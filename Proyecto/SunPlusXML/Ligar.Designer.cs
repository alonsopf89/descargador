namespace SunPlusXML
{
    partial class Ligar
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.cantidadText = new System.Windows.Forms.TextBox();
            this.ligarButton = new System.Windows.Forms.Button();
            this.labelDiario3 = new System.Windows.Forms.Label();
            this.labelDiario2 = new System.Windows.Forms.Label();
            this.labelDiario = new System.Windows.Forms.Label();
            this.xmlCantidad = new System.Windows.Forms.Button();
            this.buscar = new System.Windows.Forms.Button();
            this.lineaDiario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numeroDiario = new System.Windows.Forms.TextBox();
            this.labelnumero = new System.Windows.Forms.Label();
            this.webControl1 = new EO.WebBrowser.WinForm.WebControl();
            this.webView1 = new EO.WebBrowser.WebView();
            this.listaDeCandidatos = new System.Windows.Forms.ListView();
            this.labelDiario4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.labelDiario4);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.cantidadText);
            this.splitContainer1.Panel1.Controls.Add(this.ligarButton);
            this.splitContainer1.Panel1.Controls.Add(this.labelDiario3);
            this.splitContainer1.Panel1.Controls.Add(this.labelDiario2);
            this.splitContainer1.Panel1.Controls.Add(this.labelDiario);
            this.splitContainer1.Panel1.Controls.Add(this.xmlCantidad);
            this.splitContainer1.Panel1.Controls.Add(this.buscar);
            this.splitContainer1.Panel1.Controls.Add(this.lineaDiario);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.numeroDiario);
            this.splitContainer1.Panel1.Controls.Add(this.labelnumero);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.webControl1);
            this.splitContainer1.Panel2.Controls.Add(this.listaDeCandidatos);
            this.splitContainer1.Size = new System.Drawing.Size(1785, 1069);
            this.splitContainer1.SplitterDistance = 398;
            this.splitContainer1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 859);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 26);
            this.label2.TabIndex = 9;
            this.label2.Text = "Cantidad:";
            // 
            // cantidadText
            // 
            this.cantidadText.Location = new System.Drawing.Point(47, 911);
            this.cantidadText.Name = "cantidadText";
            this.cantidadText.Size = new System.Drawing.Size(199, 31);
            this.cantidadText.TabIndex = 8;
            // 
            // ligarButton
            // 
            this.ligarButton.Location = new System.Drawing.Point(47, 981);
            this.ligarButton.Name = "ligarButton";
            this.ligarButton.Size = new System.Drawing.Size(206, 40);
            this.ligarButton.TabIndex = 7;
            this.ligarButton.Text = "Ligar";
            this.ligarButton.UseVisualStyleBackColor = true;
            this.ligarButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelDiario3
            // 
            this.labelDiario3.AutoSize = true;
            this.labelDiario3.Location = new System.Drawing.Point(39, 352);
            this.labelDiario3.Name = "labelDiario3";
            this.labelDiario3.Size = new System.Drawing.Size(84, 26);
            this.labelDiario3.TabIndex = 6;
            this.labelDiario3.Text = "            ";
            // 
            // labelDiario2
            // 
            this.labelDiario2.AutoSize = true;
            this.labelDiario2.Location = new System.Drawing.Point(39, 303);
            this.labelDiario2.Name = "labelDiario2";
            this.labelDiario2.Size = new System.Drawing.Size(72, 26);
            this.labelDiario2.TabIndex = 5;
            this.labelDiario2.Text = "          ";
            // 
            // labelDiario
            // 
            this.labelDiario.AutoSize = true;
            this.labelDiario.Location = new System.Drawing.Point(24, 269);
            this.labelDiario.Name = "labelDiario";
            this.labelDiario.Size = new System.Drawing.Size(0, 26);
            this.labelDiario.TabIndex = 4;
            // 
            // xmlCantidad
            // 
            this.xmlCantidad.Location = new System.Drawing.Point(39, 636);
            this.xmlCantidad.Name = "xmlCantidad";
            this.xmlCantidad.Size = new System.Drawing.Size(207, 40);
            this.xmlCantidad.TabIndex = 0;
            this.xmlCantidad.Text = "XML por cantidad";
            this.xmlCantidad.UseVisualStyleBackColor = true;
            this.xmlCantidad.Click += new System.EventHandler(this.xmlCantidad_Click);
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(39, 405);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(207, 40);
            this.buscar.TabIndex = 3;
            this.buscar.Text = "Buscar Diario";
            this.buscar.UseVisualStyleBackColor = true;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // lineaDiario
            // 
            this.lineaDiario.Location = new System.Drawing.Point(39, 215);
            this.lineaDiario.Name = "lineaDiario";
            this.lineaDiario.Size = new System.Drawing.Size(195, 31);
            this.lineaDiario.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Linea de diario:";
            // 
            // numeroDiario
            // 
            this.numeroDiario.Location = new System.Drawing.Point(39, 88);
            this.numeroDiario.Name = "numeroDiario";
            this.numeroDiario.Size = new System.Drawing.Size(195, 31);
            this.numeroDiario.TabIndex = 0;
            // 
            // labelnumero
            // 
            this.labelnumero.AutoSize = true;
            this.labelnumero.Location = new System.Drawing.Point(34, 33);
            this.labelnumero.Name = "labelnumero";
            this.labelnumero.Size = new System.Drawing.Size(185, 26);
            this.labelnumero.TabIndex = 0;
            this.labelnumero.Text = "Número de diario:";
            this.labelnumero.Click += new System.EventHandler(this.label1_Click);
            // 
            // webControl1
            // 
            this.webControl1.BackColor = System.Drawing.Color.White;
            this.webControl1.Location = new System.Drawing.Point(3, 269);
            this.webControl1.Name = "webControl1";
            this.webControl1.Size = new System.Drawing.Size(995, 797);
            this.webControl1.TabIndex = 1;
            this.webControl1.Text = "webControl1";
            this.webControl1.WebView = this.webView1;
            // 
            // webView1
            // 
            this.webView1.AllowDropLoad = true;
            // 
            // listaDeCandidatos
            // 
            this.listaDeCandidatos.Location = new System.Drawing.Point(3, 3);
            this.listaDeCandidatos.Name = "listaDeCandidatos";
            this.listaDeCandidatos.Size = new System.Drawing.Size(995, 265);
            this.listaDeCandidatos.TabIndex = 0;
            this.listaDeCandidatos.UseCompatibleStateImageBehavior = false;
            this.listaDeCandidatos.SelectedIndexChanged += new System.EventHandler(this.listaDeCandidatos_SelectedIndexChanged);
            // 
            // labelDiario4
            // 
            this.labelDiario4.AutoSize = true;
            this.labelDiario4.Location = new System.Drawing.Point(44, 470);
            this.labelDiario4.Name = "labelDiario4";
            this.labelDiario4.Size = new System.Drawing.Size(84, 26);
            this.labelDiario4.TabIndex = 10;
            this.labelDiario4.Text = "            ";
            // 
            // Ligar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1785, 1069);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Ligar";
            this.Text = "Ligar";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labelnumero;
        private System.Windows.Forms.TextBox numeroDiario;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.TextBox lineaDiario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button xmlCantidad;
        private System.Windows.Forms.ListView listaDeCandidatos;
        private System.Windows.Forms.Label labelDiario;
        private System.Windows.Forms.Label labelDiario3;
        private System.Windows.Forms.Label labelDiario2;
        private System.Windows.Forms.Button ligarButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cantidadText;
        private EO.WebBrowser.WinForm.WebControl webControl1;
        private EO.WebBrowser.WebView webView1;
        private System.Windows.Forms.Label labelDiario4;
    }
}