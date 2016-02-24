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
using System.IO;
using System.Xml;
namespace SunPlusXML
{
    public partial class Ligar2 : Form
    {
         System.Windows.Forms.ContextMenu contextMenu1;
    System.Windows.Forms.MenuItem menuItem1;
   System.Windows.Forms.MenuItem menuItem2;
   

        public String connStringSun { get; set; }
        public String maximoSun { get; set; }
        public String folioFiscalSun { get; set; }
        public String nombreArchivoXMLSun { get; set; }

        public double amountSun { get; set; }
        public List<Dictionary<string, object>> listaFinal { get; set; }
        public List<Dictionary<string, object>> listaCandidatos { get; set; }

        public void funcionVerPDF(object sender, EventArgs e)
        {
            String pdf = listaDeCandidatos.SelectedItems[0].SubItems[4].Text;
            String ruta = listaDeCandidatos.SelectedItems[0].SubItems[5].Text;

            String nombre = ruta + (object)Path.DirectorySeparatorChar + pdf;
            System.Diagnostics.Process.Start(nombre);
        }
        public void funcionVerXML(object sender, EventArgs e)
        {
            String pdf = listaDeCandidatos.SelectedItems[0].SubItems[4].Text;
            String ruta = listaDeCandidatos.SelectedItems[0].SubItems[5].Text;

            nombreArchivoXMLSun = ruta + (object)Path.DirectorySeparatorChar + listaDeCandidatos.SelectedItems[0].SubItems[7].Text;
            System.Diagnostics.Process.Start(nombreArchivoXMLSun);
        }
        public Ligar2()
        {
            InitializeComponent();
            contextMenu1 = new System.Windows.Forms.ContextMenu();
            menuItem1 = new System.Windows.Forms.MenuItem();
            menuItem2 = new System.Windows.Forms.MenuItem();
  
            contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { menuItem1, menuItem2 });
            menuItem1.Index = 0;
            menuItem1.Text = "Ver PDF";
            menuItem2.Index = 1;
            menuItem2.Text = "Ver XML";
            menuItem1.Click += funcionVerPDF;// new SystemHandler(this.funcionVerPDF);
            menuItem2.Click += funcionVerXML;

            numeroDiario.KeyPress += numeroDiario_KeyPress;
       
            listaDeCandidatos.ContextMenu = contextMenu1;
            this.connStringSun = "Database=" + Properties.Settings.Default.sunDatabase + ";Data Source=" + Properties.Settings.Default.sunDatasource + ";Integrated Security=False;MultipleActiveResultSets=true;User ID='" + Properties.Settings.Default.sunUser + "';Password='" + Properties.Settings.Default.sunPassword + "';connect timeout = 60";
  
        }
        private void numeroDiario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {


            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
          
        }

        private void auxaux()
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            listaFinal = new List<Dictionary<string, object>>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connStringSun))
                {
                    connection.Open();
                    String queryDiario = "SELECT JRNAL_LINE, ACCNT_CODE, DESCRIPTN, ANAL_T3, ANAL_T9, AMOUNT, D_C, PERIOD FROM [" + Properties.Settings.Default.sunDatabase + "].[dbo].[" + Properties.Settings.Default.sunUnidadDeNegocio + "_" + Properties.Settings.Default.sunLibro + "_SALFLDG] WHERE JRNAL_NO = " + numeroDiario.Text + " order by JRNAL_LINE asc";
                    SqlCommand cmdCheck = new SqlCommand(queryDiario, connection);
                    SqlDataReader reader = cmdCheck.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            String jrnal_line = Convert.ToString(reader.GetInt32(0));
                            String acount = reader.GetString(1);
                            String descr = reader.GetString(2);
                            String fnct = reader.GetString(3);
                            String dtls = reader.GetString(4);
                            String amount = Convert.ToString(Math.Abs(reader.GetDecimal(5)));

                            String dc = reader.GetString(6);
                            String period = Convert.ToString(reader.GetInt32(7));
                            amountSun = Convert.ToDouble(amount);

                            Dictionary<string, object> dictionary = new Dictionary<string, object>();
                            dictionary.Add("jrnal_line", jrnal_line);
                            dictionary.Add("acount", acount);
                            dictionary.Add("descr", descr);
                            dictionary.Add("fnct", fnct);
                            dictionary.Add("dtls", dtls);
                            if (dc.Equals("D"))
                            {
                                dictionary.Add("debe", amount);
                                dictionary.Add("credito", 0);
                            }
                            else
                            {
                                dictionary.Add("debe", 0);
                                dictionary.Add("credito", amount);
                            }
                            dictionary.Add("period", period);
                            listaFinal.Add(dictionary);
                        }
                        listaDelDiario.Clear();
                        listaDelDiario.View = View.Details;
                        listaDelDiario.GridLines = true;
                        listaDelDiario.FullRowSelect = true;
                        listaDelDiario.Columns.Add("Linea", 45);
                        listaDelDiario.Columns.Add("Cuenta", 100);
                        listaDelDiario.Columns.Add("Descripción", 220);
                        listaDelDiario.Columns.Add("Función", 150);
                        listaDelDiario.Columns.Add("Detalle", 100);
                        listaDelDiario.Columns.Add("Debe", 80);
                        listaDelDiario.Columns.Add("Cargo", 80);
                        listaDelDiario.Columns.Add("Periodo", 80);

                        foreach (Dictionary<string, object> dic in listaFinal)
                        {
                            if (dic.ContainsKey("jrnal_line"))
                            {
                                string[] arr = new string[9];
                                ListViewItem itm;
                                //add items to ListView
                                arr[0] = Convert.ToString(dic["jrnal_line"]);
                                arr[1] = Convert.ToString(dic["acount"]);
                                arr[2] = Convert.ToString(dic["descr"]);
                                arr[3] = Convert.ToString(dic["fnct"]);
                                arr[4] = Convert.ToString(dic["dtls"]);
                                arr[5] = Convert.ToString(dic["debe"]);
                                arr[6] = Convert.ToString(dic["credito"]);
                                arr[7] = Convert.ToString(dic["period"]);

                                itm = new ListViewItem(arr);
                                listaDelDiario.Items.Add(itm);
                            }

                        }




                    }
                }
            }
            catch (Exception ex2)
            {
                System.Windows.Forms.MessageBox.Show(ex2.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
        }
        private void leerButton_Click(object sender, EventArgs e)
        {
            auxaux();
              
        }

        private void listaDelDiario_SelectedIndexChanged(object sender, EventArgs e)
        {
            String RFC = listaDelDiario.SelectedItems[0].SubItems[4].Text;
            String linea = listaDelDiario.SelectedItems[0].SubItems[0].Text;
           
            RFC = RFC.Substring(1);
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
                    String queryXML = "SELECT total, folioFiscal, rfc, razonSocial, nombreArchivoPDF, fechaExpedicion ,ruta,nombreArchivoXML FROM [" + Properties.Settings.Default.Database + "].[dbo].[facturacion_XML] WHERE rfc = '" + RFC + "' order by fechaExpedicion asc";
                    listaCandidatos = new List<Dictionary<string, object>>();
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
                                    String queryFISCAL2 = "SELECT AMOUNT, FOLIO_FISCAL FROM [" + Properties.Settings.Default.Database + "].[dbo].[FISCAL_xml] WHERE BUNIT = '" + Properties.Settings.Default.sunUnidadDeNegocio + "' AND JRNAL_NO = " + numeroDiario.Text + " AND JRNAL_LINE = " + linea;
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

                                                if (!folioAux.Equals(folioFiscal))
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
                                        listaCandidatos.Add(dictionary);
                                    }
                                }//using


                            }//while
                            listaDeCandidatos.Clear();
                            listaDeCandidatos.View = View.Details;
                            listaDeCandidatos.GridLines = true;
                            listaDeCandidatos.FullRowSelect = true;
                            listaDeCandidatos.Columns.Add("Fecha", 80);
                            listaDeCandidatos.Columns.Add("RFC", 100);
                            listaDeCandidatos.Columns.Add("Cantidad", 90);
                            listaDeCandidatos.Columns.Add("Razon Social", 190);
                            listaDeCandidatos.Columns.Add("RutaPDF", 0);
                            listaDeCandidatos.Columns.Add("ruta", 0);
                            listaDeCandidatos.Columns.Add("folioFiscal", 0);
                            listaDeCandidatos.Columns.Add("nombreArchivoXML", 0);

                            foreach (Dictionary<string, object> dic in listaCandidatos)
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
            folioFiscalSun = listaDeCandidatos.SelectedItems[0].SubItems[6].Text;
         
            nombreArchivoXMLSun = ruta + (object)Path.DirectorySeparatorChar + listaDeCandidatos.SelectedItems[0].SubItems[7].Text;
            maximoSun = listaDeCandidatos.SelectedItems[0].SubItems[2].Text;
            cantidadText.Text = maximoSun;
        }

        private void botonLigar_Click(object sender, EventArgs e)
        {
            String linea = listaDelDiario.SelectedItems[0].SubItems[0].Text;
           
            double cantidadALigar = Convert.ToDouble(cantidadText.Text);
            double maximo = Convert.ToDouble(maximoSun);
            if (cantidadALigar > maximo || maximo == 0)
            {
                System.Windows.Forms.MessageBox.Show("La cantidad a ligar debe de ser menor o igual a $" + maximo + " o bien, no ha elegido una factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            String xmlText = "";
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
            String queryCheck = "SELECT consecutivo FROM [" + Properties.Settings.Default.Database + "].[dbo].[FISCAL_xml] WHERE BUNIT = '" + Properties.Settings.Default.sunUnidadDeNegocio + "' and JRNAL_NO = " + numeroDiario.Text + " and JRNAL_LINE = " + linea + " order by consecutivo desc";

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
                    query = "INSERT INTO [" + Properties.Settings.Default.Database + "].[dbo].[FISCAL_xml] (BUNIT,JRNAL_NO,JRNAL_LINE,FOLIO_FISCAL,AMOUNT,STATUS,XML,consecutivo) VALUES ('" + Properties.Settings.Default.sunUnidadDeNegocio + "', " + numeroDiario.Text + ", " + linea + ", '" + folioFiscalSun + "', " + cantidadText.Text + ", 1, '" + xmlText + "' , " + consecutivo + ")";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    maximoSun = "0";
                    amountSun = 0;
                    cantidadText.Text = "";
                    listaDeCandidatos.Clear();
                    labelDiario4.Text = "";
                    System.Windows.Forms.MessageBox.Show("Diario Ligado", "SunPlusXML", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "Error Title", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                //  Logs.Escribir("Error en download complete : " + ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, object>  dictionary = new Dictionary<string, object>();
                                           ;
            this.openFileDialog1.DefaultExt = "xml";
            this.openFileDialog1.Filter = "XML Files|*.xml";
            openFileDialog1.InitialDirectory = "C:"+(object)Path.DirectorySeparatorChar;

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String linea = listaDelDiario.SelectedItems[0].SubItems[0].Text;
          
                String full = openFileDialog1.FileName;

                String[] fullArray = full.Split('\\');
                String nombreDelArchivo = fullArray.Last();

                XmlDocument doc = new XmlDocument();
                doc.Load(full);
                XmlNodeList titles = doc.GetElementsByTagName("tfd:TimbreFiscalDigital");
                XmlNode obj = titles.Item(0);
                String folio_fiscal = obj.Attributes["UUID"].InnerText;
                 
                String noCertificadoSAT = "";
                bool isNoCertificado = obj.Attributes["noCertificadoSAT"] != null;
                if (isNoCertificado)
                {
                    noCertificadoSAT = obj.Attributes["noCertificadoSAT"].InnerText;
                }

                try
                {
                    using (SqlConnection connection = new SqlConnection(connStringSun))
                    {
                        connection.Open();
                        String queryXML = "SELECT total, folioFiscal, rfc, razonSocial, nombreArchivoPDF, fechaExpedicion ,ruta,nombreArchivoXML FROM [" + Properties.Settings.Default.Database + "].[dbo].[facturacion_XML] WHERE folioFiscal = '" + folio_fiscal + "' order by fechaExpedicion asc";
                        listaCandidatos = new List<Dictionary<string, object>>();
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
                                        String queryFISCAL2 = "SELECT AMOUNT, FOLIO_FISCAL FROM [" + Properties.Settings.Default.Database + "].[dbo].[FISCAL_xml] WHERE BUNIT = '" + Properties.Settings.Default.sunUnidadDeNegocio + "' AND JRNAL_NO = " + numeroDiario.Text + " AND JRNAL_LINE = " + linea;
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

                                                    if (!folioAux.Equals(folioFiscal))
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
                                             dictionary.Add("maximo", total);
                                            dictionary.Add("folioFiscal", folioFiscal);
                                            dictionary.Add("rfc", rfc);
                                            dictionary.Add("razonSocial", razonSocial);
                                            dictionary.Add("nombreArchivoPDF", nombreArchivoPDF);
                                            dictionary.Add("nombreArchivoXML", nombreArchivoXML);
                                            dictionary.Add("fechaExpedicion", fechaExpedicion);
                                            dictionary.Add("ruta", ruta);
                                            listaCandidatos.Add(dictionary);
                                        }
                                    }//using


                                }//while
                                int cuantos = listaDeCandidatos.Items.Count ;

                                //listaDeCandidatos.Items.Count
                                if (cuantos == 0)
                                {
                                    listaDeCandidatos.Clear();
                                    listaDeCandidatos.View = View.Details;
                                    listaDeCandidatos.GridLines = true;
                                    listaDeCandidatos.FullRowSelect = true;
                                    listaDeCandidatos.Columns.Add("Fecha", 80);
                                    listaDeCandidatos.Columns.Add("RFC", 100);
                                    listaDeCandidatos.Columns.Add("Cantidad", 90);
                                    listaDeCandidatos.Columns.Add("Razon Social", 190);
                                    listaDeCandidatos.Columns.Add("RutaPDF", 0);
                                    listaDeCandidatos.Columns.Add("ruta", 0);
                                    listaDeCandidatos.Columns.Add("folioFiscal", 0);
                                    listaDeCandidatos.Columns.Add("nombreArchivoXML", 0);

                                }
                             
                                        string[] arr = new string[9];
                                        ListViewItem itm;
                                        //add items to ListView
                                        arr[0] = Convert.ToString(dictionary["fechaExpedicion"]);
                                        arr[1] = Convert.ToString(dictionary["rfc"]);
                                        arr[2] = Convert.ToString(dictionary["maximo"]);
                                        arr[3] = Convert.ToString(dictionary["razonSocial"]);
                                        arr[4] = Convert.ToString(dictionary["nombreArchivoPDF"]);
                                        arr[5] = Convert.ToString(dictionary["ruta"]);
                                        arr[6] = Convert.ToString(dictionary["folioFiscal"]);
                                        arr[7] = Convert.ToString(dictionary["nombreArchivoXML"]);

                                        itm = new ListViewItem(arr);
                                        listaDeCandidatos.Items.Add(itm);
                                   
                            }
                        }//using

                    }

                }
                catch (SqlException ex)
                {
                    this.Cursor = System.Windows.Forms.Cursors.Arrow;

                    System.Windows.Forms.MessageBox.Show(ex.ToString(), "Error Title", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

               // carpeta.Text = openFileDialog1.FileName;;
            }
        }

        private void numeroDiario_TextChanged(object sender, EventArgs e)
        {
            auxaux();
        }
    }
}
