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
    public partial class sunsettings : Form
    {
        public String connString { get; set; }
     
        public sunsettings()
        {
            InitializeComponent();
        }

        private void sunsettings_Load(object sender, EventArgs e)
        {
            sunLibro.Text = Properties.Settings.Default.sunLibro;
            database.Text = Properties.Settings.Default.sunDatabase;
            datasource.Text = Properties.Settings.Default.sunDatasource;
            user.Text = Properties.Settings.Default.sunUser;
            password.Text = Properties.Settings.Default.sunPassword;
            unidad.Text = Properties.Settings.Default.sunUnidadDeNegocio; 
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grabar_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.sunDatabase = database.Text;
            Properties.Settings.Default.sunDatasource = datasource.Text;
            Properties.Settings.Default.sunUser = user.Text;
            Properties.Settings.Default.sunPassword = password.Text;
            Properties.Settings.Default.sunUnidadDeNegocio = unidad.Text;
            Properties.Settings.Default.sunLibro = sunLibro.Text;
            Properties.Settings.Default.Save();
        }

        private void revisar_Click(object sender, EventArgs e)
        {
            this.connString = "Database=" + Properties.Settings.Default.sunDatabase + ";Data Source=" + Properties.Settings.Default.sunDatasource + ";Integrated Security=False;User ID='" + Properties.Settings.Default.sunUser + "';Password='" + Properties.Settings.Default.sunPassword + "';connect timeout = 60";
            String queryCheck = "USE [" + Properties.Settings.Default.sunDatabase + "] SELECT name FROM sys.tables";
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();

                    SqlCommand cmdCheck = new SqlCommand(queryCheck, connection);
                    SqlDataReader reader = cmdCheck.ExecuteReader();
                    if (reader.HasRows)
                    {
                        System.Windows.Forms.MessageBox.Show("Conexión Establecida satisfactoriamente", "SunPlusXML", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
