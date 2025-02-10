namespace BuildingManagementSystem
{
    partial class OwnerManager
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
            this.ownermanagerbackbutton = new System.Windows.Forms.Button();
            this.ownermanageraddmanagerbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ownermanagerchoosehousecombobox = new System.Windows.Forms.ComboBox();
            this.ownermanagerstatuscombobox = new System.Windows.Forms.ComboBox();
            this.managerDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.managerDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ownermanagerbackbutton
            // 
            this.ownermanagerbackbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ownermanagerbackbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.ownermanagerbackbutton.FlatAppearance.BorderSize = 0;
            this.ownermanagerbackbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ownermanagerbackbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ownermanagerbackbutton.ForeColor = System.Drawing.Color.White;
            this.ownermanagerbackbutton.Location = new System.Drawing.Point(12, 12);
            this.ownermanagerbackbutton.Name = "ownermanagerbackbutton";
            this.ownermanagerbackbutton.Size = new System.Drawing.Size(131, 38);
            this.ownermanagerbackbutton.TabIndex = 25;
            this.ownermanagerbackbutton.Text = "Back";
            this.ownermanagerbackbutton.UseVisualStyleBackColor = false;
            this.ownermanagerbackbutton.Click += new System.EventHandler(this.ownermanagerbackbutton_Click);
            // 
            // ownermanageraddmanagerbutton
            // 
            this.ownermanageraddmanagerbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ownermanageraddmanagerbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.ownermanageraddmanagerbutton.FlatAppearance.BorderSize = 0;
            this.ownermanageraddmanagerbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ownermanageraddmanagerbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ownermanageraddmanagerbutton.ForeColor = System.Drawing.Color.White;
            this.ownermanageraddmanagerbutton.Location = new System.Drawing.Point(775, 12);
            this.ownermanageraddmanagerbutton.Name = "ownermanageraddmanagerbutton";
            this.ownermanageraddmanagerbutton.Size = new System.Drawing.Size(165, 38);
            this.ownermanageraddmanagerbutton.TabIndex = 26;
            this.ownermanageraddmanagerbutton.Text = "Add Manager";
            this.ownermanageraddmanagerbutton.UseVisualStyleBackColor = false;
            this.ownermanageraddmanagerbutton.Click += new System.EventHandler(this.ownermanageraddmanagerbutton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(124, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 27);
            this.label1.TabIndex = 27;
            this.label1.Text = "Choose House :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(521, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 27);
            this.label2.TabIndex = 28;
            this.label2.Text = "Status :";
            // 
            // ownermanagerchoosehousecombobox
            // 
            this.ownermanagerchoosehousecombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ownermanagerchoosehousecombobox.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ownermanagerchoosehousecombobox.FormattingEnabled = true;
            this.ownermanagerchoosehousecombobox.Location = new System.Drawing.Point(319, 119);
            this.ownermanagerchoosehousecombobox.Name = "ownermanagerchoosehousecombobox";
            this.ownermanagerchoosehousecombobox.Size = new System.Drawing.Size(133, 27);
            this.ownermanagerchoosehousecombobox.TabIndex = 29;
            this.ownermanagerchoosehousecombobox.SelectedIndexChanged += new System.EventHandler(this.ownermanagerchoosehousecombobox_SelectedIndexChanged);
            // 
            // ownermanagerstatuscombobox
            // 
            this.ownermanagerstatuscombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ownermanagerstatuscombobox.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ownermanagerstatuscombobox.FormattingEnabled = true;
            this.ownermanagerstatuscombobox.Items.AddRange(new object[] {
            "All Managers",
            "Active Managers",
            "Past Managers"});
            this.ownermanagerstatuscombobox.Location = new System.Drawing.Point(624, 118);
            this.ownermanagerstatuscombobox.Name = "ownermanagerstatuscombobox";
            this.ownermanagerstatuscombobox.Size = new System.Drawing.Size(173, 27);
            this.ownermanagerstatuscombobox.TabIndex = 30;
            this.ownermanagerstatuscombobox.SelectedIndexChanged += new System.EventHandler(this.ownermanagerstatuscombobox_SelectedIndexChanged);
            // 
            // managerDataGridView
            // 
            this.managerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.managerDataGridView.Location = new System.Drawing.Point(285, 221);
            this.managerDataGridView.Name = "managerDataGridView";
            this.managerDataGridView.RowHeadersWidth = 49;
            this.managerDataGridView.RowTemplate.Height = 24;
            this.managerDataGridView.Size = new System.Drawing.Size(430, 174);
            this.managerDataGridView.TabIndex = 31;
            this.managerDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.managerDataGridView_CellContentClick);
            // 
            // OwnerManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 503);
            this.Controls.Add(this.managerDataGridView);
            this.Controls.Add(this.ownermanagerstatuscombobox);
            this.Controls.Add(this.ownermanagerchoosehousecombobox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ownermanageraddmanagerbutton);
            this.Controls.Add(this.ownermanagerbackbutton);
            this.Name = "OwnerManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OwnerManager";
            this.Load += new System.EventHandler(this.OwnerManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.managerDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ownermanagerbackbutton;
        private System.Windows.Forms.Button ownermanageraddmanagerbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ownermanagerchoosehousecombobox;
        private System.Windows.Forms.ComboBox ownermanagerstatuscombobox;
        private System.Windows.Forms.DataGridView managerDataGridView;
    }
}