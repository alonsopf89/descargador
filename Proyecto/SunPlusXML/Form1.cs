using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net.Mail;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Threading.Tasks;
using System.Windows.Forms;
using EO.WebBrowser;
using EO.WebBrowser.Wpf;
using HtmlAgilityPack;
using System.Windows;
using System.Windows.Controls;
using System.Globalization;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data.Linq;
using System.Windows.Input;
using System.Windows.Markup;
using PdfFileWriter;
namespace SunPlusXML
{
    public partial class Form1 : Form
    {
        private Timer timer1;
        public List<string> ligas;
        public string MesSel { get; set; }
        public Stopwatch tiemporec { get; set; }

        public string AnoSel { get; set; }
        public int liga { get; set; }

        public int descargado { get; set; }
        public int status { get; set; }
        public int primeraVez { get; set; }
        public String Enters { get; set; }
        public List<DownloadItem> Descargados { get; set; }
        public Timer tmr { get; set; }
        public Timer tmrPrimero { get; set; }
        public Timer tmrSegundo { get; set; }
        public Timer tmrTercero { get; set; }
        public Timer tmrCuarto { get; set; }
        public Timer tmrQuinto { get; set; }
        public Timer tmrSexto { get; set; }
        public Timer tmrSeptimo { get; set; }
        public Timer tmrOctavo { get; set; }
        public Timer tmrNoveno { get; set; }
        public Timer tmrDecimo { get; set; }
        public Timer tmrDecimoPrimero { get; set; }
        public Timer tmrDecimoSegundo { get; set; }
        public Timer tmrDecimoTercero { get; set; }
        public Timer tmrDecimoCuarto { get; set; }
        public Timer tmrDecimoQuinto { get; set; }
        public Timer tmrDecimoSexto { get; set; }
        public Timer tmrDecimoSeptimo { get; set; }
       
        public String month { get; set; }
        public String year { get; set; }
        public String day { get; set; }

        public StringBuilder mensajeParaElCorreo { get; set; }
      
        public int diaActual { get; set; }
        public int mesActual { get; set; }
      
        public bool estoyEnCancelados { get; set; }
        public bool estoyEnElMesAnterior { get; set; }
        public bool primeroElMesAnterior { get; set; }
        public bool cualCheco { get; set; }
        public bool estoyEnEmitidos { get; set; }
        public bool soloUnaVezNoveno { get; set; }
        public bool Cancelar { get; set; }
        public bool entraUnaSolaVezAlAux { get; set; }
       // public bool modoUnDia { get; set; }
        public int columna { get; set; }
        public int totalDeDescargados { get; set; }
        public int totalDeCancelados { get; set; }
        public int totalDeYaExistian { get; set; }
        public DateTime tomorrow { get; set; }
        public int posicion { get; set; }
     public int cuantosYaExistian { get; set; }
             public int cuantosNoSeInsertaron { get; set; }

       // public List<LogErrores> log { get; set; }
        public int start { get; set; }
        public String connString { get; set; }
        public int modoGlobal { get; set; }
        public int anoAnterior { get; set; }
      
        public Form1(int modo)
        {
            modoGlobal = modo;
            anoAnterior = 0;
            if(modo==3)//ultrapesado del ano anterior
                {
                    modoGlobal = 2;//trabaja como todo el ano
                    anoAnterior = 1;//pero descarga la del año anterior!
                }
            InitializeComponent();
             this.connString = "Database=" + Properties.Settings.Default.Database + ";Data Source=" + Properties.Settings.Default.Datasource + ";Integrated Security=False;User ID='" + Properties.Settings.Default.User + "';Password='"+Properties.Settings.Default.Password+"';connect timeout = 60";

           
           
            this.timer1 = new Timer();
            this.timer1.Interval = 2000;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);

        }
        public Form1(int modo, String rfcNuevo, String ciecNueva, String correoNuevo)
        {
            modoGlobal = modo;
            InitializeComponent();
            this.connString = "Database=" + Properties.Settings.Default.Database + ";Data Source=" + Properties.Settings.Default.Datasource + ";Integrated Security=False;User ID='" + Properties.Settings.Default.User + "';Password='" + Properties.Settings.Default.Password + "';connect timeout = 60";

            Properties.Settings.Default.RFC = rfcNuevo;
            Properties.Settings.Default.pass = ciecNueva;
            Properties.Settings.Default.correoReceptor = correoNuevo;
           // Properties.Settings.Default.deboGuardar = "0";
            Properties.Settings.Default.Save();

            this.timer1 = new Timer();
            this.timer1.Interval = 3000;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);

        }
        private void PruebaDescarga(ref string RFC)
        {
      /*       this.columna = -1;
      this.proceso.Text = "Preparando informacion...";
         string html = this.webView3.GetHtml();
         
      HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
      htmlDocument.LoadHtml(html);
      IEnumerable<HtmlNode> enumerable1 = (IEnumerable<HtmlNode>) Enumerable.ToArray<HtmlNode>(Enumerable.Where<HtmlNode>(htmlDocument.DocumentNode.Descendants("span"), (Func<HtmlNode, bool>) (n => n.Attributes["id"] != null && n.Attributes["id"].Value == "ctl00_LblRfcAutenticado")));
      try
      {
        RFC = ((HtmlNode[]) enumerable1)[0].InnerText.Replace("RFC Autenticado: ", "");
      }
      catch (Exception ex)
      {
      //  Logs.Escribir(ex.ToString());
        return;
      }
   // if (!string.IsNullOrEmpty(RFC) && RFC.Replace("&amp;", "&") != Sesion.RFC.Replace("&amp;", "&"))
     //   return;
      int num1 = html.IndexOf("Consultar Facturas Recibidas");
      html.IndexOf("Consultar Facturas Emitidas");
      html.IndexOf("La consulta realizada solo muestra los primeros 500 registros");
      HtmlNode[] htmlNodeArray = Enumerable.ToArray<HtmlNode>(Enumerable.Where<HtmlNode>(htmlDocument.DocumentNode.Descendants("img"), (Func<HtmlNode, bool>) (n => n.Attributes["name"] != null && n.Attributes["name"].Value == "BtnDescarga")));
      IEnumerable<HtmlNode> enumerable2 = (IEnumerable<HtmlNode>) Enumerable.ToArray<HtmlNode>(Enumerable.Where<HtmlNode>(htmlDocument.DocumentNode.Descendants("select"), (Func<HtmlNode, bool>) (n => n.Attributes["id"] != null && n.Attributes["id"].Value == "ctl00_MainContent_CldFecha_DdlMes")));
      IEnumerable<HtmlNode> enumerable3 = (IEnumerable<HtmlNode>) Enumerable.ToArray<HtmlNode>(Enumerable.Where<HtmlNode>(htmlDocument.DocumentNode.Descendants("select"), (Func<HtmlNode, bool>) (n => n.Attributes["id"] != null && n.Attributes["id"].Value == "DdlAnio")));
      IEnumerable<HtmlNode> enumerable4 = (IEnumerable<HtmlNode>) Enumerable.ToArray<HtmlNode>(Enumerable.Where<HtmlNode>(htmlDocument.DocumentNode.Descendants("input"), (Func<HtmlNode, bool>) (n => n.Attributes["id"] != null && n.Attributes["id"].Value == "ctl00_MainContent_CldFechaInicial2_Calendario_text")));
      IEnumerable<HtmlNode> enumerable5 = (IEnumerable<HtmlNode>) Enumerable.ToArray<HtmlNode>(Enumerable.Where<HtmlNode>(htmlDocument.DocumentNode.Descendants("input"), (Func<HtmlNode, bool>) (n => n.Attributes["id"] != null && n.Attributes["id"].Value == "ctl00_MainContent_CldFechaFinal2_Calendario_text")));
      IEnumerable<HtmlNode> enumerable6 = (IEnumerable<HtmlNode>) Enumerable.ToArray<HtmlNode>(Enumerable.Where<HtmlNode>(htmlDocument.DocumentNode.Descendants("select"), (Func<HtmlNode, bool>) (n => n.Attributes["id"] != null && n.Attributes["id"].Value == "ctl00_MainContent_BtnBusqueda")));
     // this.listadoSAT = new List<TablaImportadaSAT>();
      this.ligas = new List<string>();
      //TablaImportadaSAT tablaImportadaSat = new TablaImportadaSAT();
      if (num1 > -1)
      {
        foreach (HtmlNode htmlNode1 in enumerable2)
        {
          foreach (HtmlNode htmlNode2 in (IEnumerable<HtmlNode>) htmlNode1.ChildNodes)
          {
            if (htmlNode2.HasAttributes && htmlNode2.GetAttributeValue("selected", "") != "" && htmlNode2.Attributes["selected"].Value == "selected")
            {
              this.MesSel = Convert.ToInt32(htmlNode2.GetAttributeValue("Value", "")).ToString("00") + " " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(htmlNode2.GetAttributeValue("Value", ""))).Substring(0, 3).ToUpper();          
              //this.MesSel = Convert.ToInt32(htmlNode2.GetAttributeValue("Value", "")).ToString("00") + " " + FuncionesGenerales.NombreMes(Convert.ToInt32(htmlNode2.GetAttributeValue("Value", "")), true).ToUpper();
              break;
            }
          }
        }
        foreach (HtmlNode htmlNode1 in enumerable3)
        {
          foreach (HtmlNode htmlNode2 in (IEnumerable<HtmlNode>) htmlNode1.ChildNodes)
          {
            if (htmlNode2.HasAttributes && htmlNode2.GetAttributeValue("selected", "") != "" && htmlNode2.Attributes["selected"].Value == "selected")
            {
              this.AnoSel = htmlNode2.GetAttributeValue("Value", "");
              break;
            }
          }
        }
        this.AnoSel = "Recibidos" + (object) Path.DirectorySeparatorChar + this.AnoSel;
      }
      else
      {
        DateTime startDate = DateTime.Today;
        DateTime endDate = DateTime.Today;
        foreach (HtmlNode htmlNode in enumerable4)
        {
          if (htmlNode.HasAttributes && htmlNode.GetAttributeValue("value", "") != "" && htmlNode.Attributes["value"].Value != "")
          {
            startDate = Convert.ToDateTime(htmlNode.GetAttributeValue("value", ""));
            break;
          }
        }
        foreach (HtmlNode htmlNode in enumerable5)
        {
          if (htmlNode.HasAttributes && htmlNode.GetAttributeValue("value", "") != "" && htmlNode.Attributes["value"].Value != "")
          {
            endDate = Convert.ToDateTime(htmlNode.GetAttributeValue("value", ""));
            break;
          }
        }
        
        int num2 = DateTime.DaysInMonth(startDate.Year, startDate.Month);
        if (System.Data.Linq.SqlClient.SqlMethods.DateDiffDay(startDate, endDate) + 1 > num2)
        {
          //Mensajes.MostrarMensaje(Constantes.TipoMensaje.Aviso, "Descarga Masiva", "La consulta de conprobantes emitidos no puede ser mayor de un mes");
          this.Cursor = System.Windows.Forms.Cursors.Arrow;
          this.proceso.Text = "";
          this.Cancelar = true;
         // this.btnCancelar.Visibility = Visibility.Hidden;
          return;
        }
        if (startDate.Month != endDate.Month)
        {
        //  Mensajes.MostrarMensaje(Constantes.TipoMensaje.Aviso, "Descarga Masiva", "La fecha inicial y la fecha final deben ser del mismo mes" + Environment.NewLine + "Mes Inicial:" + FuncionesGenerales.NombreMes(startDate.Month, false) + " Mes Final:" + FuncionesGenerales.NombreMes(endDate.Month, false));
          this.Cursor = System.Windows.Forms.Cursors.Arrow;
          this.proceso.Text = "";
          this.Cancelar = true;
        //  this.btnCancelar.Visibility = Visibility.Hidden;
          return;
        }
        this.MesSel = startDate.Month.ToString("00") + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(startDate.Month).Substring(0, 3).ToUpper();
        //this.MesSel = startDate.Month.ToString("00") + FuncionesGenerales.NombreMes(startDate.Month, true).ToUpper();
        this.AnoSel = "Emitidos" + (object) Path.DirectorySeparatorChar + (string) (object) startDate.Year;
      }
      foreach (HtmlNode htmlNode in htmlNodeArray)
      {
          string str = htmlNode.Attributes[6].Value;
          int num2 = str.IndexOf("AccionCfdi('");
          int num3 = str.IndexOf("','Recuperacion'");
          this.ligas.Add("https://portalcfdi.facturaelectronica.sat.gob.mx/RecuperaCfdi.aspx?" + str.Substring(num2 + 12, num3 - num2 - 12).Replace("RecuperaCfdi.aspx?", ""));
      }
      this.Descargados = new List<DownloadItem>();
            */
            ///////////////////
             this.columna = -1;
              this.proceso.Text = "Preparando informacion...";
              string html = this.webView3.GetHtml();
              HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
              htmlDocument.LoadHtml(html);
              IEnumerable<HtmlNode> enumerable1 = (IEnumerable<HtmlNode>)Enumerable.ToArray<HtmlNode>(Enumerable.Where<HtmlNode>(htmlDocument.DocumentNode.Descendants("span"), (Func<HtmlNode, bool>)(n => n.Attributes["id"] != null && n.Attributes["id"].Value == "ctl00_LblRfcAutenticado")));
              try
              {
                  RFC = ((HtmlNode[])enumerable1)[0].InnerText.Replace("RFC Autenticado: ", "");
                  rfcLabel.Text = RFC;
              }
              catch (Exception ex)
              {
                  ex.ToString();
            //      Logs.Escribir(ex.ToString());
                  return;
              }
        //      if (!string.IsNullOrEmpty(RFC) && RFC.Replace("&amp;", "&") != Sesion.RFC.Replace("&amp;", "&"))
          //        return;
              int num1 = html.IndexOf("Consultar Facturas Recibidas");
              html.IndexOf("Consultar Facturas Emitidas");
              HtmlNode[] htmlNodeArray = Enumerable.ToArray<HtmlNode>(Enumerable.Where<HtmlNode>(htmlDocument.DocumentNode.Descendants("img"), (Func<HtmlNode, bool>)(n => n.Attributes["name"] != null && n.Attributes["name"].Value == "BtnDescarga")));
              IEnumerable<HtmlNode> enumerable2 = (IEnumerable<HtmlNode>)Enumerable.ToArray<HtmlNode>(Enumerable.Where<HtmlNode>(htmlDocument.DocumentNode.Descendants("select"), (Func<HtmlNode, bool>)(n => n.Attributes["id"] != null && n.Attributes["id"].Value == "ctl00_MainContent_CldFecha_DdlMes")));
              IEnumerable<HtmlNode> enumerable3 = (IEnumerable<HtmlNode>)Enumerable.ToArray<HtmlNode>(Enumerable.Where<HtmlNode>(htmlDocument.DocumentNode.Descendants("select"), (Func<HtmlNode, bool>)(n => n.Attributes["id"] != null && n.Attributes["id"].Value == "DdlAnio")));
              IEnumerable<HtmlNode> enumerable4 = (IEnumerable<HtmlNode>)Enumerable.ToArray<HtmlNode>(Enumerable.Where<HtmlNode>(htmlDocument.DocumentNode.Descendants("input"), (Func<HtmlNode, bool>)(n => n.Attributes["id"] != null && n.Attributes["id"].Value == "ctl00_MainContent_CldFechaInicial2_Calendario_text")));
              IEnumerable<HtmlNode> enumerable5 = (IEnumerable<HtmlNode>)Enumerable.ToArray<HtmlNode>(Enumerable.Where<HtmlNode>(htmlDocument.DocumentNode.Descendants("input"), (Func<HtmlNode, bool>)(n => n.Attributes["id"] != null && n.Attributes["id"].Value == "ctl00_MainContent_CldFechaFinal2_Calendario_text")));
              IEnumerable<HtmlNode> enumerable6 = (IEnumerable<HtmlNode>)Enumerable.ToArray<HtmlNode>(Enumerable.Where<HtmlNode>(htmlDocument.DocumentNode.Descendants("select"), (Func<HtmlNode, bool>)(n => n.Attributes["id"] != null && n.Attributes["id"].Value == "ctl00_MainContent_BtnBusqueda")));
              this.ligas = new List<string>();
              if (num1 > -1)
              {
                  foreach (HtmlNode htmlNode1 in enumerable2)
                  {
                      foreach (HtmlNode htmlNode2 in (IEnumerable<HtmlNode>)htmlNode1.ChildNodes)
                      {
                          if (htmlNode2.HasAttributes && htmlNode2.GetAttributeValue("selected", "") != "" && htmlNode2.Attributes["selected"].Value == "selected")
                          {
                              this.MesSel = Convert.ToInt32(htmlNode2.GetAttributeValue("Value", "")).ToString("00") + " " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(htmlNode2.GetAttributeValue("Value", ""))).Substring(0, 3).ToUpper();
                              break;
                          }
                      }
                  }
                  foreach (HtmlNode htmlNode1 in enumerable3)
                  {
                      foreach (HtmlNode htmlNode2 in (IEnumerable<HtmlNode>)htmlNode1.ChildNodes)
                      {
                          if (htmlNode2.HasAttributes && htmlNode2.GetAttributeValue("selected", "") != "" && htmlNode2.Attributes["selected"].Value == "selected")
                          {
                              this.AnoSel = htmlNode2.GetAttributeValue("Value", "");
                              break;
                          }
                      }
                  }
                  this.AnoSel = RFC + (object)Path.DirectorySeparatorChar + "Recibidos" + (object)Path.DirectorySeparatorChar + this.AnoSel;
          
                 // this.AnoSel = "Recibidos" + (object)Path.DirectorySeparatorChar + this.AnoSel;
              }
              else
              {
                  DateTime startDate = DateTime.Today;
                  DateTime endDate = DateTime.Today;
                  foreach (HtmlNode htmlNode in enumerable4)
                  {
                      if (htmlNode.HasAttributes && htmlNode.GetAttributeValue("value", "") != "" && htmlNode.Attributes["value"].Value != "")
                      {
                          startDate = Convert.ToDateTime(htmlNode.GetAttributeValue("value", ""));
                          break;
                      }
                  }
                  foreach (HtmlNode htmlNode in enumerable5)
                  {
                      if (htmlNode.HasAttributes && htmlNode.GetAttributeValue("value", "") != "" && htmlNode.Attributes["value"].Value != "")
                      {
                          endDate = Convert.ToDateTime(htmlNode.GetAttributeValue("value", ""));
                          break;
                      }
                  }
                  int num2 = DateTime.DaysInMonth(startDate.Year, startDate.Month);
                  this.MesSel = startDate.Month.ToString("00") + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(startDate.Month).Substring(0, 3).ToUpper();
                  this.AnoSel = Properties.Settings.Default.RFC + (object)Path.DirectorySeparatorChar + "Emitidos" + Convert.ToString(Path.DirectorySeparatorChar) + Convert.ToString(startDate.Year);
        
        //          this.AnoSel = "Emitidos" + Convert.ToString(Path.DirectorySeparatorChar) + Convert.ToString( startDate.Year);
              }
              foreach (HtmlNode htmlNode in htmlNodeArray)
              {
                  string str = htmlNode.Attributes[6].Value;
                  int num2 = str.IndexOf("AccionCfdi('");
                  int num3 = str.IndexOf("','Recuperacion'");
                  this.ligas.Add("https://portalcfdi.facturaelectronica.sat.gob.mx/RecuperaCfdi.aspx?" + str.Substring(num2 + 12, num3 - num2 - 12).Replace("RecuperaCfdi.aspx?", ""));
              }
              this.Descargados = new List<DownloadItem>();
             
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.tiemporec.Elapsed.Minutes != 50)//5 why?
                return;
            this.tiemporec.Restart();
            this.webView3.EvalScript("\r\n                        var boton = document.getElementById('ctl00_MainContent_BtnBusqueda');\r\n                        boton.click();\r\n                        boton.onclick();");
        }

        private void btnDescarga_Click(object sender, EventArgs e)
        {
          
        }
        private void empiezaConLosEmitidos()
        {
            tmrNoveno.Start();
        }
        private void Descarga()
        {
            this.webView3.Url = this.ligas[this.posicion];
        }
        private void WebView_BeforeDownload(object sender, BeforeDownloadEventArgs e)
        {
          
            e.ShowDialog = false;

            string path = carpeta.Text + (object)Path.DirectorySeparatorChar +this.AnoSel+(object)Path.DirectorySeparatorChar+ this.MesSel + (object)Path.DirectorySeparatorChar+diaActual.ToString();
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string tempPath = Path.GetTempPath();
            e.FilePath = e.FilePath.Replace(tempPath, path + (object)Path.DirectorySeparatorChar);
        
           }

        private void timerHandlerDecimoSeptimo(object sender, EventArgs e)
        {
            tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 17 PROCESS";
            if (cualCheco)
            {
                cualCheco = false;
                String siEncontroResultados = (String)this.webView3.EvalScript("document.getElementById('ctl00_MainContent_PnlNoResultados').style.display");
                try
                {
                    if (siEncontroResultados != null)
                    {
                        if (siEncontroResultados.Equals("inline"))
                        {
                            string html = this.webView3.GetHtml();
                            tiempoHastaTrigger.Text = "NO ENCONTRE CANCELADOS DE LOS EMITIDOS";
                            tmrDecimoSeptimo.Stop();
                            mandaCorreo();
                        }
                    }
                }
                catch (Exception ex1)
                {
                    ex1.ToString();
                }
            }
            else
            {
                cualCheco = true;

                String submit = Convert.ToString(this.webView3.EvalScript("document.getElementById('ContenedorDinamico');"));
                if (submit.Equals("") || submit.Equals("null"))
                {
                    primeraVez = 1;
                }
                else
                {
                    if (primeraVez == 1)
                    {
                        primeraVez = 0;
                        tmrDecimoSeptimo.Interval = Convert.ToInt32(Properties.Settings.Default.timeInterval);
                    }
                    else
                    {
                        primeraVez = 1;
                        tmrDecimoSeptimo.Stop();
                        tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 17 STOP SI ENCONTRE FACTURAS";

                        string html = this.webView3.GetHtml();
                        StringBuilder warnings = new StringBuilder("");
                        totalDeCancelados = 0;
                        while (html.IndexOf("<span style=\"display:inline-block;width:270px;\">") != -1)
                        {
                            int posicionInicial = html.IndexOf("<span style=\"display:inline-block;width:270px;\">");
                            String UUID = html.Substring(posicionInicial + 48, 36);
                            html = html.Substring(posicionInicial + 48 + 36 + 94);
                            //94
                            posicionInicial = html.IndexOf("<");
                            String rfcEmisor = html.Substring(0, posicionInicial);
                            html = html.Substring(posicionInicial + 94);
                            posicionInicial = html.IndexOf("<");
                            String razonSocialEmisor = html.Substring(0, posicionInicial);
                            html = html.Substring(posicionInicial);

                            posicionInicial = html.IndexOf("WORD-BREAK:BREAK-ALL;");
                            html = html.Substring(posicionInicial + 21+50);

                            posicionInicial = html.IndexOf("<");
                            rfcEmisor = html.Substring(0, posicionInicial);
                            html = html.Substring(posicionInicial);

                            posicionInicial = html.IndexOf("WORD-BREAK:BREAK-ALL;");
                            html = html.Substring(posicionInicial + 21 + 50);

                            posicionInicial = html.IndexOf("<");
                            razonSocialEmisor = html.Substring(0, posicionInicial);
                            html = html.Substring(posicionInicial);




                            posicionInicial = html.IndexOf("WORD-BREAK:BREAK-ALL;");
                            html = html.Substring(posicionInicial + 21+50);
                            String fechaExpedicion = html.Substring(0, 10);

                            posicionInicial = html.IndexOf("WORD-BREAK:BREAK-ALL;");
                            html = html.Substring(posicionInicial + 21);
                            posicionInicial = html.IndexOf("WORD-BREAK:BREAK-ALL;");
                            html = html.Substring(posicionInicial + 21);

                            posicionInicial = html.IndexOf("WORD-BREAK:BREAK-ALL;");
                            html = html.Substring(posicionInicial + 21 + 51);

                            posicionInicial = html.IndexOf("<");
                            String cantidad = html.Substring(0, posicionInicial);

                            posicionInicial = html.IndexOf("WORD-BREAK:BREAK-ALL;");
                            html = html.Substring(posicionInicial + 21 + 50);
                            posicionInicial = html.IndexOf("<");
                            String tipoDeComprobante = html.Substring(0, posicionInicial).ToUpper();
                            String statusDeCancelado = "0";//gasto
                            if(tipoDeComprobante.Equals("INGRESO"))
                            {
                                statusDeCancelado = "3";//ingreso
                            }
                          
                            String query1 = "UPDATE [" + Properties.Settings.Default.Database + "].[dbo].[facturacion_XML] set STATUS = '" + statusDeCancelado + "' WHERE folioFiscal = '" + UUID + "'";
                            totalDeCancelados++;
                            try
                            {
                                using (SqlConnection connection = new SqlConnection(connString))
                                {
                                    connection.Open();
                                    SqlCommand cmd = new SqlCommand(query1, connection);
                                    cmd.ExecuteNonQuery();

                                    String queryCheck1 = "SELECT BUNIT, JRNAL_NO, JRNAL_LINE, CONCEPTO, FUNCION, PROJECT, descripcionLI, AMOUNT, Consecutivo, FOLIO_FISCAL FROM [" + Properties.Settings.Default.Database + "].[dbo].[FISCAL_xml] WHERE FOLIO_FISCAL = '" + UUID + "'";
                                    SqlCommand cmdCheck = new SqlCommand(queryCheck1, connection);
                                    SqlDataReader reader = cmdCheck.ExecuteReader();


                                    if (reader.HasRows)
                                    {
                                        String BUNIT = "";
                                        String JRNAL_NO = "";
                                        String JRNAL_LINE = "";
                                        String CONCEPTO = "";
                                        String FUNCION = "";
                                        String PROJECT = "";
                                        String descripcionLI = "";
                                        String AMOUNT = "";
                                        String Consecutivo = "";
                                        String FOLIO_FISCAL = "";
                                        mensajeParaElCorreo.Append(this.Enters + "Los cancelados estan ligados a los siguientes movimientos: ");
                                        while (reader.Read())
                                        {
                                            BUNIT = reader.GetString(0).Trim();
                                            JRNAL_NO = Convert.ToString(reader.GetInt32(1));
                                            JRNAL_LINE = Convert.ToString(reader.GetInt32(2));
                                            CONCEPTO = reader.GetString(3).Trim();
                                            FUNCION = reader.GetString(4).Trim();
                                            PROJECT = reader.GetString(5).Trim();
                                            descripcionLI = reader.GetString(6).Trim();
                                            AMOUNT = Convert.ToString(reader.GetDecimal(7));
                                            Consecutivo = reader.GetString(8).Trim();
                                            FOLIO_FISCAL = reader.GetString(9).Trim();
                                            mensajeParaElCorreo.Append(this.Enters + BUNIT + " " + JRNAL_NO + " " + JRNAL_LINE + " " + CONCEPTO + " " + FUNCION + " " + PROJECT + " " + descripcionLI + " " + AMOUNT + " " + FOLIO_FISCAL + " " + Consecutivo);
                                        }
                                    }
                                    else
                                    {
                                        //inserto el que no eexiste
                                        String query2 = "INSERT INTO [" + Properties.Settings.Default.Database + "].[dbo].[facturacion_XML] (fechaExpedicion, folioFiscal,STATUS,total,rfc,razonSocial, ocultaEnLigar,rfcRaiz) VALUES ('" + fechaExpedicion + "', '" + UUID + "', '" + statusDeCancelado + "', '" + cantidad + "','" + rfcEmisor + "', '" + razonSocialEmisor + "',0,,'" + Properties.Settings.Default.RFC + "')";
                                        String queryCheck2 = "SELECT * FROM [" + Properties.Settings.Default.Database + "].[dbo].[facturacion_XML] WHERE folioFiscal = '" + UUID + "'";
                                        try
                                        {
                                            using (SqlConnection connection2 = new SqlConnection(connString))
                                            {
                                                connection2.Open();
                                                SqlCommand cmdCheck2 = new SqlCommand(queryCheck2, connection2);
                                                SqlDataReader reader2 = cmdCheck2.ExecuteReader();
                                                if (!reader2.Read())
                                                {
                                                    reader2.Close();
                                                    connection2.Close();
                                                    connection2.Open();
                                                    SqlCommand cmd2 = new SqlCommand(query2, connection2);
                                                    cmd2.ExecuteNonQuery();
                                                    warnings.Append(this.Enters + "WARNING: la factura con UUID: " + UUID + ", RFC: " + rfcEmisor + " " + razonSocialEmisor + " ,  por $" + cantidad + " fue cancelada antes de entrar a nuestros registros");
                                                }
                                            }
                                        }
                                        catch (Exception ex1)
                                        {
                                            ex1.ToString();
                                            this.cuantosNoSeInsertaron++;
                                            //  System.Windows.Forms.MessageBox.Show("Error Message", ex1.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                    }
                                }
                            }
                            catch (Exception ex1)
                            {
                                System.Windows.Forms.MessageBox.Show(ex1.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }


                        }
                        mensajeParaElCorreo.Append(" Cancelados: "+totalDeCancelados);
                        mensajeParaElCorreo.Append(warnings);
                        mandaCorreo();
                    }
                }
            }//else main
        }
        private void timerHandlerDecimoSexto(object sender, EventArgs e)
        {
            tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 16 PROCESS";
            String submit = Convert.ToString(this.webView3.EvalScript("document.getElementById('ctl00_MainContent_CldFechaInicial2_Calendario_text');"));
            if (submit.Equals("") || submit.Equals("null"))
            {
                primeraVez = 1;
            }
            else
            {
                if (primeraVez == 1)
                {
                    primeraVez = 0;
                    tmrDecimoSexto.Interval = Convert.ToInt32(Properties.Settings.Default.timeInterval);
                }
                else
                {
                    primeraVez = 1;
                    tmrDecimoSexto.Stop();
                    DateTime now = DateTime.Now;
                    int year = now.Year-anoAnterior;
                 
                    tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 16 STOP";
                    if(modoGlobal==2)//ultrapesado
                    {
                        this.webView3.EvalScript("document.getElementById('ctl00_MainContent_CldFechaInicial2_Calendario_text').value='01/01/" + year + "';");
                        this.webView3.EvalScript("document.getElementById('ctl00_MainContent_CldFechaFinal2_Calendario_text').value='31/12/" + year + "';");
                        this.webView3.EvalScript("document.getElementById('ctl00_MainContent_CldFechaFinal2_DdlHora').value='23';");
                        this.webView3.EvalScript("document.getElementById('ctl00_MainContent_CldFechaFinal2_DdlMinuto').value='59';");
                   
                    }

                    this.webView3.EvalScript("var arrayA = document.getElementsByTagName('a');var i = 0;for (i = 0; i < arrayA.length; i++){if (arrayA[i].innerHTML.valueOf() == new String('Cancelado').valueOf()){arrayA[i].click();break;}}");
                    this.webView3.EvalScript("window.alert = function() {};");


                    this.webView3.EvalScript("document.getElementById('ctl00_MainContent_BtnBusqueda').click();");
                    tmrDecimoSeptimo.Start();
                    tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 17 START";
                }
            }
        }
        private void timerHandlerDecimoQuinto(object sender, EventArgs e)
        {
            tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 15 PROCESS";
            if(cualCheco)
            {
                cualCheco = false;
                String siEncontroResultados = (String)this.webView3.EvalScript("document.getElementById('ctl00_MainContent_PnlNoResultados').style.display");
                try
                {
                    if (siEncontroResultados != null)
                    {
                        if (siEncontroResultados.Equals("inline"))
                        {
                            primeraVez = 1;
                            tmrDecimoQuinto.Stop();
                            tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 15 STOP NO ENCONTRE FACTURAS";
                            estoyEnEmitidos = true;
                            this.cuantosYaExistian = 0;
                            estoyEnCancelados = false;
                            if (entraUnaSolaVezAlAux)
                            {
                                entraUnaSolaVezAlAux = false;
                                auxaux();
                            }
                        }
                    }
                }
                catch (Exception ex1)
                {
                    ex1.ToString();
                }
            }
            else
            {
                cualCheco = true;
                String submit = Convert.ToString(this.webView3.EvalScript("document.getElementById('ListaFoliosUrl');"));
                if (submit.Equals("") || submit.Equals("null"))
                {
                    primeraVez = 1;
                }
                else
                {
                    if (primeraVez == 1)
                    {
                        primeraVez = 0;
                        tmrDecimoQuinto.Interval = Convert.ToInt32(Properties.Settings.Default.timeInterval);
                    }
                    else
                    {
                        primeraVez = 1;
                        tmrDecimoQuinto.Stop();
                        tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 15 STOP SI ENCONTRE FACTURAS";
                        estoyEnEmitidos = true;
                        estoyEnCancelados = false;
                        this.cuantosYaExistian = 0;
                        if (entraUnaSolaVezAlAux)
                        {
                            entraUnaSolaVezAlAux = false;
                            auxaux();
                        }
                       
                    }
                }
            } 
        }
        private void timerHandlerDecimoCuarto(object sender, EventArgs e)
        {
            tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 14 PROCESS";
            String submit = Convert.ToString(this.webView3.EvalScript("document.getElementById('ctl00_MainContent_CldFechaInicial2_Calendario_text');"));
            if (submit.Equals("") || submit.Equals("null"))
            {
                primeraVez = 1;
            }
            else
            {
                if (primeraVez == 1)
                {
                    primeraVez = 0;
                    tmrDecimoCuarto.Interval = Convert.ToInt32(Properties.Settings.Default.timeInterval);
                }
                else
                {
                    primeraVez = 1;
                    tmrDecimoCuarto.Stop();
                    tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 14 STOP";
          
                    DateTime now = DateTime.Now;
                    int year = now.Year-anoAnterior;
                    int month = now.Month;
                    int day = now.Day;
                    String mes = month.ToString();
                    if (month < 10)
                    {
                        mes = "0" + month;
                    }
                    String dia = day.ToString();
                    if (day < 10)
                    {
                        dia = "0" + day;
                    }
                    int diaFinal = 28;
                    if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
                    {
                        diaFinal = 31;
                    }
                    else
                    {
                        if(month == 4 || month == 6 || month == 9 || month == 11)
                        {
                            diaFinal = 30;
                        }
                        else
                        {
                            if(year%4==0)//ano bisiesto
                            {
                                diaFinal = 29;
                            }
                        }
                    }
                    if(modoGlobal==2)//ultra pesado
                    {
                        String mm = Convert.ToString(mesActual+1);
                        if( (mesActual + 1)<10)
                        {
                            mm = "0" + (mesActual + 1);
                        }
                        String dd = diaActual.ToString();
                        if(diaActual<10)
                        {
                            dd = "0" + diaActual;
                        }
                        entraUnaSolaVezAlAux = true;
                        String html = this.webView3.GetHtml();
                        this.webView3.EvalScript("document.getElementById('ctl00_MainContent_CldFechaFinal2_DdlHora').value='23';");
                        this.webView3.EvalScript("document.getElementById('ctl00_MainContent_CldFechaFinal2_DdlMinuto').value='59';");
                    
                        this.webView3.EvalScript("document.getElementById('ctl00_MainContent_CldFechaInicial2_Calendario_text').value='"+dd+"/"+mm+"/" + year + "';");
                        this.webView3.EvalScript("document.getElementById('ctl00_MainContent_CldFechaFinal2_Calendario_text').value='"+dd+"/"+mm+"/" + year + "';");
                    }
                    else
                    {
                        this.webView3.EvalScript("document.getElementById('ctl00_MainContent_CldFechaInicial2_Calendario_text').value='01/" + mes + "/" + year + "';");
                        this.webView3.EvalScript("document.getElementById('ctl00_MainContent_CldFechaFinal2_Calendario_text').value='" + diaFinal.ToString() + "/" + mes + "/" + year + "';");
                    }
                   
                    this.webView3.EvalScript("var arrayA = document.getElementsByTagName('a');var i = 0;for (i = 0; i < arrayA.length; i++){if (arrayA[i].innerHTML.valueOf() == new String('Vigente').valueOf()){arrayA[i].click();break;}}");
                    this.webView3.EvalScript("window.alert = function() {};");
                    this.webView3.EvalScript("document.getElementById('ctl00_MainContent_BtnBusqueda').click();");
                    tmrDecimoQuinto.Start();
                    tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 15 START";
                }
            }
        }
        private void timerHandlerDecimoTercero(object sender, EventArgs e)
        {
            tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 13 PROCESS";
            String submit = Convert.ToString(this.webView3.EvalScript("document.getElementById('ctl00_MainContent_RdoFechas');"));
            if (submit.Equals("") || submit.Equals("null"))
            {
                primeraVez = 1;
            }
            else
            {
                if (primeraVez == 1)
                {
                    primeraVez = 0;
                    tmrDecimoTercero.Interval = Convert.ToInt32(Properties.Settings.Default.timeInterval);
                }
                else
                {
                    primeraVez = 1;
                    tmrDecimoTercero.Stop();
                    tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 13 STOP";
          
                    this.webView3.EvalScript("document.getElementById('ctl00_MainContent_RdoFechas').click();");
                    tmrDecimoCuarto.Start();
                    tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 14 START";
                }
            }
        }

        private void timerHandlerDecimoSegundo(object sender, EventArgs e)
        {
            tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 12 PROCESS";
            String submit = Convert.ToString(this.webView3.EvalScript("document.getElementById('ctl00_MainContent_RdoTipoBusquedaEmisor');"));
            if (submit.Equals("") || submit.Equals("null"))
            {
                primeraVez = 1;
            }
            else
            {
                if (primeraVez == 1)
                {
                    primeraVez = 0;
                    tmrDecimoSegundo.Interval = Convert.ToInt32(Properties.Settings.Default.timeInterval);
                }
                else
                {
                    primeraVez = 1;
                    tmrDecimoSegundo.Stop();
                    tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 12 STOP";
          
                    this.webView3.EvalScript("document.getElementById('ctl00_MainContent_RdoTipoBusquedaEmisor').click();");
                    this.webView3.EvalScript("document.getElementById('ctl00_MainContent_BtnBusqueda').click();");
                    tmrDecimoTercero.Start();
                    tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 13 START";
                }
            }
        }
        private void timerHandlerDecimoPrimero(object sender, EventArgs e)
        {
            tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 11 PROCESS";
            if(cualCheco)
            {
                cualCheco = false;
                String siEncontroResultados = (String)this.webView3.EvalScript("document.getElementById('ctl00_MainContent_PnlNoResultados').style.display");
                try
                {
                    if (siEncontroResultados != null)
                    {
                        if (siEncontroResultados.Equals("inline"))
                        {
                            primeraVez = 1;
                            tmrDecimoPrimero.Stop();
                            tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 11 STOP NO ENCONTRE FACTURAS";
                            auxaux();
                        }
                    }
                }
                catch (Exception ex1)
                {
                    ex1.ToString();
                }
            }
            else
            {
                cualCheco = true;
                String submit = Convert.ToString(this.webView3.EvalScript("document.getElementById('ListaFoliosUrl');"));
                if (submit.Equals("") || submit.Equals("null"))
                {
                    primeraVez = 1;
                }
                else
                {
                    if (primeraVez == 1)
                    {
                        primeraVez = 0;
                        tmrDecimoPrimero.Interval = Convert.ToInt32(Properties.Settings.Default.timeInterval);
                    }
                    else
                    {
                        primeraVez = 1;
                        tmrDecimoPrimero.Stop();
                        tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 11 STOP SI ENCONTRE FACTURAS";
                        auxaux();
                    }
                }
            }
            
        }
        private void timerHandlerDecimo(object sender, EventArgs e)
        {
            tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 10 PROCESS";
            tmrDecimo.Stop();
            tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 10 STOP";
          
            DateTime now = DateTime.Now;
            this.webView3.EvalScript("document.getElementById('ctl00_MainContent_DdlEstadoComprobante').selectedIndex = 2;");
            int mes = now.Month - 2;
            if(mes==-1)
            {
                mes = 11;
                int year = now.Year-2012;
                this.webView3.EvalScript("document.getElementById('DdlAnio').selectedIndex = " + year + ";");                
            }
            this.webView3.EvalScript("window.alert = function() {};");
            this.webView3.EvalScript("document.getElementById('ctl00_MainContent_CldFecha_DdlDia').selectedIndex = " + diaActual.ToString() + ";");
            if (modoGlobal == 2)//ultrapesado
            {
                this.webView3.EvalScript("document.getElementById('ctl00_MainContent_CldFecha_DdlMes').selectedIndex = " + mesActual.ToString() + ";");
            }
            else
            {
                this.webView3.EvalScript("document.getElementById('ctl00_MainContent_CldFecha_DdlMes').selectedIndex = " + mes.ToString() + ";");
            }
            
            this.webView3.EvalScript("document.getElementById('ctl00_MainContent_BtnBusqueda').click();");
//            tmrSexto.Start();


            tmrDecimoPrimero.Start();
            tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 10 START";
        }
        public void vuelveAEmpezar()
        {
            tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO";
            this.webView3.Url = "https://portalcfdi.facturaelectronica.sat.gob.mx/";
            this.proceso.Text = "Cargando https://portalcfdi.facturaelectronica.sat.gob.mx/";
            tmrSegundo.Stop();
            tmrTercero.Stop();
            tmrCuarto.Stop();
            tmrQuinto.Stop();
            tmrSexto.Stop();
            tmrSeptimo.Stop();
            tmrOctavo.Stop();
            tmrNoveno.Stop();
            tmrPrimero.Start();
        }
        private void timerHandlerNoveno(object sender, EventArgs e)
        {
            if(soloUnaVezNoveno)
            {
                soloUnaVezNoveno = false;
                tmrNoveno.Stop();
                tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 9 PROCESS";
                //String submit = Convert.ToString(this.webView3.EvalScript("document.getElementsByTagName('a')[2].innerHTML;"));
              //       this.webView3.EvalScript("window.location='Consulta.aspx';");
                this.webView3.Url = "https://portalcfdi.facturaelectronica.sat.gob.mx/ConsultaEmisor.aspx";
          
           
             //   this.webView3.EvalScript("document.getElementsByTagName('a')[2].click();");
                //this.webView3.EvalScript(" var arrayA = document.getElementsByTagName('a');var i = 0;for (i = 0; i < arrayA.length; i++){if (arrayA[i].getAttribute(\"href\").localeCompare(\"Consulta.aspx\")){arrayA[i].click();}}");
                tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 9 STOP";
                //tmrDecimoSegundo.Start();
                tmrDecimoTercero.Start();
                tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 13 START";
            }
           
            /*
            DateTime startTime = DateTime.Now;
            TimeSpan span = tomorrow.Subtract(startTime);
            tiempoHastaTrigger.Text = "Tiempo hasta iniciar el proceso otra vez: " + span.Hours + ":" + span.Minutes + ":" + span.Seconds;
            if(span.Hours==0 && span.Minutes==0)
            {
                tmrNoveno.Stop();
                vuelveAEmpezar();
            }*/
        }
        private void timerHandlerOctavo(object sender, EventArgs e)
        {
            tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 8 PROCESS";
            if (cualCheco)
            {
                cualCheco = false;
                String siEncontroResultados = (String)this.webView3.EvalScript("document.getElementById('ctl00_MainContent_PnlNoResultados').style.display");
                try
                {
                    if (siEncontroResultados != null)
                    {
                        if (siEncontroResultados.Equals("inline"))
                        {
                            tiempoHastaTrigger.Text = "NO ENCONTRE CANCELADOS DE LOS RECIBIDOS";
         

                        }
                    }
                }
                catch (Exception ex1)
                {
                    ex1.ToString();
                }
            }
            else
            {
                cualCheco = true;

                String submit = Convert.ToString(this.webView3.EvalScript("document.getElementById('ContenedorDinamico');"));
                if (submit.Equals("") || submit.Equals("null"))
                {
                    primeraVez = 1;
                }
                else
                {
                    if (primeraVez == 1)
                    {
                        primeraVez = 0;
                        tmrOctavo.Interval = Convert.ToInt32(Properties.Settings.Default.timeInterval);
                    }
                    else
                    {
                        primeraVez = 1;
                        tmrOctavo.Stop();
                        tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 8 STOP";

                        string html = this.webView3.GetHtml();
                        StringBuilder warnings = new StringBuilder("");
                        while (html.IndexOf("<span style=\"display:inline-block;width:270px;\">") != -1)
                        {
                            int posicionInicial = html.IndexOf("<span style=\"display:inline-block;width:270px;\">");
                            String UUID = html.Substring(posicionInicial + 48, 36);
                            html = html.Substring(posicionInicial + 48 + 36 + 94);
                            //94
                            posicionInicial = html.IndexOf("<");
                            String rfcEmisor = html.Substring(0, posicionInicial);
                            html = html.Substring(posicionInicial +  94);
                            posicionInicial = html.IndexOf("<");
                            String razonSocialEmisor = html.Substring(0, posicionInicial);
                             html = html.Substring(posicionInicial);
                            
                            posicionInicial = html.IndexOf("WORD-BREAK:BREAK-ALL;");
                            html = html.Substring(posicionInicial + 21);
                            posicionInicial = html.IndexOf("WORD-BREAK:BREAK-ALL;");
                            html = html.Substring(posicionInicial + 21);
                            posicionInicial = html.IndexOf("WORD-BREAK:BREAK-ALL;");
                            html = html.Substring(posicionInicial + 21);
                            posicionInicial = html.IndexOf("WORD-BREAK:BREAK-ALL;");
                            html = html.Substring(posicionInicial + 21+50);

                            posicionInicial = html.IndexOf("<");
                            String fechaExpedicion = html.Substring(0, posicionInicial);


                            posicionInicial = html.IndexOf("WORD-BREAK:BREAK-ALL;");
                            html = html.Substring(posicionInicial + 21);
                            posicionInicial = html.IndexOf("WORD-BREAK:BREAK-ALL;");
                            html = html.Substring(posicionInicial + 21 + 51);

                            posicionInicial = html.IndexOf("<");
                            String cantidad = html.Substring(0, posicionInicial);

                            posicionInicial = html.IndexOf("WORD-BREAK:BREAK-ALL;");
                            html = html.Substring(posicionInicial + 21+50);
                            posicionInicial = html.IndexOf("<");

                            String tipoDeComprobante = html.Substring(0, posicionInicial).ToUpper();
                            String statusDeCancelado = "3";//ingreso
                            if(tipoDeComprobante.Equals("INGRESO"))
                            {
                                statusDeCancelado = "0";//gasto
                            }

                            posicionInicial = html.IndexOf("WORD-BREAK:BREAK-ALL;");
                            html = html.Substring(posicionInicial + 21);
                            posicionInicial = html.IndexOf("WORD-BREAK:BREAK-ALL;");
                            html = html.Substring(posicionInicial + 21 + 50);
                            posicionInicial = html.IndexOf("<");
                            String fechaCancelacion = html.Substring(0, posicionInicial);

                            String query1 = "";
                            query1 = "UPDATE [" + Properties.Settings.Default.Database + "].[dbo].[facturacion_XML] set STATUS = '" + statusDeCancelado + "', fechaCancelacion = '" + fechaCancelacion + "' WHERE folioFiscal = '" + UUID + "'";
                            totalDeCancelados++;
                            try
                            {
                                using (SqlConnection connection = new SqlConnection(connString))
                                {
                                    connection.Open();
                                    SqlCommand cmd = new SqlCommand(query1, connection);
                                    cmd.ExecuteNonQuery();

                                    String queryCheck1 = "SELECT BUNIT, JRNAL_NO, JRNAL_LINE, CONCEPTO, FUNCION, PROJECT, descripcionLI, AMOUNT, Consecutivo, FOLIO_FISCAL FROM [" + Properties.Settings.Default.Database + "].[dbo].[FISCAL_xml] WHERE FOLIO_FISCAL = '" + UUID + "'";
                                    SqlCommand cmdCheck = new SqlCommand(queryCheck1, connection);
                                    SqlDataReader reader = cmdCheck.ExecuteReader();


                                    if (reader.HasRows)
                                    {
                                        String BUNIT = "";
                                        String JRNAL_NO = "";
                                        String JRNAL_LINE = "";
                                        String CONCEPTO = "";
                                        String FUNCION = "";
                                        String PROJECT = "";
                                        String descripcionLI = "";
                                        String AMOUNT = "";
                                        String Consecutivo = "";
                                        String FOLIO_FISCAL = "";
                                        mensajeParaElCorreo.Append(this.Enters + "Los cancelados estan ligados a los siguientes movimientos: ");
                                        while (reader.Read())
                                        {
                                            BUNIT = reader.GetString(0).Trim();
                                            JRNAL_NO = Convert.ToString(reader.GetInt32(1));
                                            JRNAL_LINE = Convert.ToString(reader.GetInt32(2));
                                            CONCEPTO = reader.GetString(3).Trim();
                                            FUNCION = reader.GetString(4).Trim();
                                            PROJECT = reader.GetString(5).Trim();
                                            descripcionLI = reader.GetString(6).Trim();
                                            AMOUNT = Convert.ToString(reader.GetDecimal(7));
                                            Consecutivo = reader.GetString(8).Trim();
                                            FOLIO_FISCAL = reader.GetString(9).Trim();
                                            mensajeParaElCorreo.Append(this.Enters + BUNIT + " " + JRNAL_NO + " " + JRNAL_LINE + " " + CONCEPTO + " " + FUNCION + " " + PROJECT + " " + descripcionLI + " " + AMOUNT + " " + FOLIO_FISCAL + " " + Consecutivo);
                                        }
                                    }
                                    else
                                    {
                                        //inserto el que no eexiste
                                        String query2 = "INSERT INTO [" + Properties.Settings.Default.Database + "].[dbo].[facturacion_XML] (folioFiscal,STATUS,fechaCancelacion,total,fechaExpedicion,rfc,razonSocial, ocultaEnLigar,rfcRaiz) VALUES ('" + UUID + "', '" + statusDeCancelado + "', '" + fechaCancelacion + "', '" + cantidad + "', '" + fechaExpedicion + "','" + rfcEmisor + "', '" + razonSocialEmisor + "',0,'" + Properties.Settings.Default.RFC + "')";
                                        String queryCheck2 = "SELECT * FROM [" + Properties.Settings.Default.Database + "].[dbo].[facturacion_XML] WHERE folioFiscal = '" + UUID + "'";
                                        try
                                        {
                                            using (SqlConnection connection2 = new SqlConnection(connString))
                                            {
                                                connection2.Open();
                                                SqlCommand cmdCheck2 = new SqlCommand(queryCheck2, connection2);
                                                SqlDataReader reader2 = cmdCheck2.ExecuteReader();
                                                if (!reader2.Read())
                                                {
                                                    reader2.Close();
                                                    connection2.Close();
                                                    connection2.Open();
                                                    SqlCommand cmd2 = new SqlCommand(query2, connection2);
                                                    cmd2.ExecuteNonQuery();
                                                    warnings.Append(this.Enters + "WARNING: la factura con UUID: " + UUID + ", RFC: "+rfcEmisor+" "+razonSocialEmisor+" , Fecha: "+fechaExpedicion+",  por $"+cantidad+" fue cancelada antes de entrar a nuestros registros");
                                                }
                                            }
                                        }
                                        catch (Exception ex1)
                                        {
                                            ex1.ToString();
                                            this.cuantosNoSeInsertaron++;
                                            //  System.Windows.Forms.MessageBox.Show("Error Message", ex1.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                    }
                                }
                            }
                            catch (Exception ex1)
                            {
                                System.Windows.Forms.MessageBox.Show(ex1.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                           

                        }
                        mensajeParaElCorreo.Append(warnings);
                        if(modoGlobal==2)//ultra pesado
                        {
                            if(mesActual<11)
                            {
                                mesActual++;
                                tmrSeptimo.Start();
                                tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 7 START";
                            }
                            else
                            {
                                mensajeParaElCorreo.Append(totalDeCancelados);
                                diaActual = 1;
                                mesActual = 0;
                                empiezaConLosEmitidos();
                            }
                        }
                        else
                        {
                            if (primeroElMesAnterior)
                            {
                                primeroElMesAnterior = false;
                                tmrSeptimo.Start();
                                tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 7 START";
                            }
                            else
                            {
                                mensajeParaElCorreo.Append(totalDeCancelados);
                                empiezaConLosEmitidos();
                            }
                        }
                    }
                }
            }//else main
        }
        private void timerHandlerSeptimo(object sender, EventArgs e)
        {
            tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 7 PROCESS";
            tmrSeptimo.Stop();
            tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 7 STOP";
          
            this.webView3.EvalScript("document.getElementById('ctl00_MainContent_DdlEstadoComprobante').selectedIndex = 1;");
            if(modoGlobal==2)//ultrapesado
            {
                this.webView3.EvalScript("document.getElementById('ctl00_MainContent_CldFecha_DdlMes').selectedIndex = " + mesActual.ToString() + ";");
            }
            else
            {
                if (primeroElMesAnterior)
                {
                    DateTime now = DateTime.Now;
                    int mes = now.Month - 2;
                    if (mes == -1)
                    {
                        mes = 11;
                        int year = now.Year - 2012;
                        this.webView3.EvalScript("document.getElementById('DdlAnio').selectedIndex = " + year + ";");
                    }
                    this.webView3.EvalScript("document.getElementById('ctl00_MainContent_CldFecha_DdlMes').selectedIndex = " + mes.ToString() + ";");
                }
                else
                {
                    DateTime now = DateTime.Now;
                    int mes = now.Month - 1;
                    this.webView3.EvalScript("document.getElementById('ctl00_MainContent_CldFecha_DdlMes').selectedIndex = " + mes.ToString() + ";");
                }
            }
           
            this.webView3.EvalScript("window.alert = function() {};");
            this.webView3.EvalScript("document.getElementById('ctl00_MainContent_CldFecha_DdlDia').selectedIndex = 0;");
            this.webView3.EvalScript("document.getElementById('ctl00_MainContent_BtnBusqueda').click();");
             tmrOctavo.Start();
             tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 8 START";    
        }
        private void timerHandlerSexto(object sender, EventArgs e)
        {
            tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 6 PROCESS";
            if(cualCheco)
            {
                cualCheco = false;
                 String siEncontroResultados =(String) this.webView3.EvalScript("document.getElementById('ctl00_MainContent_PnlNoResultados').style.display");
                 try
                 {
                     if (siEncontroResultados != null)
                     {
                         if (siEncontroResultados.Equals("inline"))
                         {
                             primeraVez = 1;
                             tmrSexto.Stop();
                             tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 6 STOP NO ENCONTRE FACTURAS";
                             auxaux();
                         }
                     }
                 }
                catch(Exception ex1)
                 {
                     ex1.ToString();
                 }
            }
            else
            {
                cualCheco = true;
                String submit = Convert.ToString(this.webView3.EvalScript("document.getElementById('ListaFoliosUrl');"));
                if (submit.Equals("") || submit.Equals("null"))
                {
                    primeraVez = 1;
                }
                else
                {
                    if (primeraVez == 1)
                    {
                        primeraVez = 0;
                        tmrSexto.Interval = Convert.ToInt32(Properties.Settings.Default.timeInterval);
                    }
                    else
                    {
                        primeraVez = 1;
                        tmrSexto.Stop();
                        tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 6 STOP SI ENCONTRE FACTURAS";
                        auxaux();
                    }
                }
            }
           
        }
        private void timerHandlerQuinto(object sender, EventArgs e)
        {
            tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 5 PROCESS";
            String submit = Convert.ToString(this.webView3.EvalScript("document.getElementById('ctl00_MainContent_DdlEstadoComprobante');") );
            if (submit.Equals("") || submit.Equals("null"))
            {
                primeraVez = 1;
            }
            else
            {
                if (primeraVez == 1)
                {
                    primeraVez = 0;
                    tmrQuinto.Interval = Convert.ToInt32(Properties.Settings.Default.timeInterval);
                }
                else
                {
                    primeraVez = 1;
                    tmrQuinto.Stop();
                    tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 5 STOP";
                    DateTime now = DateTime.Now;
                    this.webView3.EvalScript("window.alert = function() {};");
                    this.webView3.EvalScript("document.getElementById('ctl00_MainContent_DdlEstadoComprobante').selectedIndex = 2;");
                    int mes = now.Month-1;
                    if(modoGlobal==2)//ultra pesado
                    {
                        this.webView3.EvalScript("document.getElementById('ctl00_MainContent_CldFecha_DdlDia').selectedIndex = " + diaActual.ToString() + ";");
                        this.webView3.EvalScript("document.getElementById('ctl00_MainContent_CldFecha_DdlMes').selectedIndex = "+mesActual.ToString()+";");
                        if(anoAnterior>0)//ano anterior
                        {
                            int year = now.Year - 2012;
                            this.webView3.EvalScript("document.getElementById('DdlAnio').selectedIndex = " + year + ";");
                        }
                    }
                    else
                    {
                        this.webView3.EvalScript("document.getElementById('ctl00_MainContent_CldFecha_DdlDia').selectedIndex = " + diaActual.ToString() + ";");
                        this.webView3.EvalScript("document.getElementById('ctl00_MainContent_CldFecha_DdlMes').selectedIndex = " + mes.ToString() + ";");
                    }
                    
                    this.webView3.EvalScript("document.getElementById('ctl00_MainContent_BtnBusqueda').click();");
                    cualCheco = false;
                    tmrSexto.Start();
                    tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 6 START";
                }
            }
        }

        private void timerHandlerCuarto(object sender, EventArgs e)
        {
            tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 4 PROCESS";
            String submit = Convert.ToString(this.webView3.EvalScript("document.getElementById('ctl00_MainContent_RdoFechas');") );
            if (submit.Equals("") || submit.Equals("null"))
            {
                primeraVez = 1;
            }
            else
            {
                if (primeraVez == 1)
                {
                    primeraVez = 0;
                    tmrCuarto.Interval = Convert.ToInt32(Properties.Settings.Default.timeInterval);
                }
                else
                {
                    primeraVez = 1;
                    tmrCuarto.Stop();
                    tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 4 STOP";
                    this.webView3.EvalScript("document.getElementById('ctl00_MainContent_RdoFechas').click();");
                    tmrQuinto.Start();
                    tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 5 START";
                }
            }
        }

        private void timerHandlerTercero(object sender, EventArgs e)
        {
            tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 3 PROCESS";
            String submit = Convert.ToString(this.webView3.EvalScript("document.getElementById('ctl00_MainContent_RdoTipoBusquedaReceptor');") );
            if (submit.Equals("") || submit.Equals("null"))
            {
                primeraVez = 1;
            }
            else
            {
                if (primeraVez == 1)
                {
                    primeraVez = 0;
                    tmrTercero.Interval = Convert.ToInt32(Properties.Settings.Default.timeInterval);
                }
                else
                {
                    primeraVez = 1;
                    tmrTercero.Stop();
                    tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 3 STOP";
                    
                    this.webView3.EvalScript("document.getElementById('ctl00_MainContent_RdoTipoBusquedaReceptor').click();");
                    this.webView3.EvalScript("document.getElementById('ctl00_MainContent_BtnBusqueda').click();");
                    tmrCuarto.Start();
                    tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 4 START";
                    //agregar para debuguear mitidos
                }
            }
        }

        private void timerHandlerSegundo(object sender, EventArgs e)
        {
            tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 2 PROCESS";
         //   String submit = Convert.ToString(this.webView3.EvalScript("document.getElementsByName('Ecom_User_ID')[0];") );
            String submit = Convert.ToString(this.webView3.EvalScript("document.getElementsByName('Ecom_User_ID').length;")).Trim();

            if (submit.Equals("") || submit.Equals("null"))
            {
                primeraVez = 1;
            }
            else
            {
               
                if (primeraVez == 1 && submit.Equals("1"))
                {
                    primeraVez = 0;
                    tmrSegundo.Interval = Convert.ToInt32(Properties.Settings.Default.timeInterval);
                }
                else
                {
                    if(submit.Equals("0"))
                    {
                        primeraVez = 0;
                        tmrSegundo.Interval = Convert.ToInt32(Properties.Settings.Default.timeInterval);
                    }
                    else
                    {
                        if (Properties.Settings.Default.RFC.Trim().Equals(""))
                        {
                            tiempoHastaTrigger.Text = "PRIMERO LLENA LAS VARIABLES";
                        }
                        else
                        {
                            primeraVez = 1;
                            tmrSegundo.Stop();
                            tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 2 STOP";
                            this.webView3.EvalScript("document.getElementsByName('Ecom_User_ID')[0].value='" + Properties.Settings.Default.RFC + "';");
                            this.webView3.EvalScript("document.getElementsByName('Ecom_Password')[0].value='" + Properties.Settings.Default.pass + "';");
                            this.webView3.EvalScript("document.getElementById('submit').click();");
                            tmrTercero.Start();
                            tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 3 START";
                        }
                    }
                }
            }
        }
        public void mandaCorreo()
        {
            tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO MANDANDO CORREO";
            try
            {
                MailMessage mail2 = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail2.From = new MailAddress(Properties.Settings.Default.correoEmisor);
                mail2.To.Add(Properties.Settings.Default.correoReceptor);
                DateTime now = DateTime.Now;
                int year = now.Year-anoAnterior;
                int month = now.Month;
                int day = now.Day;
                String mes = month.ToString();
                if (month < 10)
                {
                    mes = "0" + month;
                }
                String dia = day.ToString();
                if (day < 10)
                {
                    dia = "0" + day;
                }
                mail2.Subject = "Reporte de facturas del dia: " + dia + "/" + mes + "/" + year;
                mail2.Body = mensajeParaElCorreo.ToString();
        
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(Properties.Settings.Default.correoEmisor, Properties.Settings.Default.passEmisor );
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail2);

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                // Console app
                System.Environment.Exit(1);
            }
            
           
           

        }

        private void timerHandlerPrimero(object sender, EventArgs e)
        {
            tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 1 PROCESS";
            primeroElMesAnterior = true;
            if(modoGlobal==1)
            {
                mensajeParaElCorreo = new StringBuilder(this.Enters + "Todo bien amigo");         
                DateTime now = DateTime.Now;
                diaActual = now.Day;
            }
            else
            {
                diaActual = 1;
                if(modoGlobal==2)//ultra pesado
                {
                    mesActual = 0;//enero
                }
            }
            soloUnaVezNoveno = true;
            estoyEnEmitidos = false;
            estoyEnElMesAnterior = false;
            estoyEnCancelados = false;
            totalDeCancelados = 0;
            totalDeDescargados = 0;
            entraUnaSolaVezAlAux = true;
            totalDeYaExistian = 0;
            String html = this.webView3.GetHtml();
            String submit = Convert.ToString(this.webView3.EvalScript("document.getElementById('submit');") );
            if(submit.Equals("") || submit.Equals("null"))
            {
                primeraVez = 1;
            }
            else
            {
                if(primeraVez==1)
                {
                    primeraVez = 0;
                    tmrPrimero.Interval = Convert.ToInt32(Properties.Settings.Default.timeInterval);     
                }
                else
                {
                    primeraVez = 1;
                    tmrPrimero.Stop();
                    tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 1 STOP";
                    this.webView3.EvalScript("var aux = document.getElementsByTagName('a')[1].click();");
                    this.webView3.EvalScript("aux.click();");
                    tmrSegundo.Start();
                    tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 2 START";
                }
            }
        }
        private void insertaProveedor(String rfcProveedor, String razonSocialProveedor)
        {
            String query2 = "INSERT INTO [" + Properties.Settings.Default.Database + "].[dbo].[proveedor] (rfc,razonSocial) VALUES ('" + rfcProveedor + "', '" + razonSocialProveedor + "')";
            String queryCheck2 = "SELECT * FROM [" + Properties.Settings.Default.Database + "].[dbo].[proveedor] WHERE rfc = '" + rfcProveedor + "'";
            try
            {
                using (SqlConnection connection2 = new SqlConnection(connString))
                {
                    connection2.Open();
                    SqlCommand cmdCheck2 = new SqlCommand(queryCheck2, connection2);
                    SqlDataReader reader2 = cmdCheck2.ExecuteReader();
                    if (!reader2.Read())
                    {
                        reader2.Close();
                        connection2.Close();
                        connection2.Open();
                        SqlCommand cmd2 = new SqlCommand(query2, connection2);
                        cmd2.ExecuteNonQuery();
                     }
                }
            }
            catch (Exception ex1)
            {
                ex1.ToString();
            }
        }
        private void timerHandlerSegundosDeVida(object sender, EventArgs e)
        {
            mensajeParaElCorreo.Append(" NO ESTUVO BIEN, REPITO, NO ESTUVO BIEN, FAVOR DE CONTACTAR AL ADMINISTRADOR!");
            mandaCorreo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            modoGlobal = 2;//borrar
            Timer tmrSegundosDeVida = new Timer();
            if(modoGlobal==1)
            {
                modoLabel.Text = "Modo: Ligero (solo facturas de hoy)";
                tmrSegundosDeVida.Interval = 3300000;//55 minutos
       
            }
            else
            {
                if(modoGlobal==2)
                {
                    modoLabel.Text = "Modo: Ultra Pesado (Facturas de todo el año)";
                    tmrSegundosDeVida.Interval = 86400000;//24 horas
                }
                else
                {
                   

                        modoLabel.Text = "Modo: Pesado (Facturas de todo el mes, y un poco del anterior)";
                        tmrSegundosDeVida.Interval = 21600000;//6 horas
                    

                }
            }
            tmrSegundosDeVida.Tick += timerHandlerSegundosDeVida;
            tmrSegundosDeVida.Start();
          
             this.webView3.BeforeDownload += new BeforeDownloadHandler(this.WebView_BeforeDownload);
             this.webView3.LoadCompleted += new NavigationTaskEventHandler(this.WebView_LoadCompleted);
             this.webView3.DownloadCompleted += new DownloadEventHandler(this.WebView_DownloadCompleted);
           //  this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
             //this.webControl1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
           
             carpeta.Text = Properties.Settings.Default.sunRuta;
            this.webView3.Url = "https://portalcfdi.facturaelectronica.sat.gob.mx/";
            tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO";
            this.proceso.Text = "Cargando https://portalcfdi.facturaelectronica.sat.gob.mx/";
            this.Enters = "\n";
            tmrPrimero = new Timer();
            tmrPrimero.Interval = 1000;
            tmrPrimero.Tick += timerHandlerPrimero;
            tmrPrimero.Start();
            tiempoHastaTrigger.Text = "EN PROCESO AUTOMATICO 1 START";
                  

            tmrSegundo = new Timer();
            tmrSegundo.Interval = 1000;
            tmrSegundo.Tick += timerHandlerSegundo;

            tmrTercero = new Timer();
            tmrTercero.Interval = 1000;
            tmrTercero.Tick += timerHandlerTercero;

            tmrCuarto = new Timer();
            tmrCuarto.Interval = 1000;
            tmrCuarto.Tick += timerHandlerCuarto;

            tmrQuinto = new Timer();
            tmrQuinto.Interval = 1000;
            tmrQuinto.Tick += timerHandlerQuinto;

            tmrSexto = new Timer();
            tmrSexto.Interval = 1000;
            tmrSexto.Tick += timerHandlerSexto;

            tmrSeptimo = new Timer();
            tmrSeptimo.Interval = 1000;
            tmrSeptimo.Tick += timerHandlerSeptimo;

            tmrOctavo = new Timer();
            tmrOctavo.Interval = 1000;
            tmrOctavo.Tick += timerHandlerOctavo;

            tmrNoveno = new Timer();
            tmrNoveno.Interval = 10000;
            tmrNoveno.Tick += timerHandlerNoveno;

            tmrDecimo = new Timer();
            tmrDecimo.Interval = 1000;
            tmrDecimo.Tick += timerHandlerDecimo;

            tmrDecimoPrimero = new Timer();
            tmrDecimoPrimero.Interval = 1000;
            tmrDecimoPrimero.Tick += timerHandlerDecimoPrimero;

            tmrDecimoSegundo = new Timer();
            tmrDecimoSegundo.Interval = 1000;
            tmrDecimoSegundo.Tick += timerHandlerDecimoSegundo;

            tmrDecimoTercero = new Timer();
            tmrDecimoTercero.Interval = 1000;
            tmrDecimoTercero.Tick += timerHandlerDecimoTercero;

            tmrDecimoCuarto = new Timer();
            tmrDecimoCuarto.Interval = 1000;
            tmrDecimoCuarto.Tick += timerHandlerDecimoCuarto;

            tmrDecimoQuinto = new Timer();
            tmrDecimoQuinto.Interval = 1000;
            tmrDecimoQuinto.Tick += timerHandlerDecimoQuinto;

            tmrDecimoSexto = new Timer();
            tmrDecimoSexto.Interval = 1000;
            tmrDecimoSexto.Tick += timerHandlerDecimoSexto;

            tmrDecimoSeptimo = new Timer();
            tmrDecimoSeptimo.Interval = 1000;
            tmrDecimoSeptimo.Tick += timerHandlerDecimoSeptimo;
           
        }

        private void WebView_DownloadCompleted(object sender, DownloadEventArgs e)
        {
            try
            {
                if (this.Cancelar)
                {
                    this.Cursor = System.Windows.Forms.Cursors.Arrow;
                    this.webControl1.Cursor = System.Windows.Forms.Cursors.Arrow;
                //    Mensaje.MostrarMensaje(Constantes.TipoMensaje.Detenido, "Descarga", "Proceso cancelado por el usuario");
                }
                else
                {
                    DownloadItem archivoXML = e.Item;
                    
                    String full = archivoXML.FullPath;
                   
                    String []fullArray  = full.Split('\\');
                    String nombreDelArchivo = fullArray.Last();
                    
                    XmlDocument doc = new XmlDocument();
                    doc.Load(full);
                    XmlNodeList titles = doc.GetElementsByTagName("tfd:TimbreFiscalDigital");
                    XmlNode obj = titles.Item(0);

                    String noCertificadoSAT = "";
                    bool isNoCertificado = obj.Attributes["noCertificadoSAT"] != null;
                    if (isNoCertificado)
                    {
                        noCertificadoSAT = obj.Attributes["noCertificadoSAT"].InnerText;
                    }

                    String selloCFD = "";
                    bool isselloCFD = obj.Attributes["selloCFD"] != null;
                    if (isselloCFD)
                    {
                        selloCFD = obj.Attributes["selloCFD"].InnerText;
                    }

                    String selloSAT = "";
                    bool isselloSAT = obj.Attributes["selloSAT"] != null;
                    if (isselloSAT)
                    {
                        selloSAT = obj.Attributes["selloSAT"].InnerText;
                    }





                    String folio_fiscal = obj.Attributes["UUID"].InnerText;
                    folio_fiscal = folio_fiscal.ToUpper();
                   
                    XmlNodeList titlesx = doc.GetElementsByTagName("cfdi:Receptor");
                    if(titlesx.Count==0)
                    {
                        titlesx = doc.GetElementsByTagName("Receptor");
                    }

                    XmlNode objx = titlesx.Item(0);
                    String rfcReceptor = "";
                    String nombreReceptor = "";
                    bool isRFCrfcReceptor = objx.Attributes["rfc"] != null;
                    if (isRFCrfcReceptor)
                    {
                        rfcReceptor = objx.Attributes["rfc"].InnerText;
                    }
                    bool isRFCNombreReceptor = objx.Attributes["nombre"] != null;
                    if (isRFCNombreReceptor)
                    {
                        nombreReceptor = objx.Attributes["nombre"].InnerText;
                    }

                    XmlNodeList titles1 = doc.GetElementsByTagName("cfdi:Emisor");
                    if (titles1.Count == 0)
                    {
                        titles1 = doc.GetElementsByTagName("Emisor");
                    }

                    XmlNode obj1 = titles1.Item(0);
                    String rfc = "";
                    bool isRFC = obj1.Attributes["rfc"] != null;
                    if (isRFC)
                    {
                        rfc = obj1.Attributes["rfc"].InnerText;
                    }
                    

                    String razon = "";
                    bool isRazon = obj1.Attributes["nombre"] != null;
                    if(isRazon)
                    {
                        razon = obj1.Attributes["nombre"].InnerText;
                    }
                  
                    XmlNodeList titles2 = doc.GetElementsByTagName("cfdi:Comprobante");
                    if (titles2.Count == 0)
                    {
                        titles2 = doc.GetElementsByTagName("Comprobante");
                    }


                    XmlNode obj2 = titles2.Item(0);

                    XmlNodeList titlesY = doc.GetElementsByTagName("cfdi:DomicilioFiscal");
                    if (titlesY.Count == 0)
                    {
                        titlesY = doc.GetElementsByTagName("DomicilioFiscal");
                    }
                    String calle = "";
                    String noExterior = "";
                    String colonia = "";
                    String municipio = "";
                    String estado = "";
                         
                    if(titlesY.Count>0)
                    {
                        XmlNode objY = titlesY.Item(0);
                        bool isCalle = objY.Attributes["calle"] != null;
                        if (isCalle)
                        {
                            calle = objY.Attributes["calle"].InnerText;
                        }

                         bool isnoExterior = objY.Attributes["noExterior"] != null;
                        if (isnoExterior)
                        {
                            noExterior = objY.Attributes["noExterior"].InnerText;
                        }

                         bool iscolonia = objY.Attributes["colonia"] != null;
                        if (iscolonia)
                        {
                            colonia = objY.Attributes["colonia"].InnerText;
                        }

                        bool ismunicipio = objY.Attributes["municipio"] != null;
                        if (ismunicipio)
                        {
                            municipio = objY.Attributes["municipio"].InnerText;
                        }

                        bool isestado = objY.Attributes["estado"] != null;
                        if (isestado)
                        {
                            estado = objY.Attributes["estado"].InnerText;
                        }
                    }

                   
                    

                    XmlNodeList titles4 = doc.GetElementsByTagName("cfdi:Impuestos");
                    if (titles4.Count == 0)
                    {
                        titles4 = doc.GetElementsByTagName("Impuestos");
                    }


                    XmlNode obj4 = titles4.Item(0);
                  
                    String iva = "0";
                    bool isIva = obj4.Attributes["totalImpuestosTrasladados"] != null;
                    if(isIva)
                    {
                        iva = obj4.Attributes["totalImpuestosTrasladados"].InnerText;
                    }
                    else
                    {
                        XmlNodeList traslados = doc.GetElementsByTagName("cfdi:Traslado");
                        if (traslados.Count == 0)
                        {
                            traslados = doc.GetElementsByTagName("Traslado");
                        }
                        int i;
                        for(i=0;i<traslados.Count;i++)
                        {
                            XmlNode objn = traslados.Item(i);
                            String cantidad = "0";
                            bool isCantidad = objn.Attributes["importe"] != null;
                            if(isCantidad)
                            {     
                                 cantidad=objn.Attributes["importe"].InnerText;                     
                            }
                            iva = Convert.ToString( float.Parse(iva) + float.Parse(cantidad));
                        }
                    }

                   

                    String subTotal = "";
                    bool isSubTotal = obj2.Attributes["subTotal"] != null;
                    if (isSubTotal)
                    {
                        subTotal = obj2.Attributes["subTotal"].InnerText;
                    }

                    String tipoDeComprobante = "INGRESO";
                     bool istipoDeComprobante = obj2.Attributes["tipoDeComprobante"] != null;
                    if (istipoDeComprobante)
                    {
                        tipoDeComprobante = obj2.Attributes["tipoDeComprobante"].InnerText.Trim().ToUpper();
                    }
                   
                   


                    String total = "";
                    bool isTotal = obj2.Attributes["total"] != null;
                    if(isTotal)
                    {
                        total = obj2.Attributes["total"].InnerText;
                    }

                    bool isFecha = obj2.Attributes["fecha"] != null;
                    String fecha = "";
                    if(isFecha)
                    {
                        fecha = obj2.Attributes["fecha"].InnerText;
                    }
                    bool isFolio = obj2.Attributes["folio"] != null;
                    String folio = "";
                    if(isFolio)
                    {
                        folio = obj2.Attributes["folio"].InnerText;
                    }
                    if(estoyEnCancelados)
                    {
                        String query1 = "UPDATE [" + Properties.Settings.Default.Database + "].[dbo].[facturacion_XML] set STATUS = '0' WHERE folioFiscal = '" + folio_fiscal+"'";
                        totalDeCancelados++;
                        try
                        {
                            using (SqlConnection connection = new SqlConnection(connString))
                            {
                                connection.Open();
                                SqlCommand cmd = new SqlCommand(query1, connection);
                                cmd.ExecuteNonQuery();

                                String queryCheck1 = "SELECT BUNIT, JRNAL_NO, JRNAL_LINE, CONCEPTO, FUNCION, PROJECT, descripcionLI, AMOUNT, Consecutivo, FOLIO_FISCAL FROM [" + Properties.Settings.Default.Database + "].[dbo].[FISCAL_xml] WHERE folioFiscal = '" + folio_fiscal + "'";
                                SqlCommand cmdCheck = new SqlCommand(queryCheck1, connection);
                                SqlDataReader reader = cmdCheck.ExecuteReader();


                                if (reader.HasRows)
                                {
                                    String BUNIT = "";
                                    String JRNAL_NO = "";
                                    String JRNAL_LINE = "";
                                    String CONCEPTO = "";
                                    String FUNCION = "";
                                    String PROJECT = "";
                                    String descripcionLI = "";
                                    String AMOUNT = "";
                                    String Consecutivo = "";
                                    String FOLIO_FISCAL = "";
                                    mensajeParaElCorreo.Append(this.Enters+"Los cancelados estan ligados a los siguientes movimientos: ");
                                    while (reader.Read())
                                    {
                                        BUNIT = reader.GetString(0).Trim();
                                        JRNAL_NO = Convert.ToString(reader.GetInt32(1));
                                        JRNAL_LINE = Convert.ToString(reader.GetInt32(2));
                                        CONCEPTO = reader.GetString(3).Trim();
                                        FUNCION = reader.GetString(4).Trim();
                                        PROJECT = reader.GetString(5).Trim();
                                        descripcionLI = reader.GetString(6).Trim();
                                        AMOUNT = Convert.ToString(reader.GetDecimal(7));
                                        Consecutivo = reader.GetString(8).Trim();
                                        FOLIO_FISCAL = reader.GetString(9).Trim();

                                        mensajeParaElCorreo.Append(this.Enters+BUNIT + " " + JRNAL_NO + " " + JRNAL_LINE + " " + CONCEPTO + " " + FUNCION + " " + PROJECT + " " + descripcionLI + " " + AMOUNT + " " + FOLIO_FISCAL + " " + Consecutivo);


                                       
                                    }
                                }
                            }
                        }
                        catch (Exception ex1)
                        {
                            System.Windows.Forms.MessageBox.Show(ex1.ToString(), "Error Message1", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                            
                    }
                    else
                    {



                        String query = "";
                       if( this.AnoSel.IndexOf("Emitidos")!=-1)
                       {
                           if(tipoDeComprobante.Equals("INGRESO"))
                           {
                               query = "INSERT INTO [" + Properties.Settings.Default.Database + "].[dbo].[facturacion_XML] (folioFiscal,nombreArchivoXML,ruta,rfc,razonSocial,total,folio,fechaExpedicion,nombreArchivoPDF,STATUS,ocultaEnLigar,rfcRaiz) VALUES ('" + folio_fiscal + "', '" + nombreDelArchivo + "', '" + carpeta.Text + (object)Path.DirectorySeparatorChar + this.AnoSel + (object)Path.DirectorySeparatorChar + this.MesSel + (object)Path.DirectorySeparatorChar + diaActual + "', '" + rfcReceptor + "', '" + nombreReceptor + "', " + total + ", '" + folio + "' , '" + fecha + "', '" + folio_fiscal + ".pdf','2',0,'" + Properties.Settings.Default.RFC + "')";
                           }
                           else
                           {
                               query = "INSERT INTO [" + Properties.Settings.Default.Database + "].[dbo].[facturacion_XML] (folioFiscal,nombreArchivoXML,ruta,rfc,razonSocial,total,folio,fechaExpedicion,nombreArchivoPDF,STATUS,ocultaEnLigar,rfcRaiz) VALUES ('" + folio_fiscal + "', '" + nombreDelArchivo + "', '" + carpeta.Text + (object)Path.DirectorySeparatorChar + this.AnoSel + (object)Path.DirectorySeparatorChar + this.MesSel + (object)Path.DirectorySeparatorChar + diaActual + "', '" + rfcReceptor + "', '" + nombreReceptor + "', " + total + ", '" + folio + "' , '" + fecha + "', '" + folio_fiscal + ".pdf','1',0,'" + Properties.Settings.Default.RFC + "')";
                           }
                           insertaProveedor(rfcReceptor, nombreReceptor);
                       }
                       else
                       {
                           if (tipoDeComprobante.Equals("INGRESO"))
                           {
                               query = "INSERT INTO [" + Properties.Settings.Default.Database + "].[dbo].[facturacion_XML] (folioFiscal,nombreArchivoXML,ruta,rfc,razonSocial,total,folio,fechaExpedicion,nombreArchivoPDF,STATUS,ocultaEnLigar,rfcRaiz) VALUES ('" + folio_fiscal + "', '" + nombreDelArchivo + "', '" + carpeta.Text + (object)Path.DirectorySeparatorChar + this.AnoSel + (object)Path.DirectorySeparatorChar + this.MesSel + (object)Path.DirectorySeparatorChar + diaActual + "', '" + rfc + "', '" + razon + "', " + total + ", '" + folio + "' , '" + fecha + "', '" + folio_fiscal + ".pdf','1',0,'" + Properties.Settings.Default.RFC + "')";
                   
                           }
                           else
                           {
                               query = "INSERT INTO [" + Properties.Settings.Default.Database + "].[dbo].[facturacion_XML] (folioFiscal,nombreArchivoXML,ruta,rfc,razonSocial,total,folio,fechaExpedicion,nombreArchivoPDF,STATUS,ocultaEnLigar,rfcRaiz) VALUES ('" + folio_fiscal + "', '" + nombreDelArchivo + "', '" + carpeta.Text + (object)Path.DirectorySeparatorChar + this.AnoSel + (object)Path.DirectorySeparatorChar + this.MesSel + (object)Path.DirectorySeparatorChar + diaActual + "', '" + rfc + "', '" + razon + "', " + total + ", '" + folio + "' , '" + fecha + "', '" + folio_fiscal + ".pdf','2',0,'" + Properties.Settings.Default.RFC + "')";
                           }
                           //query = "INSERT INTO [" + Properties.Settings.Default.Database + "].[dbo].[facturacion_XML] (folioFiscal,nombreArchivoXML,ruta,rfc,razonSocial,total,folio,fechaExpedicion,nombreArchivoPDF,STATUS,ocultaEnLigar) VALUES ('" + folio_fiscal + "', '" + nombreDelArchivo + "', '" + carpeta.Text + (object)Path.DirectorySeparatorChar + this.AnoSel + (object)Path.DirectorySeparatorChar + this.MesSel + (object)Path.DirectorySeparatorChar + diaActual + "', '" + rfc + "', '" + razon + "', " + total + ", '" + folio + "' , '" + fecha + "', '" + folio_fiscal + ".pdf','1',0)";
                           insertaProveedor(rfc, razon);
                       }
                      
                        String queryCheck = "SELECT * FROM [" + Properties.Settings.Default.Database + "].[dbo].[facturacion_XML] WHERE folioFiscal = '" + folio_fiscal + "'";

                        try
                        {
                            using (SqlConnection connection = new SqlConnection(connString))
                            {
                                connection.Open();
                                SqlCommand cmdCheck = new SqlCommand(queryCheck, connection);
                                SqlDataReader reader = cmdCheck.ExecuteReader();
                                if (!reader.Read())
                                {
                                    reader.Close();
                                    connection.Close();
                                    connection.Open();
                                    SqlCommand cmd = new SqlCommand(query, connection);
                                    cmd.ExecuteNonQuery();

                                    String FileName = carpeta.Text + (object)Path.DirectorySeparatorChar +this.AnoSel+(object)Path.DirectorySeparatorChar+ this.MesSel + (object)Path.DirectorySeparatorChar + diaActual.ToString() + (object)Path.DirectorySeparatorChar + folio_fiscal + ".pdf";
                                    Document = new PdfDocument(PaperType.Letter, false, UnitOfMeasure.Inch, FileName);
                                    DefineFontResources();
                                    DefineTilingPatternResource();
                                    PdfPage Page = new PdfPage(Document);
                                    PdfContents Contents = new PdfContents(Page);
                                    Contents.SaveGraphicsState();
                                    Contents.Translate(0.1, 0.1);
                                    const Double Width = 5.15;
                                    const Double Height = 10.65;
                                    const Double FontSize = 9.0;
                                    PdfFileWriter.TextBox Box = new PdfFileWriter.TextBox(Width, 0.25);
                                    XmlNodeList conceptos = doc.GetElementsByTagName("cfdi:Concepto");
                                    if (conceptos.Count == 0)
                                    {
                                        conceptos = doc.GetElementsByTagName("Concepto");
                                    }

                                    int i;
                                    String conceptosString = "";
                                    for (i = 0; i < conceptos.Count; i++)
                                    {
                                        XmlNode objy = conceptos.Item(i);
                                        String cantidadc = "";
                                        bool isCantidadc = objy.Attributes["cantidad"] != null;
                                        if (isCantidadc)
                                        {
                                            cantidadc = objy.Attributes["cantidad"].InnerText;
                                        }
                                        String unidadc = "";
                                        bool isUnidadc = objy.Attributes["unidad"] != null;
                                        if (isUnidadc)
                                        {
                                            unidadc = objy.Attributes["unidad"].InnerText;
                                        }
                                        String descripcionc = "";
                                        bool isdescripcionc = objy.Attributes["descripcion"] != null;
                                        if (isdescripcionc)
                                        {
                                            descripcionc = objy.Attributes["descripcion"].InnerText;
                                        }
                                        String importec = "";
                                        bool isimportec = objy.Attributes["importe"] != null;
                                        if (isimportec)
                                        {
                                            importec = objy.Attributes["importe"].InnerText;
                                        }
                                        conceptosString = conceptosString + "\n" + cantidadc + " " + descripcionc + " $" + importec;
                                    }
                                    String impuestosString = "";
                                    double totalDeRetenciones = 0;
                                    XmlNodeList retencionesLocales = doc.GetElementsByTagName("implocal:RetencionesLocales");
                                    if (retencionesLocales.Count == 0)
                                    {
                                        retencionesLocales = doc.GetElementsByTagName("RetencionesLocales");
                                    }
                                    for (i = 0; i < retencionesLocales.Count; i++)
                                    {
                                        XmlNode objn = retencionesLocales.Item(i);
                                        String cantidad = "0";
                                        String impuesto = "";
                                        float tasa = 0;
                                        bool isCantidad = objn.Attributes["Importe"] != null;
                                        if (isCantidad)
                                        {
                                            totalDeRetenciones += Convert.ToDouble(objn.Attributes["Importe"].InnerText);
                                            cantidad = objn.Attributes["Importe"].InnerText;
                                            impuesto = objn.Attributes["ImpLocRetenido"].InnerText;
                                            tasa = float.Parse(objn.Attributes["TasadeRetencion"].InnerText);
                                            float importe = float.Parse(cantidad);
                                            String queryCheckImpuesto = "SELECT * FROM [" + Properties.Settings.Default.Database + "].[dbo].[impuestos] WHERE folioFiscal = '" + folio_fiscal + "' and impuesto = '" + impuesto + "' and tasa = " + tasa + " and importe = " + importe;
                                            SqlCommand cmdCheckImpuesto = new SqlCommand(queryCheckImpuesto, connection);
                                            SqlDataReader readerImpuesto = cmdCheckImpuesto.ExecuteReader();
                                            impuestosString = impuestosString + "\nImpuesto: " + impuesto + "\nTasa: " + tasa + "\nImporte: " + importe;
                                            if (!readerImpuesto.HasRows)
                                            {
                                                readerImpuesto.Close();
                                                String queryImpuesto = "INSERT INTO [" + Properties.Settings.Default.Database + "].[dbo].[impuestos] (folioFiscal,impuesto,tasa,importe,tipo,rfcRaiz) VALUES ('" + folio_fiscal + "', '" + impuesto + "', " + tasa + ", " + importe + ",2,'" + Properties.Settings.Default.RFC + "')";
                                                SqlCommand cmdImpuesto = new SqlCommand(queryImpuesto, connection);
                                                cmdImpuesto.ExecuteNonQuery();
                                            }
                                            else
                                            {
                                                readerImpuesto.Close();
                                            }
                                        }
                                        iva = Convert.ToString(float.Parse(iva) + float.Parse(cantidad));
                                    }

                                    XmlNodeList retenciones = doc.GetElementsByTagName("cfdi:Retencion");
                                    if (retenciones.Count == 0)
                                    {
                                        retenciones = doc.GetElementsByTagName("Retencion");
                                    }
                                  
                                    for (i = 0; i < retenciones.Count; i++)
                                    {
                                        XmlNode objn = retenciones.Item(i);
                                        String cantidad = "0";
                                        String impuesto = "";
                                        float tasa = 0;
                                        bool isCantidad = objn.Attributes["importe"] != null;
                                        if (isCantidad)
                                        {
                                            totalDeRetenciones += Convert.ToDouble(objn.Attributes["importe"].InnerText);
                                            cantidad = objn.Attributes["importe"].InnerText;
                                            impuesto = objn.Attributes["impuesto"].InnerText;
                                            tasa = 0;
                                            float importe = float.Parse(cantidad);
                                            String queryCheckImpuesto = "SELECT * FROM [" + Properties.Settings.Default.Database + "].[dbo].[impuestos] WHERE folioFiscal = '" + folio_fiscal + "' and impuesto = '" + impuesto + "' and tasa = " + tasa + " and importe = " + importe;
                                            SqlCommand cmdCheckImpuesto = new SqlCommand(queryCheckImpuesto, connection);
                                            SqlDataReader readerImpuesto = cmdCheckImpuesto.ExecuteReader();
                                            impuestosString = impuestosString + "\nImpuesto: " + impuesto + "\nImporte: " + importe;
                                            if (!readerImpuesto.HasRows)
                                            {
                                                readerImpuesto.Close();
                                                String queryImpuesto = "INSERT INTO [" + Properties.Settings.Default.Database + "].[dbo].[impuestos] (folioFiscal,impuesto,tasa,importe,tipo,rfcRaiz) VALUES ('" + folio_fiscal + "', '" + impuesto + "', " + tasa + ", " + importe + ",2,'" + Properties.Settings.Default.RFC + "')";
                                                SqlCommand cmdImpuesto = new SqlCommand(queryImpuesto, connection);
                                                cmdImpuesto.ExecuteNonQuery();
                                            }
                                            else
                                            {
                                                readerImpuesto.Close();
                                            }
                                        }
                                        iva = Convert.ToString(float.Parse(iva) + float.Parse(cantidad));
                                    }

                                    if(totalDeRetenciones>0.0)
                                    {
                                        double nuevoTotal = Math.Round(totalDeRetenciones + Convert.ToDouble(total),2);
                                        String query2 = "UPDATE [" + Properties.Settings.Default.Database + "].[dbo].[facturacion_XML] set total = "+nuevoTotal+"  WHERE folioFiscal = '" + folio_fiscal+"'";
                                        try
                                        {
                                            using (SqlCommand cmdx = new SqlCommand(query2, connection))
                                            {
                                                cmd.ExecuteNonQuery();
                                            }
                                        }
                                        catch(Exception ex3)
                                        {
                                            ex3.ToString();
                                        }
                                    }
                                    

                                    XmlNodeList trasladosLocales = doc.GetElementsByTagName("implocal:TrasladosLocales");
                                    if (trasladosLocales.Count == 0)
                                    {
                                        trasladosLocales = doc.GetElementsByTagName("TrasladosLocales");
                                    }
                                    for (i = 0; i < trasladosLocales.Count; i++)
                                    {
                                        XmlNode objn = trasladosLocales.Item(i);
                                        String cantidad = "0";
                                        String impuesto = "";
                                        float tasa = 0;
                                        bool isCantidad = objn.Attributes["Importe"] != null;
                                        if (isCantidad)
                                        {
                                            cantidad = objn.Attributes["Importe"].InnerText;
                                            impuesto = objn.Attributes["ImpLocTrasladado"].InnerText;
                                            tasa = float.Parse(objn.Attributes["TasadeTraslado"].InnerText);
                                            float importe = float.Parse(cantidad);
                                            String queryCheckImpuesto = "SELECT * FROM [" + Properties.Settings.Default.Database + "].[dbo].[impuestos] WHERE folioFiscal = '" + folio_fiscal + "' and impuesto = '" + impuesto + "' and tasa = " + tasa + " and importe = " + importe;
                                            SqlCommand cmdCheckImpuesto = new SqlCommand(queryCheckImpuesto, connection);
                                            SqlDataReader readerImpuesto = cmdCheckImpuesto.ExecuteReader();
                                            impuestosString = impuestosString + "\nImpuesto: " + impuesto + "\nTasa: " + tasa + "\nImporte: " + importe;
                                            if (!readerImpuesto.HasRows)
                                            {
                                                readerImpuesto.Close();
                                                String queryImpuesto = "INSERT INTO [" + Properties.Settings.Default.Database + "].[dbo].[impuestos] (folioFiscal,impuesto,tasa,importe,tipo,rfcRaiz) VALUES ('" + folio_fiscal + "', '" + impuesto + "', " + tasa + ", " + importe + ",1,'" + Properties.Settings.Default.RFC + "')";
                                                SqlCommand cmdImpuesto = new SqlCommand(queryImpuesto, connection);
                                                cmdImpuesto.ExecuteNonQuery();
                                            }
                                            else
                                            {
                                                readerImpuesto.Close();
                                            }
                                        }
                                        iva = Convert.ToString(float.Parse(iva) + float.Parse(cantidad));
                                    }

                                    XmlNodeList traslados = doc.GetElementsByTagName("cfdi:Traslado");
                                    if (traslados.Count == 0)
                                    {
                                        traslados = doc.GetElementsByTagName("Traslado");
                                    }
                                    for (i = 0; i < traslados.Count; i++)
                                    {
                                        XmlNode objn = traslados.Item(i);
                                        String cantidad = "0";
                                        String impuesto = "";
                                        float tasa = 0;
                                        bool isCantidad = objn.Attributes["importe"] != null;
                                        if (isCantidad)
                                        {
                                            cantidad = objn.Attributes["importe"].InnerText;
                                            impuesto = objn.Attributes["impuesto"].InnerText;
                                            tasa = float.Parse(objn.Attributes["tasa"].InnerText);
                                            float importe = float.Parse(cantidad);
                                            String queryCheckImpuesto = "SELECT * FROM [" + Properties.Settings.Default.Database + "].[dbo].[impuestos] WHERE folioFiscal = '" + folio_fiscal + "' and impuesto = '" + impuesto + "' and tasa = " + tasa + " and importe = " + importe;
                                            SqlCommand cmdCheckImpuesto = new SqlCommand(queryCheckImpuesto, connection);
                                            SqlDataReader readerImpuesto = cmdCheckImpuesto.ExecuteReader();
                                            impuestosString = impuestosString + "\nImpuesto: " + impuesto + "\nTasa: " + tasa + "\nImporte: " + importe;
                                            if (!readerImpuesto.HasRows)
                                            {
                                                readerImpuesto.Close();
                                                String queryImpuesto = "INSERT INTO [" + Properties.Settings.Default.Database + "].[dbo].[impuestos] (folioFiscal,impuesto,tasa,importe,tipo,rfcRaiz) VALUES ('" + folio_fiscal + "', '" + impuesto + "', " + tasa + ", " + importe + ",1,'" + Properties.Settings.Default.RFC + "')";
                                                SqlCommand cmdImpuesto = new SqlCommand(queryImpuesto, connection);
                                                cmdImpuesto.ExecuteNonQuery();
                                            }
                                            else
                                            {
                                                readerImpuesto.Close();
                                            }
                                        }
                                        iva = Convert.ToString(float.Parse(iva) + float.Parse(cantidad));
                                    }
                                    Box.AddText(ArialNormal, FontSize,
                                        "Cliente: " + nombreReceptor + "\n" +
                                        "RFC: " + rfcReceptor + "\n" +
                                        "Emisor: " + razon + "\n" +
                                        "RFC: " + rfc + "\n" +
                                        "Domicilio Fiscal: "+ calle+" "+noExterior+" "+colonia+" "+municipio+" "+estado+"\n"+ 
                                        "Folio: " + folio + "\nFolio Fiscal: " + folio_fiscal + "\nTotal: $" + total + "\nFecha de Expedicion: " + fecha + conceptosString + impuestosString + "\nNo de Serie del Certificado del SAT: " + noCertificadoSAT + "\nSello digital del CFDI:\n" + selloCFD + "\n\nSello del SAT:\n" + selloSAT + "\n\n\nEste documento es una representación impresa de un CFDI");
                                    Box.AddText(ArialNormal, FontSize, "\n");
                                    Double PosY = Height;
                                    Contents.DrawText(0.0, ref PosY, 0.0, 0, 0.015, 0.05, TextBoxJustify.FitToWidth, Box);
                                    Contents.RestoreGraphicsState();
                                    Contents.SaveGraphicsState();
                                    String DataString = "?re=" + rfc + "&rr=" + rfcReceptor + "&tt=" + total + "&id=" + folio_fiscal;
                                    PdfQRCode QRCode = new PdfQRCode(Document, DataString, ErrorCorrection.M);
                                    Contents.DrawQRCode(QRCode, 6.0, 6.8, 1.2);
                                    Contents.RestoreGraphicsState();
                                    Document.CreateFile();
                                    totalDeDescargados++;
                                }
                                else
                                {
                                    this.cuantosYaExistian++;
                                    totalDeYaExistian++;
                                }

                            }
                        }
                        catch (Exception ex1)
                        {
                            ex1.ToString();
                            this.cuantosNoSeInsertaron++;
                         //   System.Windows.Forms.MessageBox.Show("Error Message", ex1.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                   
           





                    ++this.posicion;
                    if (this.posicion < this.ligas.Count)
                    {
                        if (!this.Cancelar)
                        {
                            this.Descargados.Add(e.Item);
                            this.proceso.Text = string.Format("Descargando {0} de {1}, Ya existian: {2}, Con errores: {3} ", (object)(this.posicion + 1), (object)this.ligas.Count.ToString() , (object)this.cuantosYaExistian, (object)this.cuantosNoSeInsertaron);
                            this.Descarga();
                        }
                        else
                        {
                            this.Cursor = System.Windows.Forms.Cursors.Arrow;
                            this.webControl1.Cursor = System.Windows.Forms.Cursors.Arrow;
                 //           Mensaje.MostrarMensaje(Constantes.TipoMensaje.Detenido, "Descarga", "Proceso cancelado por el usuario");
                        }
                    }
                    else
                    {
                        if(modoGlobal==2 && estoyEnEmitidos)
                        {
                             DateTime now = DateTime.Now;
                            int year = now.Year-anoAnterior;
                            int month = now.Month;
                            if(modoGlobal==2)//ultrapesado
                            {
                                month = mesActual + 1;
                            }
                   
                            int diaFinal = 28;
                            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
                            {
                                diaFinal = 31;
                            }
                            else
                            {
                                if (month == 4 || month == 6 || month == 9 || month == 11)
                                {
                                    diaFinal = 30;
                                }
                                else
                                {
                                    if (year % 4 == 0)//ano bisiesto
                                    {
                                        diaFinal = 29;
                                    }
                                }
                            }

                            if (diaActual < diaFinal)
                            {
                                diaActual++;
                                tmrDecimoCuarto.Start();
                                return;
                            }
                            else
                            {
                                diaActual = 1;
                                if(mesActual<11)
                                {
                                    mesActual++;
                                    tmrDecimoCuarto.Start();
                                    return;
                                }
                                else
                                {
                                    tmrDecimoSexto.Start();
                                    return;
                                }
                            }

                            
                        }
                        if(modoGlobal==1)
                        {
                            if(estoyEnEmitidos)
                            {
                                mandaCorreo();
                            }
                            else
                            {
                                empiezaConLosEmitidos();
                            }
                        }
                        else
                        { 
                            this.proceso.Text = string.Format("Descargando {0} de {1}, Ya existian: {2}, Con errores: {3}", (object)this.posicion, (object)this.ligas.Count.ToString() , (object)this.cuantosYaExistian, (object)this.cuantosNoSeInsertaron);
                            this.Descargados.Add(e.Item);
                            this.Cursor = System.Windows.Forms.Cursors.Arrow;
                            this.webControl1.Cursor = System.Windows.Forms.Cursors.Arrow;
                            this.proceso.Text = string.Format("Descarga Finalizada {0} de {1}, Ya existian: {2}, Con errores: {3}", (object)this.posicion, (object)this.ligas.Count.ToString(), (object)this.cuantosYaExistian, (object)this.cuantosNoSeInsertaron);
                            if(estoyEnCancelados)
                            {
                                //ya termine
                                mensajeParaElCorreo.Append(totalDeCancelados);
                                return;
                            }
                            if(!estoyEnCancelados && estoyEnEmitidos)
                            {
                                //agregar para debuguear emitidos
                                mensajeParaElCorreo.Append(Enters + Enters + "Facturas Emitidas totales: " + (object)this.ligas.Count.ToString() + " Ya existian: " + (object)this.cuantosYaExistian);
                                tmrDecimoSexto.Start();
                                return;
                            }
                            DateTime now = DateTime.Now;
                            int year = now.Year-anoAnterior;
                            int month = now.Month;
                            if(modoGlobal==2)//ultrapesado
                            {
                                month = mesActual + 1;
                            }
                   
                            int diaFinal = 28;
                            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
                            {
                                diaFinal = 31;
                            }
                            else
                            {
                                if (month == 4 || month == 6 || month == 9 || month == 11)
                                {
                                    diaFinal = 30;
                                }
                                else
                                {
                                    if (year % 4 == 0)//ano bisiesto
                                    {
                                        diaFinal = 29;
                                    }
                                }
                            }

                            if (diaActual < diaFinal)
                            {
                                diaActual++;
                                if(estoyEnElMesAnterior)
                                {
                                    tmrDecimo.Start();
                                }
                                else
                                {
                                    tmrQuinto.Start();
                                }
                            }
                            else
                            {
                                if (estoyEnElMesAnterior)
                                {
                                    estoyEnElMesAnterior = false;
                                    diaActual = 1;
                                    empiezaConLosCancelados();
                                }
                                else
                                {
                                    if(modoGlobal==2)//ultrapesado
                                    {
                                        if(mesActual<11)
                                        {
                                            mesActual++;
                                            diaActual = 1;
                                            tmrDecimo.Start();
                                        }
                                        else
                                        {
                                            estoyEnElMesAnterior = false;
                                            diaActual = 1;
                                            mesActual = 0;
                                            empiezaConLosCancelados();
                                        }
                                    }
                                    else//modo pesado
                                    {
                                       /* diaActual++;
                                        if (estoyEnElMesAnterior)
                                        {
                                            tmrDecimo.Start();
                                        }
                                        else
                                        {
                                            tmrQuinto.Start();
                                        }*/
                                        empiezaConElMesAnterior();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               System.Windows.Forms.MessageBox.Show( ex.ToString(), "Error Title2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               
               
               //  Logs.Escribir("Error en download complete : " + ex.ToString());
            }
        }
        private void timerHandlerStop(object sender, EventArgs e)
        {
              tmr.Stop(); 
        }
        private void WebView_LoadCompleted(object sender, NavigationTaskEventArgs e)
        {
            this.proceso.Text = "Listo";      
        }

        private void webControl1_Click(object sender, EventArgs e)
        {

        }

        private void proceso_Click(object sender, EventArgs e)
        {

        }
        public void empiezaConElMesAnterior()
        {
           estoyEnElMesAnterior=true;
           diaActual = 26;
           tmrDecimo.Start();
        }
        public void empiezaConLosCancelados()
        {
            estoyEnCancelados=true;
            mensajeParaElCorreo = new StringBuilder(this.Enters+"Hoy el resultado fue:  Nuevas Facturas del Mes: "+totalDeDescargados+" Ya existian: "+totalDeYaExistian+" Facturas Canceladas: ");
            tmrSeptimo.Start();
        }
        public void auxaux()
        {
            String siEncontroResultados =(String) this.webView3.EvalScript("document.getElementById('ctl00_MainContent_PnlNoResultados').style.display");
            try
            {
                if (siEncontroResultados != null)
                {
                    if (siEncontroResultados.Equals("inline"))
                    {
                        if(modoGlobal==2 && estoyEnEmitidos)//ultrapesado
                        {
                            DateTime now = DateTime.Now;
                            int year = now.Year-anoAnterior;
                            int month = now.Month;
                            int diaFinal = 28;
                            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
                            {
                                diaFinal = 31;
                            }
                            else
                            {
                                if (month == 4 || month == 6 || month == 9 || month == 11)
                                {
                                    diaFinal = 30;
                                }
                                else
                                {
                                    if (year % 4 == 0)//ano bisiesto
                                    {
                                        diaFinal = 29;
                                    }
                                }
                            }

                            if (diaActual < diaFinal)
                            {
                                diaActual++;
                                tmrDecimoCuarto.Start();
                            }
                            else
                            {
                                if (mesActual < 11)
                                {
                                    mesActual++;
                                    diaActual = 1;
                                    tmrDecimoCuarto.Start();
                                }
                                else
                                {
                                    estoyEnElMesAnterior = false;
                                    diaActual = 1;
                                    mesActual = 0;
                                    tmrDecimoSexto.Start();
                                }
                            }
                            return;
                        }


                        if (estoyEnElMesAnterior)
                        {
                            estoyEnElMesAnterior = false;
                            diaActual = 1;
                            empiezaConLosCancelados();
                        }
                        else
                        {
                            if(modoGlobal==2 )//ultra pesado o pesado
                            {//saltate ese día
                                 DateTime now = DateTime.Now;
                                int year = now.Year-anoAnterior;
                                int month = now.Month;
                                int diaFinal = 28;
                                if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
                                {
                                    diaFinal = 31;
                                }
                                else
                                {
                                    if (month == 4 || month == 6 || month == 9 || month == 11)
                                    {
                                        diaFinal = 30;
                                    }
                                    else
                                    {
                                        if (year % 4 == 0)//ano bisiesto
                                        {
                                            diaFinal = 29;
                                        }
                                    }
                                }

                                if (diaActual < diaFinal)
                                {
                                    diaActual++;
                                    tmrQuinto.Start();
                                }
                                else
                                {
                                    if (mesActual < 11)
                                    {
                                        mesActual++;
                                        diaActual = 1;
                                        tmrDecimo.Start();
                                    }
                                    else
                                    {
                                        estoyEnElMesAnterior = false;
                                        diaActual = 1;
                                        mesActual = 0;
                                        empiezaConLosCancelados();
                                    }
                                }
                            }
                            else
                            {
                                empiezaConElMesAnterior();
                            }
                            
                        }

                    }
                    else
                    {
                        this.connString = "Database=" + Properties.Settings.Default.Database + ";Data Source=" + Properties.Settings.Default.Datasource + ";Integrated Security=False;User ID='" + Properties.Settings.Default.User + "';Password='" + Properties.Settings.Default.Password + "';connect timeout = 60";
                        this.cuantosNoSeInsertaron = 0;
                        this.cuantosYaExistian = 0;
                        this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                        this.webControl1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                        string RFC = "";
                        this.Cancelar = false;
                        this.PruebaDescarga(ref RFC);
                        this.posicion = 0;
                        this.descargado = -1;
                        if (this.ligas != null && this.ligas.Count > 0)
                        {
                            this.Descarga();
                            this.tiemporec = new Stopwatch();
                            this.tiemporec.Start();
                            this.timer1.Start();
                        }
                        else
                        {
                            this.Cursor = System.Windows.Forms.Cursors.Arrow;
                            this.webControl1.Cursor = System.Windows.Forms.Cursors.Arrow;
                        }
                    }
                }

            }
            catch (Exception e)
            {
                e.ToString();
                //throw new Exception(e.ToString());
            }
           
        }
        private void btnDescarga_Click_1(object sender, EventArgs e)
        {
           // vuelveAEmpezar();
        }

        private void salida_Click(object sender, EventArgs e)
        {
            if(this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                carpeta.Text = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default.sunRuta = carpeta.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void bDToolStripMenuItem_Click(object sender, EventArgs e)
        {
          }
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("SunPlusXML v0.0.1 Soporte: f.pecina@unav.edu.mx", "SunPlus XML", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);    
        }
        public PdfFont ArialNormal { get; set; }

        public PdfFont ArialBold { get; set; }
        public PdfFont ArialItalic { get; set; }
        public PdfFont ArialBoldItalic { get; set; }
        public PdfFont TimesNormal { get; set; }
        public PdfFont Comic { get; set; }
        public PdfDocument Document { get; set; }
        public PdfTilingPattern WaterMark { get; set; }
        private void DefineTilingPatternResource()
        {
            WaterMark = new PdfTilingPattern(Document);
            String Mark = "PdfFileWriter";
            Double FontSize = 18.0;
            Double TextWidth = ArialBold.TextWidth(FontSize, Mark);
            Double TextHeight = ArialBold.LineSpacing(FontSize);
            Double BaseLine = ArialBold.DescentPlusLeading(FontSize);
            Double BoxWidth = TextWidth + 2 * TextHeight;
            Double BoxHeight = 4 * TextHeight;
            WaterMark.SetTileBox(BoxWidth, BoxHeight);
            WaterMark.SaveGraphicsState();
            WaterMark.SetColorNonStroking(Color.FromArgb(230, 244, 255));
            WaterMark.DrawRectangle(0, 0, BoxWidth, BoxHeight, PaintOp.Fill);
            WaterMark.SetColorNonStroking(Color.White);
            WaterMark.DrawText(ArialBold, FontSize, BoxWidth / 2, BaseLine, TextJustify.Center, Mark);
            BaseLine += BoxHeight / 2;
            WaterMark.DrawText(ArialBold, FontSize, 0.0, BaseLine, TextJustify.Center, Mark);
            WaterMark.DrawText(ArialBold, FontSize, BoxWidth, BaseLine, TextJustify.Center, Mark);
            WaterMark.RestoreGraphicsState();
            return;
        }
        private void DefineFontResources()
        {
            String FontName1 = "Arial";
            String FontName2 = "Times New Roman";
            ArialNormal = new PdfFont(Document, FontName1, System.Drawing.FontStyle.Regular, true);
            ArialBold = new PdfFont(Document, FontName1, System.Drawing.FontStyle.Bold, true);
            ArialItalic = new PdfFont(Document, FontName1, System.Drawing.FontStyle.Italic, true);
            ArialBoldItalic = new PdfFont(Document, FontName1, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, true);
            TimesNormal = new PdfFont(Document, FontName2, System.Drawing.FontStyle.Regular, true);
            Comic = new PdfFont(Document, "Comic Sans MS", System.Drawing.FontStyle.Bold, true);
            ArialNormal.CharSubstitution(9679, 9679, 161);		// euro
            ArialNormal.CharSubstitution(1488, 1514, 162);		// hebrew
            ArialNormal.CharSubstitution(1040, 1045, 189);		// russian
            ArialNormal.CharSubstitution(945, 950, 195);		// greek
            return;
        }
        private void soloDelBuzonTributarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        private void sUFISCALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings form2 = new settings();
            form2.Show();
        }
        private void sUNPLUSADVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sunsettings formsun = new sunsettings();
            formsun.Show();
        }
        private void ligarMovimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }
        private void polizasDelMesToolStripMenuItem_Click(object sender, EventArgs e)
        {
          }     
    }
}