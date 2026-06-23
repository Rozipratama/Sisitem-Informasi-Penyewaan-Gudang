namespace Werehouse_Rental_Information_System
{
    partial class FormPilihKontrak
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
            this.dgvKontrak = new System.Windows.Forms.DataGridView();
            this.btnBatal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKontrak)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKontrak
            // 
            this.dgvKontrak.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKontrak.Location = new System.Drawing.Point(12, 64);
            this.dgvKontrak.Name = "dgvKontrak";
            this.dgvKontrak.RowTemplate.Height = 24;
            this.dgvKontrak.Size = new System.Drawing.Size(1048, 252);
            this.dgvKontrak.TabIndex = 0;
            this.dgvKontrak.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKontrak_CellContentClick);
            // 
            // btnBatal
            // 
            this.btnBatal.Location = new System.Drawing.Point(12, 12);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(128, 46);
            this.btnBatal.TabIndex = 1;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = true;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // FormPilihKontrak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1065, 325);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.dgvKontrak);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPilihKontrak";
            this.Text = "FormPilihKontrak";
            this.Load += new System.EventHandler(this.FormPilihKontrak_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKontrak)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKontrak;
        private System.Windows.Forms.Button btnBatal;
    }
}