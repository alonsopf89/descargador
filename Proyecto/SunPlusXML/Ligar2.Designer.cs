namespace SunPlusXML
{
    partial class Ligar2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ligar2));
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.numeroDiario = new System.Windows.Forms.TextBox();
            this.leerButton = new System.Windows.Forms.Button();
            this.listaDelDiario = new System.Windows.Forms.ListView();
            this.listaDeCandidatos = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.botonLigar = new System.Windows.Forms.Button();
            this.labelDiario4 = new System.Windows.Forms.Label();
            this.cantidadText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(40, 32);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(0, 26);
            this.linkLabel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Número de Diario";
            // 
            // numeroDiario
            // 
            this.numeroDiario.Location = new System.Drawing.Point(51, 96);
            this.numeroDiario.Name = "numeroDiario";
            this.numeroDiario.Size = new System.Drawing.Size(178, 31);
            this.numeroDiario.TabIndex = 2;
            this.numeroDiario.TextChanged += new System.EventHandler(this.numeroDiario_TextChanged);
            // 
            // leerButton
            // 
            this.leerButton.Location = new System.Drawing.Point(275, 43);
            this.leerButton.Name = "leerButton";
            this.leerButton.Size = new System.Drawing.Size(206, 84);
            this.leerButton.TabIndex = 3;
            this.leerButton.Text = "Leer";
            this.leerButton.UseVisualStyleBackColor = true;
            this.leerButton.Click += new System.EventHandler(this.leerButton_Click);
            // 
            // listaDelDiario
            // 
            this.listaDelDiario.Location = new System.Drawing.Point(51, 183);
            this.listaDelDiario.Name = "listaDelDiario";
            this.listaDelDiario.Size = new System.Drawing.Size(1718, 382);
            this.listaDelDiario.TabIndex = 4;
            this.listaDelDiario.UseCompatibleStateImageBehavior = false;
            this.listaDelDiario.SelectedIndexChanged += new System.EventHandler(this.listaDelDiario_SelectedIndexChanged);
            // 
            // listaDeCandidatos
            // 
            this.listaDeCandidatos.Location = new System.Drawing.Point(51, 682);
            this.listaDeCandidatos.Name = "listaDeCandidatos";
            this.listaDeCandidatos.Size = new System.Drawing.Size(1718, 327);
            this.listaDeCandidatos.TabIndex = 5;
            this.listaDeCandidatos.UseCompatibleStateImageBehavior = false;
            this.listaDeCandidatos.SelectedIndexChanged += new System.EventHandler(this.listaDeCandidatos_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 615);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(508, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "Facturas posibles para ligar al movimiento contable";
            // 
            // botonLigar
            // 
            this.botonLigar.Location = new System.Drawing.Point(1608, 587);
            this.botonLigar.Name = "botonLigar";
            this.botonLigar.Size = new System.Drawing.Size(161, 81);
            this.botonLigar.TabIndex = 7;
            this.botonLigar.Text = "Ligar";
            this.botonLigar.UseVisualStyleBackColor = true;
            this.botonLigar.Click += new System.EventHandler(this.botonLigar_Click);
            // 
            // labelDiario4
            // 
            this.labelDiario4.AutoSize = true;
            this.labelDiario4.Location = new System.Drawing.Point(902, 71);
            this.labelDiario4.Name = "labelDiario4";
            this.labelDiario4.Size = new System.Drawing.Size(102, 26);
            this.labelDiario4.TabIndex = 8;
            this.labelDiario4.Text = "               ";
            // 
            // cantidadText
            // 
            this.cantidadText.Location = new System.Drawing.Point(1305, 615);
            this.cantidadText.Name = "cantidadText";
            this.cantidadText.Size = new System.Drawing.Size(268, 31);
            this.cantidadText.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1115, 615);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 26);
            this.label3.TabIndex = 10;
            this.label3.Text = "Cantidad a ligar:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(620, 605);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(290, 51);
            this.button1.TabIndex = 11;
            this.button1.Text = "Cargar otra Factura";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Ligar2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1806, 1037);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cantidadText);
            this.Controls.Add(this.labelDiario4);
            this.Controls.Add(this.botonLigar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listaDeCandidatos);
            this.Controls.Add(this.listaDelDiario);
            this.Controls.Add(this.leerButton);
            this.Controls.Add(this.numeroDiario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ligar2";
            this.Text = "Ligar XML";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox numeroDiario;
        private System.Windows.Forms.Button leerButton;
        private System.Windows.Forms.ListView listaDelDiario;
        private System.Windows.Forms.ListView listaDeCandidatos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button botonLigar;
        private System.Windows.Forms.Label labelDiario4;
        private System.Windows.Forms.TextBox cantidadText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}