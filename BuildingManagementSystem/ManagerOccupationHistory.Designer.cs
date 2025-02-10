namespace BuildingManagementSystem
{
    partial class ManagerOccupationHistory
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
            this.managerprofileoccupationhistorybackbutton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // managerprofileoccupationhistorybackbutton
            // 
            this.managerprofileoccupationhistorybackbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.managerprofileoccupationhistorybackbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.managerprofileoccupationhistorybackbutton.FlatAppearance.BorderSize = 0;
            this.managerprofileoccupationhistorybackbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.managerprofileoccupationhistorybackbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managerprofileoccupationhistorybackbutton.ForeColor = System.Drawing.Color.White;
            this.managerprofileoccupationhistorybackbutton.Location = new System.Drawing.Point(12, 12);
            this.managerprofileoccupationhistorybackbutton.Name = "managerprofileoccupationhistorybackbutton";
            this.managerprofileoccupationhistorybackbutton.Size = new System.Drawing.Size(131, 38);
            this.managerprofileoccupationhistorybackbutton.TabIndex = 48;
            this.managerprofileoccupationhistorybackbutton.Text = "Back";
            this.managerprofileoccupationhistorybackbutton.UseVisualStyleBackColor = false;
            this.managerprofileoccupationhistorybackbutton.Click += new System.EventHandler(this.managerprofileoccupationhistorybackbutton_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(320, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(227, 27);
            this.label6.TabIndex = 49;
            this.label6.Text = "Occupation History";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(256, 193);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 49;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(357, 254);
            this.dataGridView1.TabIndex = 56;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ManagerOccupationHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 518);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.managerprofileoccupationhistorybackbutton);
            this.Name = "ManagerOccupationHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManagerOccupationHistory";
            this.Load += new System.EventHandler(this.ManagerOccupationHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button managerprofileoccupationhistorybackbutton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}