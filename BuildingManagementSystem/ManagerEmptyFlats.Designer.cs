namespace BuildingManagementSystem
{
    partial class ManagerEmptyFlats
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
            this.manageremptyflatschoosehousecombobox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.manageremptyflatstsbackbutton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // manageremptyflatschoosehousecombobox
            // 
            this.manageremptyflatschoosehousecombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manageremptyflatschoosehousecombobox.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageremptyflatschoosehousecombobox.FormattingEnabled = true;
            this.manageremptyflatschoosehousecombobox.Location = new System.Drawing.Point(381, 86);
            this.manageremptyflatschoosehousecombobox.Name = "manageremptyflatschoosehousecombobox";
            this.manageremptyflatschoosehousecombobox.Size = new System.Drawing.Size(170, 27);
            this.manageremptyflatschoosehousecombobox.TabIndex = 58;
            this.manageremptyflatschoosehousecombobox.SelectedIndexChanged += new System.EventHandler(this.manageremptyflatschoosehousecombobox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(165, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 27);
            this.label1.TabIndex = 57;
            this.label1.Text = "Choose House :";
            // 
            // manageremptyflatstsbackbutton
            // 
            this.manageremptyflatstsbackbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.manageremptyflatstsbackbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.manageremptyflatstsbackbutton.FlatAppearance.BorderSize = 0;
            this.manageremptyflatstsbackbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manageremptyflatstsbackbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageremptyflatstsbackbutton.ForeColor = System.Drawing.Color.White;
            this.manageremptyflatstsbackbutton.Location = new System.Drawing.Point(12, 12);
            this.manageremptyflatstsbackbutton.Name = "manageremptyflatstsbackbutton";
            this.manageremptyflatstsbackbutton.Size = new System.Drawing.Size(131, 38);
            this.manageremptyflatstsbackbutton.TabIndex = 56;
            this.manageremptyflatstsbackbutton.Text = "Back";
            this.manageremptyflatstsbackbutton.UseVisualStyleBackColor = false;
            this.manageremptyflatstsbackbutton.Click += new System.EventHandler(this.manageremptyflatstsbackbutton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 205);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 49;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(820, 211);
            this.dataGridView1.TabIndex = 59;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ManagerEmptyFlats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 518);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.manageremptyflatschoosehousecombobox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.manageremptyflatstsbackbutton);
            this.Name = "ManagerEmptyFlats";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManagerEmptyFlats";
            this.Load += new System.EventHandler(this.ManagerEmptyFlats_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox manageremptyflatschoosehousecombobox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button manageremptyflatstsbackbutton;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}