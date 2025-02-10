namespace BuildingManagementSystem
{
    partial class TenantElectricBillDetails
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
            this.label6 = new System.Windows.Forms.Label();
            this.tenantelectricbilldetailsbackbutton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(351, 55);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(226, 27);
            this.label6.TabIndex = 59;
            this.label6.Text = "Electric Bill History";
            // 
            // tenantelectricbilldetailsbackbutton
            // 
            this.tenantelectricbilldetailsbackbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tenantelectricbilldetailsbackbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.tenantelectricbilldetailsbackbutton.FlatAppearance.BorderSize = 0;
            this.tenantelectricbilldetailsbackbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tenantelectricbilldetailsbackbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenantelectricbilldetailsbackbutton.ForeColor = System.Drawing.Color.White;
            this.tenantelectricbilldetailsbackbutton.Location = new System.Drawing.Point(12, 12);
            this.tenantelectricbilldetailsbackbutton.Name = "tenantelectricbilldetailsbackbutton";
            this.tenantelectricbilldetailsbackbutton.Size = new System.Drawing.Size(131, 38);
            this.tenantelectricbilldetailsbackbutton.TabIndex = 58;
            this.tenantelectricbilldetailsbackbutton.Text = "Back";
            this.tenantelectricbilldetailsbackbutton.UseVisualStyleBackColor = false;
            this.tenantelectricbilldetailsbackbutton.Click += new System.EventHandler(this.tenantelectricbilldetailsbackbutton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(65, 213);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 49;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(836, 227);
            this.dataGridView1.TabIndex = 60;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // TenantElectricBillDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 503);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tenantelectricbilldetailsbackbutton);
            this.Name = "TenantElectricBillDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TenantElectricBillDetails";
            this.Load += new System.EventHandler(this.TenantElectricBillDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button tenantelectricbilldetailsbackbutton;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}