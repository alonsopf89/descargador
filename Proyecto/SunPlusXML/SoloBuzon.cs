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
    public partial class SoloBuzon : Form
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
        public SoloBuzon()
        {
            InitializeComponent();
        }
        public String connString { get; set; }
        public String periodoI { get; set; }
        public String periodoF { get; set; }
        public int pii { get; set; }
        public int pff { get; set; }
    
        private void SoloBuzon_Load(object sender, EventArgs e)
        {
            this.connString = "Database=" + Properties.Settings.Default.Database + ";Data Source=" + Properties.Settings.Default.Datasource + ";Integrated Security=False;User ID='" + Properties.Settings.Default.User + "';Password='" + Properties.Settings.Default.Password + "';connect timeout = 60";
            this.periodoI = "";
            this.periodoF = "";
            this.pii = 0;
            this.pff = 0;
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
                                    de.Items.Add(new Item(periodo, empiezo));
                                    a.Items.Add(new Item(periodo, empiezo));
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
        public void llenaRFC(String periodoInicial, int pi, String periodoFinal, int pf)
        {
            if(periodoInicial=="" || periodoFinal == "" || pi == 0 || pf == 0)
            {
                return;
            }
            if(pi>pf)
            {
                System.Windows.Forms.MessageBox.Show("El periodo inicial debe ser menor o igual al periodo final", "SunPlusXML", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;   
            }

            List<String> periodos = new List<String>();
            int anoInicial = Convert.ToInt32( periodoInicial.Substring(0, 4));
            int mesInicial = Convert.ToInt32( periodoInicial.Substring(5, 2));

            int anoFinal = Convert.ToInt32( periodoFinal.Substring(0, 4));
            int mesFinal = Convert.ToInt32( periodoFinal.Substring(5, 2));
            int i, j;
            for(i=anoInicial;i<=anoFinal;i++)
            {
                int inicio,final;
                if(i==anoFinal)
                {
                    final = mesFinal;
                }
                else
                {
                    final = 12;
                }
                if(i==anoInicial)
                {
                    inicio = mesInicial;
                }
                else
                {
                    inicio = 1;
                }
                for(j=inicio;j<=final;j++)
                {
                    if(j<10)
                    {
                        periodos.Add(i.ToString()+"-0"+j.ToString());
                    }
                    else
                    {
                        periodos.Add(i.ToString() + "-" + j.ToString());
                    }
                }
            }

            String queryParaLlenarLosRFC = "SELECT DISTINCT rfc,razonSocial FROM [SU_FISCAL].[dbo].[facturacion_XML] WHERE SUBSTRING( CAST(fechaExpedicion AS NVARCHAR(11)),1,7) in (";
            for (i = 0; i < periodos.Count;i++ )
            {
                if(i==periodos.Count-1)
                {
                    queryParaLlenarLosRFC = queryParaLlenarLosRFC + "'" + periodos[i] + "'";
                }
                else
                {
                    queryParaLlenarLosRFC = queryParaLlenarLosRFC + "'" + periodos[i] + "',";
                }
            }
            queryParaLlenarLosRFC = queryParaLlenarLosRFC + ")";
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();

                    SqlCommand cmdCheck = new SqlCommand(queryParaLlenarLosRFC, connection);
                    SqlDataReader reader = cmdCheck.ExecuteReader();
                    int empiezo = 1;
                    if (reader.HasRows)
                    {
                        rfcCombo.Items.Clear();
                        this.todosRFC.Checked = true;
                        while (reader.Read())
                        {
                            var rfc = reader.GetString(0);
                            var razonSocial = reader.GetString(1);

                            rfcCombo.Items.Add(new Item(rfc, empiezo,razonSocial));
                            empiezo++;
                        }
                        rfcCombo.Enabled = false;
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("No existen rfc, primero descarga xml del buzon tributario.", "SunPlusXML", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Error Message", "Error Title", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

	
        }

        private void de_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item itm = (Item)de.SelectedItem;
            this.periodoI = itm.Name;
            this.pii = itm.Value;
            llenaRFC(this.periodoI, this.pii, this.periodoF, this.pff);
        }

        private void a_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item itm = (Item)a.SelectedItem;
            this.periodoF = itm.Name;
            this.pff = itm.Value;
            llenaRFC(this.periodoI, this.pii, this.periodoF, this.pff);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            rfcCombo.Enabled = true;
        }

        private void todosRFC_CheckedChanged(object sender, EventArgs e)
        {
            rfcCombo.Enabled = false;
        }

        private void todosLosPeriodos_CheckedChanged(object sender, EventArgs e)
        {
            de.Enabled = false;
            a.Enabled = false;
        }

        private void algunosPeriodos_CheckedChanged(object sender, EventArgs e)
        {
            de.Enabled = true;
            a.Enabled = true;
        }

        private void listar_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Excel|*.xls|Excel 2010|*.xlsx";
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string file = saveFileDialog1.FileName;

            List<String> periodos = new List<String>();
            int anoInicial = Convert.ToInt32(this.periodoI.Substring(0, 4));
            int mesInicial = Convert.ToInt32(this.periodoI.Substring(5, 2));

            int anoFinal = Convert.ToInt32(this.periodoF.Substring(0, 4));
            int mesFinal = Convert.ToInt32(this.periodoF.Substring(5, 2));
            int i, j;
            for (i = anoInicial; i <= anoFinal; i++)
            {
                int inicio, final;
                if (i == anoFinal)
                {
                    final = mesFinal;
                }
                else
                {
                    final = 12;
                }
                if (i == anoInicial)
                {
                    inicio = mesInicial;
                }
                else
                {
                    inicio = 1;
                }
                for (j = inicio; j <= final; j++)
                {
                    if (j < 10)
                    {
                        periodos.Add(i.ToString() + "-0" + j.ToString());
                    }
                    else
                    {
                        periodos.Add(i.ToString() + "-" + j.ToString());
                    }
                }
            }

            String queryParaLlenarLosRFC = "SELECT fechaExpedicion, rfc, razonSocial, total, folio, folioFiscal, ruta,nombreArchivoXML,nombreArchivoPDF FROM [SU_FISCAL].[dbo].[facturacion_XML] WHERE SUBSTRING( CAST(fechaExpedicion AS NVARCHAR(11)),1,7) in (";
            for (i = 0; i < periodos.Count; i++)
            {
                if (i == periodos.Count - 1)
                {
                    queryParaLlenarLosRFC = queryParaLlenarLosRFC + "'" + periodos[i] + "'";
                }
                else
                {
                    queryParaLlenarLosRFC = queryParaLlenarLosRFC + "'" + periodos[i] + "',";
                }
            }
            queryParaLlenarLosRFC = queryParaLlenarLosRFC + ") order by idXML asc";
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();

                    SqlCommand cmdCheck = new SqlCommand(queryParaLlenarLosRFC, connection);
                    SqlDataReader reader = cmdCheck.ExecuteReader();
                    int empiezo = 2;
                    if (reader.HasRows)
                    {
                        FileInfo newFile = new FileInfo(file);
                        
                        ExcelPackage pck = new ExcelPackage(newFile);
                        
                        var ws = pck.Workbook.Worksheets.Add("Content");
                        //Headers
                        ws.Cells["A1"].Value = "fechaExpedicion";
                        ws.Cells["B1"].Value = "rfc";
                        ws.Cells["C1"].Value = "razonSocial";
                        ws.Cells["D1"].Value = "total";
                        ws.Cells["E1"].Value = "folio";
                        ws.Cells["F1"].Value = "folioFiscal";
                        ws.Cells["G1"].Value = "ruta";
                        ws.Cells["H1"].Value = "nombreArchivoXML";
                        ws.Cells["I1"].Value = "nombreArchivoPDF";

                        ws.Cells["A1:I1"].Style.Font.Bold = true; 
                        while (reader.Read())
                        {
                            String fechaExpedicion = Convert.ToString(reader.GetDateTime(0));
                            String rfc = reader.GetString(1);
                            String razonSocial = reader.GetString(2);
                            double total = Convert.ToDouble(reader.GetDecimal(3));
                            String folio = reader.GetString(4);
                            String folioFiscal = reader.GetString(5);
                            String ruta = reader.GetString(6);
                            String nombreArchivoXML = reader.GetString(7);
                            String nombreArchivoPDF = reader.GetString(8);

                            ws.Cells["A" + empiezo].Value = fechaExpedicion;
                            ws.Cells["B" + empiezo].Value = rfc;
                            ws.Cells["C" + empiezo].Value = razonSocial;
                            ws.Cells["D" + empiezo].Value = total;
                            ws.Cells["E" + empiezo].Value = folio;
                            ws.Cells["F" + empiezo].Value = folioFiscal;
                            ws.Cells["G" + empiezo].Value = ruta;
                            ws.Cells["H" + empiezo].Value = nombreArchivoXML;
                            ws.Cells["I" + empiezo].Value = nombreArchivoPDF;
                            string FileRootPath = ruta + (object)Path.DirectorySeparatorChar + nombreArchivoPDF;
                            string FileRootPathXML = ruta + (object)Path.DirectorySeparatorChar + nombreArchivoXML;
                            ws.Cells["H" + empiezo].Formula = "HYPERLINK(\"" + FileRootPathXML + "\",\"XML\")";

                            ws.Cells["I" + empiezo].Formula = "HYPERLINK(\"" + FileRootPath + "\",\"PDF\")";

                            empiezo++;
                        }
                        pck.Save();
                        System.Windows.Forms.MessageBox.Show("Archivo Guardado Exitosamente", "SunPlusXML", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
       
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("No existen registros, primero descarga xml del buzon tributario.", "SunPlusXML", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Error Message", "Error Title", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


          
	
        }

        private void rfcCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item itm = (Item)rfcCombo.SelectedItem;
            razonSocial.Text = itm.Extra;
         
        }
    }
}
