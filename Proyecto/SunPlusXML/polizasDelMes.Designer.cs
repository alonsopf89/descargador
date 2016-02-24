namespace SunPlusXML
{
    partial class polizasDelMes
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
            this.label1 = new System.Windows.Forms.Label();
            this.periodosCombo = new System.Windows.Forms.ComboBox();
            this.listaRFC = new System.Windows.Forms.ListView();
            this.generarXML = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Periodo:";
            // 
            // periodosCombo
            // 
            this.periodosCombo.FormattingEnabled = true;
            this.periodosCombo.Location = new System.Drawing.Point(37, 86);
            this.periodosCombo.Name = "periodosCombo";
            this.periodosCombo.Size = new System.Drawing.Size(273, 33);
            this.periodosCombo.TabIndex = 1;
            this.periodosCombo.SelectedIndexChanged += new System.EventHandler(this.periodosCombo_SelectedIndexChanged);
            // 
            // listaRFC
            // 
            this.listaRFC.Location = new System.Drawing.Point(37, 183);
            this.listaRFC.Name = "listaRFC";
            this.listaRFC.Size = new System.Drawing.Size(1366, 714);
            this.listaRFC.TabIndex = 2;
            this.listaRFC.UseCompatibleStateImageBehavior = false;
            // 
            // generarXML
            // 
            this.generarXML.Location = new System.Drawing.Point(978, 926);
            this.generarXML.Name = "generarXML";
            this.generarXML.Size = new System.Drawing.Size(269, 49);
            this.generarXML.TabIndex = 3;
            this.generarXML.Text = "Generar XML Polizas";
            this.generarXML.UseVisualStyleBackColor = true;
            this.generarXML.Click += new System.EventHandler(this.generarXML_Click);
            // 
            // polizasDelMes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1449, 1006);
            this.Controls.Add(this.generarXML);
            this.Controls.Add(this.listaRFC);
            this.Controls.Add(this.periodosCombo);
            this.Controls.Add(this.label1);
            this.Name = "polizasDelMes";
            this.Text = "Polizas del mes";
            this.Load += new System.EventHandler(this.polizasDelMes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox periodosCombo;
        private System.Windows.Forms.ListView listaRFC;
        private System.Windows.Forms.Button generarXML;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}