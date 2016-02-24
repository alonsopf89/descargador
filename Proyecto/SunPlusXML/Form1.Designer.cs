namespace SunPlusXML
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.proceso = new System.Windows.Forms.Label();
            this.webControl1 = new EO.WebBrowser.WinForm.WebControl();
            this.webView3 = new EO.WebBrowser.WebView();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.carpeta = new System.Windows.Forms.Label();
            this.salida = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sUFISCALToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sUNPLUSADVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiempoHastaTrigger = new System.Windows.Forms.Label();
            this.modoLabel = new System.Windows.Forms.Label();
            this.segundosDeVidaLabel = new System.Windows.Forms.Label();
            this.rfcLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // proceso
            // 
            this.proceso.AutoSize = true;
            this.proceso.Location = new System.Drawing.Point(680, 25);
            this.proceso.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.proceso.Name = "proceso";
            this.proceso.Size = new System.Drawing.Size(70, 26);
            this.proceso.TabIndex = 1;
            this.proceso.Text = "label1";
            this.proceso.Click += new System.EventHandler(this.proceso_Click);
            // 
            // webControl1
            // 
            this.webControl1.BackColor = System.Drawing.Color.White;
            this.webControl1.Location = new System.Drawing.Point(4, 185);
            this.webControl1.Margin = new System.Windows.Forms.Padding(6);
            this.webControl1.Name = "webControl1";
            this.webControl1.Size = new System.Drawing.Size(1968, 1169);
            this.webControl1.TabIndex = 3;
            this.webControl1.Text = "webControl1";
            this.webControl1.WebView = this.webView3;
            // 
            // webView3
            // 
            this.webView3.AllowDropLoad = true;
            // 
            // carpeta
            // 
            this.carpeta.AutoSize = true;
            this.carpeta.Location = new System.Drawing.Point(378, 133);
            this.carpeta.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.carpeta.Name = "carpeta";
            this.carpeta.Size = new System.Drawing.Size(36, 26);
            this.carpeta.TabIndex = 4;
            this.carpeta.Text = "hh";
            // 
            // salida
            // 
            this.salida.Location = new System.Drawing.Point(44, 123);
            this.salida.Margin = new System.Windows.Forms.Padding(6);
            this.salida.Name = "salida";
            this.salida.Size = new System.Drawing.Size(237, 44);
            this.salida.TabIndex = 5;
            this.salida.Text = "Carpeta de salida";
            this.salida.UseVisualStyleBackColor = true;
            this.salida.Click += new System.EventHandler(this.salida_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bDToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(2113, 43);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bDToolStripMenuItem
            // 
            this.bDToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sUFISCALToolStripMenuItem,
            this.sUNPLUSADVToolStripMenuItem});
            this.bDToolStripMenuItem.Name = "bDToolStripMenuItem";
            this.bDToolStripMenuItem.Size = new System.Drawing.Size(59, 39);
            this.bDToolStripMenuItem.Text = "BD";
            this.bDToolStripMenuItem.Click += new System.EventHandler(this.bDToolStripMenuItem_Click);
            // 
            // sUFISCALToolStripMenuItem
            // 
            this.sUFISCALToolStripMenuItem.Name = "sUFISCALToolStripMenuItem";
            this.sUFISCALToolStripMenuItem.Size = new System.Drawing.Size(245, 40);
            this.sUFISCALToolStripMenuItem.Text = "SU_FISCAL";
            this.sUFISCALToolStripMenuItem.Click += new System.EventHandler(this.sUFISCALToolStripMenuItem_Click);
            // 
            // sUNPLUSADVToolStripMenuItem
            // 
            this.sUNPLUSADVToolStripMenuItem.Name = "sUNPLUSADVToolStripMenuItem";
            this.sUNPLUSADVToolStripMenuItem.Size = new System.Drawing.Size(245, 40);
            this.sUNPLUSADVToolStripMenuItem.Text = "SUNPLUSADV";
            this.sUNPLUSADVToolStripMenuItem.Click += new System.EventHandler(this.sUNPLUSADVToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(97, 39);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(200, 40);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // tiempoHastaTrigger
            // 
            this.tiempoHastaTrigger.AutoSize = true;
            this.tiempoHastaTrigger.Location = new System.Drawing.Point(560, 98);
            this.tiempoHastaTrigger.Name = "tiempoHastaTrigger";
            this.tiempoHastaTrigger.Size = new System.Drawing.Size(70, 26);
            this.tiempoHastaTrigger.TabIndex = 7;
            this.tiempoHastaTrigger.Text = "label1";
            // 
            // modoLabel
            // 
            this.modoLabel.AutoSize = true;
            this.modoLabel.Location = new System.Drawing.Point(1184, 98);
            this.modoLabel.Name = "modoLabel";
            this.modoLabel.Size = new System.Drawing.Size(70, 26);
            this.modoLabel.TabIndex = 8;
            this.modoLabel.Text = "label1";
            // 
            // segundosDeVidaLabel
            // 
            this.segundosDeVidaLabel.AutoSize = true;
            this.segundosDeVidaLabel.Location = new System.Drawing.Point(1189, 150);
            this.segundosDeVidaLabel.Name = "segundosDeVidaLabel";
            this.segundosDeVidaLabel.Size = new System.Drawing.Size(0, 26);
            this.segundosDeVidaLabel.TabIndex = 9;
            // 
            // rfcLabel
            // 
            this.rfcLabel.AutoSize = true;
            this.rfcLabel.Location = new System.Drawing.Point(44, 70);
            this.rfcLabel.Name = "rfcLabel";
            this.rfcLabel.Size = new System.Drawing.Size(0, 26);
            this.rfcLabel.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2147, 1243);
            this.Controls.Add(this.rfcLabel);
            this.Controls.Add(this.segundosDeVidaLabel);
            this.Controls.Add(this.modoLabel);
            this.Controls.Add(this.tiempoHastaTrigger);
            this.Controls.Add(this.salida);
            this.Controls.Add(this.carpeta);
            this.Controls.Add(this.webControl1);
            this.Controls.Add(this.proceso);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "SunPlus XML";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label proceso;
        private EO.WebBrowser.WinForm.WebControl webControl1;
        private EO.WebBrowser.WebView webView3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label carpeta;
        private System.Windows.Forms.Button salida;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sUFISCALToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sUNPLUSADVToolStripMenuItem;
        private System.Windows.Forms.Label tiempoHastaTrigger;
        private System.Windows.Forms.Label modoLabel;
        private System.Windows.Forms.Label segundosDeVidaLabel;
        private System.Windows.Forms.Label rfcLabel;
    }
}

