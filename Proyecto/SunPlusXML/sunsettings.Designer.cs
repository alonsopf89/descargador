namespace SunPlusXML
{
    partial class sunsettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sunsettings));
            this.database = new System.Windows.Forms.TextBox();
            this.datasource = new System.Windows.Forms.TextBox();
            this.user = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.unidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cancelar = new System.Windows.Forms.Button();
            this.grabar = new System.Windows.Forms.Button();
            this.revisar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.sunLibro = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // database
            // 
            this.database.Location = new System.Drawing.Point(61, 104);
            this.database.Name = "database";
            this.database.Size = new System.Drawing.Size(269, 31);
            this.database.TabIndex = 0;
            // 
            // datasource
            // 
            this.datasource.Location = new System.Drawing.Point(61, 214);
            this.datasource.Name = "datasource";
            this.datasource.Size = new System.Drawing.Size(269, 31);
            this.datasource.TabIndex = 1;
            // 
            // user
            // 
            this.user.Location = new System.Drawing.Point(61, 307);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(269, 31);
            this.user.TabIndex = 2;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(61, 408);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(269, 31);
            this.password.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Database:";
            // 
            // unidad
            // 
            this.unidad.Location = new System.Drawing.Point(61, 500);
            this.unidad.Name = "unidad";
            this.unidad.Size = new System.Drawing.Size(269, 31);
            this.unidad.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "Datasource:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "User:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 456);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(199, 26);
            this.label4.TabIndex = 8;
            this.label4.Text = "Unidad de negocio:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 360);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 26);
            this.label5.TabIndex = 9;
            this.label5.Text = "Password";
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(61, 673);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(124, 41);
            this.cancelar.TabIndex = 10;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // grabar
            // 
            this.grabar.Location = new System.Drawing.Point(204, 673);
            this.grabar.Name = "grabar";
            this.grabar.Size = new System.Drawing.Size(126, 41);
            this.grabar.TabIndex = 11;
            this.grabar.Text = "Grabar";
            this.grabar.UseVisualStyleBackColor = true;
            this.grabar.Click += new System.EventHandler(this.grabar_Click);
            // 
            // revisar
            // 
            this.revisar.Location = new System.Drawing.Point(61, 756);
            this.revisar.Name = "revisar";
            this.revisar.Size = new System.Drawing.Size(269, 63);
            this.revisar.TabIndex = 12;
            this.revisar.Text = "Revisar Conexión";
            this.revisar.UseVisualStyleBackColor = true;
            this.revisar.Click += new System.EventHandler(this.revisar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(56, 563);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 26);
            this.label6.TabIndex = 13;
            this.label6.Text = "Libro:";
            // 
            // sunLibro
            // 
            this.sunLibro.Location = new System.Drawing.Point(61, 605);
            this.sunLibro.Name = "sunLibro";
            this.sunLibro.Size = new System.Drawing.Size(269, 31);
            this.sunLibro.TabIndex = 14;
            // 
            // sunsettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(382, 868);
            this.Controls.Add(this.sunLibro);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.revisar);
            this.Controls.Add(this.grabar);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.unidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.user);
            this.Controls.Add(this.datasource);
            this.Controls.Add(this.database);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "sunsettings";
            this.Text = "SunSettings";
            this.Load += new System.EventHandler(this.sunsettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox database;
        private System.Windows.Forms.TextBox datasource;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox unidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Button grabar;
        private System.Windows.Forms.Button revisar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox sunLibro;
    }
}