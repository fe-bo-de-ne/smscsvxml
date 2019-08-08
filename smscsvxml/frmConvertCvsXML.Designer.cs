namespace smscsvxml
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
            this.dgvSMS = new System.Windows.Forms.DataGridView();
            this.ofdScegli = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.lblCSV = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSMS)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSMS
            // 
            this.dgvSMS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSMS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSMS.Location = new System.Drawing.Point(12, 102);
            this.dgvSMS.Name = "dgvSMS";
            this.dgvSMS.Size = new System.Drawing.Size(776, 320);
            this.dgvSMS.TabIndex = 0;
            // 
            // ofdScegli
            // 
            this.ofdScegli.FileName = "openFileDialog1";
            this.ofdScegli.Filter = "File CSV phonecopy|*.csv";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(81, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Open CSV";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // lblCSV
            // 
            this.lblCSV.AutoSize = true;
            this.lblCSV.Location = new System.Drawing.Point(162, 62);
            this.lblCSV.Name = "lblCSV";
            this.lblCSV.Size = new System.Drawing.Size(49, 13);
            this.lblCSV.TabIndex = 2;
            this.lblCSV.Text = "file name";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCSV);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvSMS);
            this.Name = "Form1";
            this.Text = "CSV to SMS backup XML";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSMS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSMS;
        private System.Windows.Forms.OpenFileDialog ofdScegli;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblCSV;
    }
}

