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
namespace SunPlusXML
{
    public partial class settings : Form
    {
        public String connString { get; set; }
     
        public settings()
        {
            InitializeComponent();
            this.connString = "Database=" + Properties.Settings.Default.Database + ";Data Source=" + Properties.Settings.Default.Datasource + ";Integrated Security=False;User ID='" + Properties.Settings.Default.User + "';Password='" + Properties.Settings.Default.Password + "';connect timeout = 60";

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void settings_Load(object sender, EventArgs e)
        {
            database.Text = Properties.Settings.Default.Database;
            datasource.Text = Properties.Settings.Default.Datasource;
            user.Text = Properties.Settings.Default.User;
            password.Text = Properties.Settings.Default.Password;
            passSat.Text = Properties.Settings.Default.pass;
            rfcText.Text = Properties.Settings.Default.RFC;
            correoEmisor.Text = Properties.Settings.Default.correoEmisor;
            correoReceptor.Text = Properties.Settings.Default.correoReceptor;
            passCorreo.Text = Properties.Settings.Default.passEmisor;
            if(Properties.Settings.Default.deboGuardar.Equals("1"))
            {
                grabarSQL.Checked = true;
            }
            else
            {
                grabarSQL.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Database = database.Text;
            Properties.Settings.Default.Datasource = datasource.Text;
            Properties.Settings.Default.User = user.Text;
            Properties.Settings.Default.Password = password.Text;
            Properties.Settings.Default.pass = passSat.Text;
            Properties.Settings.Default.RFC = rfcText.Text;
            Properties.Settings.Default.correoEmisor = correoEmisor.Text;
            Properties.Settings.Default.correoReceptor = correoReceptor.Text;
            Properties.Settings.Default.passEmisor = passCorreo.Text;
            String grabarSQLS = "0";
            if(grabarSQL.Checked)
            {
                grabarSQLS = "1";
            }
            Properties.Settings.Default.deboGuardar = grabarSQLS;
            Properties.Settings.Default.Save();
        }

        private void revisar_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Database = database.Text;
            Properties.Settings.Default.Datasource = datasource.Text;
            Properties.Settings.Default.User = user.Text;
            Properties.Settings.Default.Password = password.Text;
            Properties.Settings.Default.pass = passSat.Text;
            Properties.Settings.Default.RFC = rfcText.Text;
            Properties.Settings.Default.correoEmisor = correoEmisor.Text;
            Properties.Settings.Default.correoReceptor = correoReceptor.Text;
            Properties.Settings.Default.passEmisor = passCorreo.Text;
            String grabarSQLS = "0";
            if (grabarSQL.Checked)
            {
                grabarSQLS = "1";
            }
            Properties.Settings.Default.deboGuardar = grabarSQLS;
            Properties.Settings.Default.Save();
            this.connString = "Database=" + Properties.Settings.Default.Database + ";Data Source=" + Properties.Settings.Default.Datasource + ";Integrated Security=False;User ID='" + Properties.Settings.Default.User + "';Password='" + Properties.Settings.Default.Password + "';connect timeout = 60";
            String queryCheck = "USE [" + Properties.Settings.Default.Database + "] SELECT name FROM sys.tables";
             try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();

                    SqlCommand cmdCheck = new SqlCommand(queryCheck, connection);
                    SqlDataReader reader = cmdCheck.ExecuteReader();
                    if(reader.HasRows)
                    {
                        System.Windows.Forms.MessageBox.Show("Conexión Establecida satisfactoriamente", "SunPlusXML", MessageBoxButtons.OK, MessageBoxIcon.Information );
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Sin conexión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Sin conexión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
