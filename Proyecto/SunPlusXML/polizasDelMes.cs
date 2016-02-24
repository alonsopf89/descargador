using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using OfficeOpenXml;
using System.IO;
namespace SunPlusXML
{
    public partial class polizasDelMes : Form
    {
        private class Item
        {
            public string Name;
            public int Value;
            public string Extra;

            public Item(string name, int value, String extra)
            {
                Name = name; Value = value;
                Extra = extra;
            }
            public Item(string name, int value)
            {
                Name = name; Value = value;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Name;
            }
        }
        public polizasDelMes()
        {
            InitializeComponent();
        }
        public String connString { get; set; }
        public List<Dictionary<string, object>> listaFinal { get; set; }

        private void polizasDelMes_Load(object sender, EventArgs e)
        {
            this.connString = "Database=" + Properties.Settings.Default.Database + ";Data Source=" + Properties.Settings.Default.Datasource + ";Integrated Security=False;MultipleActiveResultSets=true;User ID='" + Properties.Settings.Default.User + "';Password='" + Properties.Settings.Default.Password + "';connect timeout = 60";
             String queryPeriodos = "SELECT DISTINCT SUBSTRING( CAST(fechaExpedicion AS NVARCHAR(11)),1,7) as periodos FROM [SU_FISCAL].[dbo].[facturacion_XML]";
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();

                    SqlCommand cmdCheck = new SqlCommand(queryPeriodos, connection);
                    SqlDataReader reader = cmdCheck.ExecuteReader();
                    int empiezo = 1;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var periodo = reader.GetString(0);
                            periodosCombo.Items.Add(new Item(periodo, empiezo));
                            empiezo++;
                        }
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("No existen Periodos, primero descarga xml del buzon tributario.", "SunPlusXML", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Error Message", "Error Title", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void periodosCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item itm = (Item)periodosCombo.SelectedItem;
            //1.- genero la tabla con los rfc del mes y sus cantidades de lo que tiene el sat
            //2.- para cada folio fiscal en la tabala FISCAL, hago un query con el folio fiscal y el periodo seleccionado, obtengo el rfc y la cantidad, y a la cantidad obtenida le sumo al diccionario de la lista
            //nota: usare una lista de diccionarios que llenare en el paso uno y modificare en el paso 2, y finalmente lleno la vista
            String periodo = itm.Name;
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connString))
                {
                    connection.Open();
                    String queryXML = "SELECT rfc,SUM(total) as total,razonSocial FROM [SU_FISCAL].[dbo].[facturacion_XML] WHERE SUBSTRING( CAST(fechaExpedicion AS NVARCHAR(11)),1,7) = '"+periodo+"' GROUP BY rfc,razonSocial order by rfc asc";
                    listaFinal = new List<Dictionary<string, object>>();
                    using (SqlCommand cmdCheck = new SqlCommand(queryXML, connection))
                    {
                        SqlDataReader reader = cmdCheck.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                double total = Convert.ToDouble(Math.Abs(reader.GetDecimal(1)));
                                String rfc = reader.GetString(0);
                                String razonSocial = reader.GetString(2);

                      
                                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                                dictionary.Add("maximo", total);
                                 dictionary.Add("rfc", rfc);
                                dictionary.Add("enlazado", 0);
                                dictionary.Add("razonSocial", razonSocial);
                               
                                listaFinal.Add(dictionary);
                            }
                            double amount = 0;
                            String folioFiscal = "";
                            String queryFISCAL = "SELECT FOLIO_FISCAL,AMOUNT FROM [" + Properties.Settings.Default.Database + "].[dbo].[FISCAL_xml]";
                            using (SqlCommand cmdCheckFISCAL = new SqlCommand(queryFISCAL, connection))
                            {
                                SqlDataReader readerFISCAL = cmdCheckFISCAL.ExecuteReader();
                                if (readerFISCAL.HasRows)
                                {
                                    while (readerFISCAL.Read())
                                    {
                                        amount = Convert.ToDouble(Math.Abs(readerFISCAL.GetDecimal(1)));
                                        folioFiscal = readerFISCAL.GetString(0);
                                        String queryFISCAL2 = "SELECT rfc FROM [" + Properties.Settings.Default.Database + "].[dbo].[facturacion_XML] WHERE folioFiscal = '" + folioFiscal + "' AND SUBSTRING( CAST(fechaExpedicion AS NVARCHAR(11)),1,7)  = '" + periodo + "'";
                                        using (SqlCommand cmdCheckFISCAL2 = new SqlCommand(queryFISCAL2, connection))
                                        {
                                             SqlDataReader readerFISCAL2 = cmdCheckFISCAL2.ExecuteReader();
                                             if (readerFISCAL2.HasRows)
                                             {
                                                 while (readerFISCAL2.Read())
                                                 {
                                                     String rfcAux = Convert.ToString(readerFISCAL2.GetString(0));
                                                     foreach (Dictionary<string, object> dic in listaFinal)
                                                     {
                                                         if(dic["rfc"].Equals(rfcAux))
                                                         {
                                                             dic["enlazado"] = Convert.ToString(Convert.ToDouble(dic["enlazado"]) + amount);
                                                         }
                                                     }
                                                 }
                                             }
                                         }

                                    }
                                }
                            }


                            listaRFC.Clear();
                            listaRFC.View = View.Details;
                            listaRFC.GridLines = true;
                            listaRFC.FullRowSelect = true;
                            listaRFC.Columns.Add("Razon Social", 180);
                            listaRFC.Columns.Add("RFC", 100);
                            listaRFC.Columns.Add("En el SAT", 100);
                            listaRFC.Columns.Add("Contabilizado", 100);
                          
                             foreach (Dictionary<string, object> dic in listaFinal)
                             {
                                 if (dic.ContainsKey("rfc"))
                                 {
                                     string[] arr = new string[5];
                                     ListViewItem itm2;
                                     //add items to ListView
                                     arr[0] = Convert.ToString(dic["razonSocial"]);
                                     arr[1] = Convert.ToString(dic["rfc"]);
                                     arr[2] = Convert.ToString(dic["maximo"]);
                                     arr[3] = Convert.ToString(dic["enlazado"]);
                                     
                                     itm2 = new ListViewItem(arr);
                                     listaRFC.Items.Add(itm2);
                                 }
                             }
                        }//if reader
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "Error Title", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


            
        }

        private void generarXML_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }
    }
}
