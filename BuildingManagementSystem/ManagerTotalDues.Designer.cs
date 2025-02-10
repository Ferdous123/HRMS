namespace BuildingManagementSystem
{
    partial class ManagerTotalDues
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
            this.managertotalduesbackbutton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(372, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(240, 27);
            this.label6.TabIndex = 56;
            this.label6.Text = "All Dues Information";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // managertotalduesbackbutton
            // 
            this.managertotalduesbackbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.managertotalduesbackbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.managertotalduesbackbutton.FlatAppearance.BorderSize = 0;
            this.managertotalduesbackbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.managertotalduesbackbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managertotalduesbackbutton.ForeColor = System.Drawing.Color.White;
            this.managertotalduesbackbutton.Location = new System.Drawing.Point(12, 12);
            this.managertotalduesbackbutton.Name = "managertotalduesbackbutton";
            this.managertotalduesbackbutton.Size = new System.Drawing.Size(131, 38);
            this.managertotalduesbackbutton.TabIndex = 55;
            this.managertotalduesbackbutton.Text = "Back";
            this.managertotalduesbackbutton.UseVisualStyleBackColor = false;
            this.managertotalduesbackbutton.Click += new System.EventHandler(this.managertotalduesbackbutton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(157, 139);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 49;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(648, 223);
            this.dataGridView1.TabIndex = 57;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ManagerTotalDues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 503);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.managertotalduesbackbutton);
            this.Name = "ManagerTotalDues";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManagerTotalDues";
            this.Load += new System.EventHandler(this.ManagerTotalDues_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button managertotalduesbackbutton;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}