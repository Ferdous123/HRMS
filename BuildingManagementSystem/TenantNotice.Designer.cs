namespace BuildingManagementSystem
{
    partial class TenantNotice
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
            this.tenantnoticesendbutton = new System.Windows.Forms.Button();
            this.tenantnoticemultilinetextbox = new System.Windows.Forms.TextBox();
            this.tenantnoticechoosesendercombobox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tenantnoticebbackbutton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tenantnoticesendbutton
            // 
            this.tenantnoticesendbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tenantnoticesendbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.tenantnoticesendbutton.FlatAppearance.BorderSize = 0;
            this.tenantnoticesendbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tenantnoticesendbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenantnoticesendbutton.ForeColor = System.Drawing.Color.White;
            this.tenantnoticesendbutton.Location = new System.Drawing.Point(415, 242);
            this.tenantnoticesendbutton.Name = "tenantnoticesendbutton";
            this.tenantnoticesendbutton.Size = new System.Drawing.Size(131, 38);
            this.tenantnoticesendbutton.TabIndex = 72;
            this.tenantnoticesendbutton.Text = "Send";
            this.tenantnoticesendbutton.UseVisualStyleBackColor = false;
            this.tenantnoticesendbutton.Click += new System.EventHandler(this.tenantnoticesendbutton_Click);
            // 
            // tenantnoticemultilinetextbox
            // 
            this.tenantnoticemultilinetextbox.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenantnoticemultilinetextbox.Location = new System.Drawing.Point(212, 82);
            this.tenantnoticemultilinetextbox.Multiline = true;
            this.tenantnoticemultilinetextbox.Name = "tenantnoticemultilinetextbox";
            this.tenantnoticemultilinetextbox.Size = new System.Drawing.Size(555, 143);
            this.tenantnoticemultilinetextbox.TabIndex = 71;
            this.tenantnoticemultilinetextbox.TextChanged += new System.EventHandler(this.tenantnoticemultilinetextbox_TextChanged);
            // 
            // tenantnoticechoosesendercombobox
            // 
            this.tenantnoticechoosesendercombobox.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenantnoticechoosesendercombobox.FormattingEnabled = true;
            this.tenantnoticechoosesendercombobox.Items.AddRange(new object[] {
            "All",
            "Owner",
            "Manager"});
            this.tenantnoticechoosesendercombobox.Location = new System.Drawing.Point(520, 32);
            this.tenantnoticechoosesendercombobox.Name = "tenantnoticechoosesendercombobox";
            this.tenantnoticechoosesendercombobox.Size = new System.Drawing.Size(153, 27);
            this.tenantnoticechoosesendercombobox.TabIndex = 70;
            this.tenantnoticechoosesendercombobox.SelectedIndexChanged += new System.EventHandler(this.tenantnoticechoosesendercombobox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(302, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 27);
            this.label2.TabIndex = 69;
            this.label2.Text = "Choose Receiver :";
            // 
            // tenantnoticebbackbutton
            // 
            this.tenantnoticebbackbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tenantnoticebbackbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.tenantnoticebbackbutton.FlatAppearance.BorderSize = 0;
            this.tenantnoticebbackbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tenantnoticebbackbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenantnoticebbackbutton.ForeColor = System.Drawing.Color.White;
            this.tenantnoticebbackbutton.Location = new System.Drawing.Point(12, 12);
            this.tenantnoticebbackbutton.Name = "tenantnoticebbackbutton";
            this.tenantnoticebbackbutton.Size = new System.Drawing.Size(131, 38);
            this.tenantnoticebbackbutton.TabIndex = 63;
            this.tenantnoticebbackbutton.Text = "Back";
            this.tenantnoticebbackbutton.UseVisualStyleBackColor = false;
            this.tenantnoticebbackbutton.Click += new System.EventHandler(this.tenantnoticebbackbutton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(29, 296);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 49;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(894, 195);
            this.dataGridView1.TabIndex = 73;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // TenantNotice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 503);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tenantnoticesendbutton);
            this.Controls.Add(this.tenantnoticemultilinetextbox);
            this.Controls.Add(this.tenantnoticechoosesendercombobox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tenantnoticebbackbutton);
            this.Name = "TenantNotice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TenantNotice";
            this.Load += new System.EventHandler(this.TenantNotice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button tenantnoticesendbutton;
        private System.Windows.Forms.TextBox tenantnoticemultilinetextbox;
        private System.Windows.Forms.ComboBox tenantnoticechoosesendercombobox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button tenantnoticebbackbutton;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}