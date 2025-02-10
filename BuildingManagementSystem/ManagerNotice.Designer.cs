namespace BuildingManagementSystem
{
    partial class ManagerNotice
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
            this.managernoticesendbutton = new System.Windows.Forms.Button();
            this.managernoticemultilinetextbox = new System.Windows.Forms.TextBox();
            this.managernoticechoosesendercombobox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.managernoticeflatnumbercombobox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.managernoticehousenumbercombobox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.managernoticebbackbutton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // managernoticesendbutton
            // 
            this.managernoticesendbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.managernoticesendbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.managernoticesendbutton.FlatAppearance.BorderSize = 0;
            this.managernoticesendbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.managernoticesendbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managernoticesendbutton.ForeColor = System.Drawing.Color.White;
            this.managernoticesendbutton.Location = new System.Drawing.Point(415, 276);
            this.managernoticesendbutton.Name = "managernoticesendbutton";
            this.managernoticesendbutton.Size = new System.Drawing.Size(131, 38);
            this.managernoticesendbutton.TabIndex = 61;
            this.managernoticesendbutton.Text = "Send";
            this.managernoticesendbutton.UseVisualStyleBackColor = false;
            this.managernoticesendbutton.Click += new System.EventHandler(this.managernoticesendbutton_Click);
            // 
            // managernoticemultilinetextbox
            // 
            this.managernoticemultilinetextbox.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managernoticemultilinetextbox.Location = new System.Drawing.Point(173, 129);
            this.managernoticemultilinetextbox.Multiline = true;
            this.managernoticemultilinetextbox.Name = "managernoticemultilinetextbox";
            this.managernoticemultilinetextbox.Size = new System.Drawing.Size(617, 134);
            this.managernoticemultilinetextbox.TabIndex = 60;
            // 
            // managernoticechoosesendercombobox
            // 
            this.managernoticechoosesendercombobox.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managernoticechoosesendercombobox.FormattingEnabled = true;
            this.managernoticechoosesendercombobox.Items.AddRange(new object[] {
            "Owner",
            "All Tenants"});
            this.managernoticechoosesendercombobox.Location = new System.Drawing.Point(519, 96);
            this.managernoticechoosesendercombobox.Name = "managernoticechoosesendercombobox";
            this.managernoticechoosesendercombobox.Size = new System.Drawing.Size(153, 27);
            this.managernoticechoosesendercombobox.TabIndex = 59;
            this.managernoticechoosesendercombobox.SelectedIndexChanged += new System.EventHandler(this.managernoticechoosesendercombobox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(301, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 27);
            this.label2.TabIndex = 58;
            this.label2.Text = "Choose Sender :";
            // 
            // managernoticeflatnumbercombobox
            // 
            this.managernoticeflatnumbercombobox.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managernoticeflatnumbercombobox.FormattingEnabled = true;
            this.managernoticeflatnumbercombobox.Location = new System.Drawing.Point(728, 53);
            this.managernoticeflatnumbercombobox.Name = "managernoticeflatnumbercombobox";
            this.managernoticeflatnumbercombobox.Size = new System.Drawing.Size(133, 27);
            this.managernoticeflatnumbercombobox.TabIndex = 57;
            this.managernoticeflatnumbercombobox.SelectedIndexChanged += new System.EventHandler(this.managernoticeflatnumbercombobox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(548, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 27);
            this.label4.TabIndex = 56;
            this.label4.Text = "Flat Number :";
            // 
            // managernoticehousenumbercombobox
            // 
            this.managernoticehousenumbercombobox.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managernoticehousenumbercombobox.FormattingEnabled = true;
            this.managernoticehousenumbercombobox.Location = new System.Drawing.Point(351, 53);
            this.managernoticehousenumbercombobox.Name = "managernoticehousenumbercombobox";
            this.managernoticehousenumbercombobox.Size = new System.Drawing.Size(133, 27);
            this.managernoticehousenumbercombobox.TabIndex = 55;
            this.managernoticehousenumbercombobox.SelectedIndexChanged += new System.EventHandler(this.managernoticehousenumbercombobox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(155, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 27);
            this.label3.TabIndex = 54;
            this.label3.Text = "House Number :";
            // 
            // managernoticebbackbutton
            // 
            this.managernoticebbackbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.managernoticebbackbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.managernoticebbackbutton.FlatAppearance.BorderSize = 0;
            this.managernoticebbackbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.managernoticebbackbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managernoticebbackbutton.ForeColor = System.Drawing.Color.White;
            this.managernoticebbackbutton.Location = new System.Drawing.Point(12, 10);
            this.managernoticebbackbutton.Name = "managernoticebbackbutton";
            this.managernoticebbackbutton.Size = new System.Drawing.Size(131, 38);
            this.managernoticebbackbutton.TabIndex = 52;
            this.managernoticebbackbutton.Text = "Dashboard";
            this.managernoticebbackbutton.UseVisualStyleBackColor = false;
            this.managernoticebbackbutton.Click += new System.EventHandler(this.managernoticebbackbutton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(87, 328);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 49;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(800, 163);
            this.dataGridView1.TabIndex = 62;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ManagerNotice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 498);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.managernoticesendbutton);
            this.Controls.Add(this.managernoticemultilinetextbox);
            this.Controls.Add(this.managernoticechoosesendercombobox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.managernoticeflatnumbercombobox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.managernoticehousenumbercombobox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.managernoticebbackbutton);
            this.Name = "ManagerNotice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManagerNotice";
            this.Load += new System.EventHandler(this.ManagerNotice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button managernoticesendbutton;
        private System.Windows.Forms.TextBox managernoticemultilinetextbox;
        private System.Windows.Forms.ComboBox managernoticechoosesendercombobox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox managernoticeflatnumbercombobox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox managernoticehousenumbercombobox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button managernoticebbackbutton;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}