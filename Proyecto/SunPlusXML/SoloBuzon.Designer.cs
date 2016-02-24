namespace SunPlusXML
{
    partial class SoloBuzon
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
            this.todosLosPeriodos = new System.Windows.Forms.RadioButton();
            this.algunosPeriodos = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.de = new System.Windows.Forms.ComboBox();
            this.a = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.todosRFC = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.rfcCombo = new System.Windows.Forms.ComboBox();
            this.listar = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.razonSocial = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // todosLosPeriodos
            // 
            this.todosLosPeriodos.AutoSize = true;
            this.todosLosPeriodos.Location = new System.Drawing.Point(25, 42);
            this.todosLosPeriodos.Name = "todosLosPeriodos";
            this.todosLosPeriodos.Size = new System.Drawing.Size(219, 30);
            this.todosLosPeriodos.TabIndex = 0;
            this.todosLosPeriodos.TabStop = true;
            this.todosLosPeriodos.Text = "Todos los periodos";
            this.todosLosPeriodos.UseVisualStyleBackColor = true;
            this.todosLosPeriodos.CheckedChanged += new System.EventHandler(this.todosLosPeriodos_CheckedChanged);
            // 
            // algunosPeriodos
            // 
            this.algunosPeriodos.AutoSize = true;
            this.algunosPeriodos.Location = new System.Drawing.Point(25, 100);
            this.algunosPeriodos.Name = "algunosPeriodos";
            this.algunosPeriodos.Size = new System.Drawing.Size(205, 30);
            this.algunosPeriodos.TabIndex = 1;
            this.algunosPeriodos.TabStop = true;
            this.algunosPeriodos.Text = "Algunos periodos";
            this.algunosPeriodos.UseVisualStyleBackColor = true;
            this.algunosPeriodos.CheckedChanged += new System.EventHandler(this.algunosPeriodos_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 26);
            this.label1.TabIndex = 2;
            // 
            // de
            // 
            this.de.FormattingEnabled = true;
            this.de.Location = new System.Drawing.Point(58, 237);
            this.de.Name = "de";
            this.de.Size = new System.Drawing.Size(173, 33);
            this.de.TabIndex = 3;
            this.de.SelectedIndexChanged += new System.EventHandler(this.de_SelectedIndexChanged);
            // 
            // a
            // 
            this.a.FormattingEnabled = true;
            this.a.Location = new System.Drawing.Point(58, 321);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(173, 33);
            this.a.TabIndex = 5;
            this.a.SelectedIndexChanged += new System.EventHandler(this.a_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "De:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "A:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.todosRFC);
            this.groupBox1.Location = new System.Drawing.Point(404, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 149);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RFC";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.todosLosPeriodos);
            this.groupBox2.Controls.Add(this.algunosPeriodos);
            this.groupBox2.Location = new System.Drawing.Point(43, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(294, 154);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Periodos";
            // 
            // todosRFC
            // 
            this.todosRFC.AutoSize = true;
            this.todosRFC.Location = new System.Drawing.Point(34, 37);
            this.todosRFC.Name = "todosRFC";
            this.todosRFC.Size = new System.Drawing.Size(181, 30);
            this.todosRFC.TabIndex = 0;
            this.todosRFC.TabStop = true;
            this.todosRFC.Text = "Todos los RFC";
            this.todosRFC.UseVisualStyleBackColor = true;
            this.todosRFC.CheckedChanged += new System.EventHandler(this.todosRFC_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(34, 94);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(116, 30);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Un RFC";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rfcCombo
            // 
            this.rfcCombo.FormattingEnabled = true;
            this.rfcCombo.Location = new System.Drawing.Point(438, 237);
            this.rfcCombo.Name = "rfcCombo";
            this.rfcCombo.Size = new System.Drawing.Size(288, 33);
            this.rfcCombo.TabIndex = 10;
            this.rfcCombo.SelectedIndexChanged += new System.EventHandler(this.rfcCombo_SelectedIndexChanged);
            // 
            // listar
            // 
            this.listar.Location = new System.Drawing.Point(493, 321);
            this.listar.Name = "listar";
            this.listar.Size = new System.Drawing.Size(156, 53);
            this.listar.TabIndex = 11;
            this.listar.Text = "Listar";
            this.listar.UseVisualStyleBackColor = true;
            this.listar.Click += new System.EventHandler(this.listar_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // razonSocial
            // 
            this.razonSocial.AutoSize = true;
            this.razonSocial.Location = new System.Drawing.Point(438, 185);
            this.razonSocial.Name = "razonSocial";
            this.razonSocial.Size = new System.Drawing.Size(0, 26);
            this.razonSocial.TabIndex = 12;
            // 
            // SoloBuzon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 469);
            this.Controls.Add(this.razonSocial);
            this.Controls.Add(this.listar);
            this.Controls.Add(this.rfcCombo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.a);
            this.Controls.Add(this.de);
            this.Controls.Add(this.label1);
            this.Name = "SoloBuzon";
            this.Text = "SoloBuzon";
            this.Load += new System.EventHandler(this.SoloBuzon_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton todosLosPeriodos;
        private System.Windows.Forms.RadioButton algunosPeriodos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox de;
        private System.Windows.Forms.ComboBox a;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton todosRFC;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox rfcCombo;
        private System.Windows.Forms.Button listar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label razonSocial;
    }
}