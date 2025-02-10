namespace BuildingManagementSystem
{
    partial class TenantTotalFlatRented
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
            this.tenanttotlflatrentedbackbutton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(388, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 27);
            this.label6.TabIndex = 56;
            this.label6.Text = "Total Flat Rented";
            // 
            // tenanttotlflatrentedbackbutton
            // 
            this.tenanttotlflatrentedbackbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tenanttotlflatrentedbackbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.tenanttotlflatrentedbackbutton.FlatAppearance.BorderSize = 0;
            this.tenanttotlflatrentedbackbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tenanttotlflatrentedbackbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenanttotlflatrentedbackbutton.ForeColor = System.Drawing.Color.White;
            this.tenanttotlflatrentedbackbutton.Location = new System.Drawing.Point(12, 12);
            this.tenanttotlflatrentedbackbutton.Name = "tenanttotlflatrentedbackbutton";
            this.tenanttotlflatrentedbackbutton.Size = new System.Drawing.Size(131, 38);
            this.tenanttotlflatrentedbackbutton.TabIndex = 55;
            this.tenanttotlflatrentedbackbutton.Text = "Back";
            this.tenanttotlflatrentedbackbutton.UseVisualStyleBackColor = false;
            this.tenanttotlflatrentedbackbutton.Click += new System.EventHandler(this.tenanttotlflatrentedbackbutton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 163);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(928, 250);
            this.dataGridView1.TabIndex = 57;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // TenantTotalFlatRented
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 503);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tenanttotlflatrentedbackbutton);
            this.Name = "TenantTotalFlatRented";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TenantTotalFlatRented";
            this.Load += new System.EventHandler(this.TenantTotalFlatRented_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button tenanttotlflatrentedbackbutton;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}