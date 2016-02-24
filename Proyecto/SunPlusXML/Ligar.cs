using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using mshtml;
namespace SunPlusXML
{
    public partial class Ligar : Form
    {
        public String connStringSun { get; set; }
        public String maximoSun { get; set; }
        public String folioFiscalSun { get; set; }
        public String nombreArchivoXMLSun { get; set; }
      
        public double amountSun { get; set; }
        public List<Dictionary<string, object>> listaFinal { get; set; }

        public Ligar()
        {
            InitializeComponent();
           
          //  labelDiario.AutoSize = false;
            this.connStringSun = "Database=" + Properties.Settings.Default.sunDatabase + ";Data Source=" + Properties.Settings.Default.sunDatasource + ";Integrated Security=False;MultipleActiveResultSets=true;User ID='" + Properties.Settings.Default.sunUser + "';Password='" + Properties.Settings.Default.sunPassword + "';connect timeout = 60";
      //      axPDFViewer1.LoadFile("//psf/Home/Documents/2015/test/01 ENE/FF465689-2971-4BD1-8ED4-BE5FC479C3D3.pdf");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
      
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buscar_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            
            try
            {
                using (SqlConnection connection = new SqlConnection(connStringSun))
                {
                    connection.Open();
                    String queryDiario = "SELECT AMOUNT, D_C, PERIOD, DESCRIPTN FROM ["+Properties.Settings.Default.sunDatabase+"].[dbo].["+Properties.Settings.Default.sunUnidadDeNegocio+"_"+Properties.Settings.Default.sunLibro+"_SALFLDG] WHERE JRNAL_NO = "+numeroDiario.Text+" AND JRNAL_LINE = "+lineaDiario.Text;
                    SqlCommand cmdCheck = new SqlCommand(queryDiario, connection);
                    SqlDataReader reader = cmdCheck.ExecuteReader();
                    if(reader.HasRows)
                    {
                        while (reader.Read())
                        {
                           String amount = Convert.ToString( Math.Abs(  reader.GetDecimal(0) ));

                            String dc = reader.GetString(1);
                            String period = Convert.ToString(reader.GetInt32(2));
                            String descr = reader.GetString(3);
                            amountSun = Convert.ToDouble(amount);
                            labelDiario.Text = "$ " + amount + " " + dc;
                            labelDiario2.Text = period;
                            labelDiario3.Text = descr;
                        }
                    }
                }
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Error Message", "Error Title", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
              
        }
        private void InitializeAdobe(string filePath)
        {
            try
            {
                
                 //this.axAcroPDF1.LoadFile(filePath);
                //this.axAcroPDF1.src = filePath;
                //this.axAcroPDF1.setShowToolbar(false);
                //this.axAcroPDF1.setView("FitH");
                //this.axAcroPDF1.setLayoutMode("SinglePage");
              //  this.axAcroPDF1.Show();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        private void axAcroPDF1_Enter(object sender, EventArgs e)
        {
            
        }

        private void xmlCantidad_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
           
            //1.- Sacamos todas las facturas que tengan esa cantidad, son los candidatos
            //2.- Hacemos una lista con esos candidatos por folio fiscal
            //3.- Para cada folio fiscal, checamos que no esten ya en la tabla FISCAL
            //4.- Si  no estan en la tabla, los agregamos a la lista final
            //5.- Si ya estan, restamos la cantidad con la que estan
            //6.- Si despues de la resta no tienen saldo, no los agregamos a la lista final
            //7.- Si despues de la resta tienen saldo, los agregamos a la lista final
            //8.- Limitar la cantidad a ligar, poniendo como maximo la resta
            try
            {
                using (SqlConnection connection = new SqlConnection(connStringSun))
                {
                    connection.Open();
                    String queryXML = "SELECT total, folioFiscal, rfc, razonSocial, nombreArchivoPDF, fechaExpedicion ,ruta,nombreArchivoXML FROM [" + Properties.Settings.Default.Database + "].[dbo].[facturacion_XML] WHERE total = " + amountSun + " order by fechaExpedicion asc";
                     listaFinal = new List< Dictionary<string,object> >();
                     using (SqlCommand cmdCheck = new SqlCommand(queryXML, connection))
                     {
                         SqlDataReader reader = cmdCheck.ExecuteReader();
                         if (reader.HasRows)
                         {
                             while (reader.Read())
                             {
                                 double total = Convert.ToDouble(Math.Abs(reader.GetDecimal(0)));
                                 String folioFiscal = reader.GetString(1);
                                 String rfc = reader.GetString(2);
                                 String nombreArchivoPDF = reader.GetString(4);
                                 String nombreArchivoXML = reader.GetString(7);
                                 String razonSocial = reader.GetString(3);
                                 String fechaExpedicion = Convert.ToString(reader.GetDateTime(5));
                                 String ruta = reader.GetString(6);
                                 //cuanto esta enlazado de esa factura
                                 String queryFISCAL = "SELECT FOLIO_FISCAL,BUNIT,JRNAL_NO,JRNAL_LINE,AMOUNT,consecutivo FROM [" + Properties.Settings.Default.Database + "].[dbo].[FISCAL_xml] WHERE FOLIO_FISCAL = '" + folioFiscal + "'";
                                 using (SqlCommand cmdCheckFISCAL = new SqlCommand(queryFISCAL, connection))
                                   { 
                                SqlDataReader readerFISCAL = cmdCheckFISCAL.ExecuteReader();
                                 if (readerFISCAL.HasRows)
                                 {
                                     while (readerFISCAL.Read())
                                     {
                                         double amount = Convert.ToDouble(Math.Abs(readerFISCAL.GetDecimal(4)));
                                         total = total - amount;
                                     }
                                 }
                                 double acumulador = 0;
                                     //cuanto esta enlazado de ese diario
                                 String queryFISCAL2 = "SELECT AMOUNT, FOLIO_FISCAL FROM [" + Properties.Settings.Default.Database + "].[dbo].[FISCAL_xml] WHERE BUNIT = '" + Properties.Settings.Default.sunUnidadDeNegocio + "' AND JRNAL_NO = "+numeroDiario.Text+" AND JRNAL_LINE = "+lineaDiario.Text;
                                 using (SqlCommand cmdCheckFISCAL2 = new SqlCommand(queryFISCAL2, connection))
                                 {
                                     SqlDataReader readerFISCAL2 = cmdCheckFISCAL2.ExecuteReader();
                                     if (readerFISCAL2.HasRows)
                                     {
                                         while (readerFISCAL2.Read())
                                         {
                                             double amount = Convert.ToDouble(Math.Abs(readerFISCAL2.GetDecimal(0)));
                                             String folioAux = Convert.ToString(readerFISCAL2.GetString(1));
                                             acumulador += amount;
                                          
                                             if(!folioAux.Equals(folioFiscal) )
                                             {
                                                 total = total - amount;
                                             }
                                             
                                         }
                                         labelDiario4.Text = " $" + acumulador + " enlazado";
                                            
                                     }
                                     else
                                     {
                                         labelDiario4.Text = " $ 0 enlazado";
                                            
                                     }
                                 }

                                 if (total > 0)
                                 {
                                     Dictionary<string, object> dictionary = new Dictionary<string, object>();
                                     dictionary.Add("maximo", total);
                                     dictionary.Add("folioFiscal", folioFiscal);
                                     dictionary.Add("rfc", rfc);
                                     dictionary.Add("razonSocial", razonSocial);
                                     dictionary.Add("nombreArchivoPDF", nombreArchivoPDF);
                                     dictionary.Add("nombreArchivoXML", nombreArchivoXML);
                                     dictionary.Add("fechaExpedicion", fechaExpedicion);
                                     dictionary.Add("ruta", ruta);
                                     listaFinal.Add(dictionary);
                                 }
                                }//using


                             }//while
                             listaDeCandidatos.Clear();
                             listaDeCandidatos.View = View.Details;
                             listaDeCandidatos.GridLines = true;
                             listaDeCandidatos.FullRowSelect = true;
                             listaDeCandidatos.Columns.Add("Fecha", 80);
                             listaDeCandidatos.Columns.Add("RFC", 100);
                             listaDeCandidatos.Columns.Add("Cantidad", 50);
                             listaDeCandidatos.Columns.Add("Razon Social", 150);
                             listaDeCandidatos.Columns.Add("RutaPDF", 0);
                             listaDeCandidatos.Columns.Add("ruta", 0);
                             listaDeCandidatos.Columns.Add("folioFiscal", 0);
                             listaDeCandidatos.Columns.Add("nombreArchivoXML", 0);
                          
                             foreach (Dictionary<string, object> dic in listaFinal)
                             {
                                 if (dic.ContainsKey("folioFiscal"))
                                 {
                                     string[] arr = new string[9];
                                     ListViewItem itm;
                                     //add items to ListView
                                     arr[0] = Convert.ToString(dic["fechaExpedicion"]);
                                     arr[1] = Convert.ToString(dic["rfc"]);
                                     arr[2] = Convert.ToString(dic["maximo"]);
                                     arr[3] = Convert.ToString(dic["razonSocial"]);
                                     arr[4] = Convert.ToString(dic["nombreArchivoPDF"]);
                                     arr[5] = Convert.ToString(dic["ruta"]);
                                     arr[6] = Convert.ToString(dic["folioFiscal"]);
                                     arr[7] = Convert.ToString(dic["nombreArchivoXML"]);
                                  
                                     itm = new ListViewItem(arr);
                                     listaDeCandidatos.Items.Add(itm);
                                 }

                             }
                         }
                     }//using
                    
                }
                
            }
            catch (SqlException ex)
            {
                this.Cursor = System.Windows.Forms.Cursors.Arrow;
        
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "Error Title", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
        
        }

        private void listaDeCandidatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            String ruta = listaDeCandidatos.SelectedItems[0].SubItems[5].Text;
         
            nombreArchivoXMLSun =ruta+(object)Path.DirectorySeparatorChar+ listaDeCandidatos.SelectedItems[0].SubItems[7].Text;
        
            
            folioFiscalSun = listaDeCandidatos.SelectedItems[0].SubItems[6].Text;
           maximoSun = listaDeCandidatos.SelectedItems[0].SubItems[2].Text;
            cantidadText.Text = maximoSun;
           String pdfRuta  = listaDeCandidatos.SelectedItems[0].SubItems[4].Text;
           String url = "file:" + (object)Path.DirectorySeparatorChar + (object)Path.DirectorySeparatorChar+ruta + (object)Path.DirectorySeparatorChar + pdfRuta;
          // this.webBrowser1.Navigate(new Uri(url));
           this.webView1.ZoomFactor = 1.5;
           this.webView1.Url = url;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double cantidadALigar = Convert.ToDouble( cantidadText.Text);
            double maximo = Convert.ToDouble(maximoSun);
            if(cantidadALigar>maximo || maximo ==0)
            {
                System.Windows.Forms.MessageBox.Show("La cantidad a ligar debe de ser menor o igual a $"+maximo+" o bien, no ha elegido una factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            String xmlText="";
            try
            {
                using (StreamReader sr = new StreamReader(nombreArchivoXMLSun))
                {
                    xmlText = sr.ReadToEnd();
                   
                }
            }
            catch (Exception ex2)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ex2.Message);
            }
            String queryCheck = "SELECT consecutivo FROM [" + Properties.Settings.Default.Database + "].[dbo].[FISCAL_xml] WHERE BUNIT = '" + Properties.Settings.Default.sunUnidadDeNegocio + "' and JRNAL_NO = "+numeroDiario.Text+" and JRNAL_LINE = "+lineaDiario.Text+" order by consecutivo desc";
                  
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connStringSun))
                {
                    connection.Open();
                    SqlCommand cmdCheck = new SqlCommand(queryCheck, connection);
                    SqlDataReader reader = cmdCheck.ExecuteReader();
                    String query;
                    int consecutivo = 0;
                    if (reader.Read())
                    {
                         consecutivo = reader.GetInt32(0);
                        consecutivo++;
                         reader.Close();
                         connection.Close();

                         connection.Open();
                     
                         
                     }
                    else
                    {
                        reader.Close();
                        connection.Close();

                        connection.Open();
                         consecutivo = 1;

                    }
                     query = "INSERT INTO [" + Properties.Settings.Default.Database + "].[dbo].[FISCAL_xml] (BUNIT,JRNAL_NO,JRNAL_LINE,FOLIO_FISCAL,AMOUNT,STATUS,XML,consecutivo) VALUES ('" + Properties.Settings.Default.sunUnidadDeNegocio + "', " + numeroDiario.Text + ", " + lineaDiario.Text + ", '" + folioFiscalSun + "', " + cantidadText.Text + ", 1, '" + xmlText + "' , " + consecutivo + ")";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    maximoSun = "0";
                    amountSun = 0;
                    cantidadText.Text = "";
                    listaDeCandidatos.Clear();
                    lineaDiario.Text = "";
                    numeroDiario.Text = "";
                    labelDiario.Text = "";
                    labelDiario2.Text = "";
                    labelDiario3.Text = "";
                    labelDiario4.Text = "";
                    System.Windows.Forms.MessageBox.Show("Diario Ligado", "SunPlusXML", MessageBoxButtons.OK, MessageBoxIcon.Information );
                
                   
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "Error Title", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                //  Logs.Escribir("Error en download complete : " + ex.ToString());
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        
    }
}
