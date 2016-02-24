namespace SunPlusXML
{
    partial class settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settings));
            this.database = new System.Windows.Forms.TextBox();
            this.datasource = new System.Windows.Forms.TextBox();
            this.user = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.revisar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.passCorreo = new System.Windows.Forms.TextBox();
            this.rfcText = new System.Windows.Forms.TextBox();
            this.passSat = new System.Windows.Forms.TextBox();
            this.correoReceptor = new System.Windows.Forms.TextBox();
            this.correoEmisor = new System.Windows.Forms.TextBox();
            this.grabarSQL = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // database
            // 
            this.database.Location = new System.Drawing.Point(64, 75);
            this.database.Name = "database";
            this.database.Size = new System.Drawing.Size(273, 31);
            this.database.TabIndex = 0;
            // 
            // datasource
            // 
            this.datasource.Location = new System.Drawing.Point(64, 168);
            this.datasource.Name = "datasource";
            this.datasource.Size = new System.Drawing.Size(273, 31);
            this.datasource.TabIndex = 1;
            // 
            // user
            // 
            this.user.Location = new System.Drawing.Point(64, 263);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(273, 31);
            this.user.TabIndex = 2;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(64, 347);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(273, 31);
            this.password.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Database:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Datasource:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "User:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Password:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(64, 414);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 51);
            this.button1.TabIndex = 8;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(227, 414);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 51);
            this.button2.TabIndex = 9;
            this.button2.Text = "Grabar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // revisar
            // 
            this.revisar.Location = new System.Drawing.Point(64, 495);
            this.revisar.Name = "revisar";
            this.revisar.Size = new System.Drawing.Size(273, 65);
            this.revisar.TabIndex = 10;
            this.revisar.Text = "Revisar Conexión";
            this.revisar.UseVisualStyleBackColor = true;
            this.revisar.Click += new System.EventHandler(this.revisar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(425, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 26);
            this.label5.TabIndex = 11;
            this.label5.Text = "RFC:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(425, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 26);
            this.label6.TabIndex = 12;
            this.label6.Text = "Password SAT:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(425, 231);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 26);
            this.label7.TabIndex = 13;
            this.label7.Text = "Correo receptor:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(425, 308);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 26);
            this.label8.TabIndex = 14;
            this.label8.Text = "Correo emisor:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(425, 414);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(283, 26);
            this.label9.TabIndex = 15;
            this.label9.Text = "Password de correo emisor:";
            // 
            // passCorreo
            // 
            this.passCorreo.Location = new System.Drawing.Point(430, 470);
            this.passCorreo.Name = "passCorreo";
            this.passCorreo.PasswordChar = '*';
            this.passCorreo.Size = new System.Drawing.Size(231, 31);
            this.passCorreo.TabIndex = 16;
            // 
            // rfcText
            // 
            this.rfcText.Location = new System.Drawing.Point(430, 72);
            this.rfcText.Name = "rfcText";
            this.rfcText.Size = new System.Drawing.Size(231, 31);
            this.rfcText.TabIndex = 17;
            // 
            // passSat
            // 
            this.passSat.Location = new System.Drawing.Point(430, 168);
            this.passSat.Name = "passSat";
            this.passSat.PasswordChar = '*';
            this.passSat.Size = new System.Drawing.Size(231, 31);
            this.passSat.TabIndex = 18;
            // 
            // correoReceptor
            // 
            this.correoReceptor.Location = new System.Drawing.Point(430, 263);
            this.correoReceptor.Name = "correoReceptor";
            this.correoReceptor.Size = new System.Drawing.Size(231, 31);
            this.correoReceptor.TabIndex = 19;
            // 
            // correoEmisor
            // 
            this.correoEmisor.Location = new System.Drawing.Point(430, 347);
            this.correoEmisor.Name = "correoEmisor";
            this.correoEmisor.Size = new System.Drawing.Size(231, 31);
            this.correoEmisor.TabIndex = 20;
            // 
            // grabarSQL
            // 
            this.grabarSQL.AutoSize = true;
            this.grabarSQL.Location = new System.Drawing.Point(430, 529);
            this.grabarSQL.Name = "grabarSQL";
            this.grabarSQL.Size = new System.Drawing.Size(185, 30);
            this.grabarSQL.TabIndex = 21;
            this.grabarSQL.Text = "Grabar en SQL";
            this.grabarSQL.UseVisualStyleBackColor = true;
            // 
            // settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(792, 599);
            this.Controls.Add(this.grabarSQL);
            this.Controls.Add(this.correoEmisor);
            this.Controls.Add(this.correoReceptor);
            this.Controls.Add(this.passSat);
            this.Controls.Add(this.rfcText);
            this.Controls.Add(this.passCorreo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.revisar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.user);
            this.Controls.Add(this.datasource);
            this.Controls.Add(this.database);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox database;
        private System.Windows.Forms.TextBox datasource;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button revisar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox passCorreo;
        private System.Windows.Forms.TextBox rfcText;
        private System.Windows.Forms.TextBox passSat;
        private System.Windows.Forms.TextBox correoReceptor;
        private System.Windows.Forms.TextBox correoEmisor;
        private System.Windows.Forms.CheckBox grabarSQL;
    }
}