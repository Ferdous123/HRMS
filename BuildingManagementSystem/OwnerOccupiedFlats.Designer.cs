namespace BuildingManagementSystem
{
    partial class OwnerOccupiedFlats
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
            this.owneroccupiedflatsbackbutton = new System.Windows.Forms.Button();
            this.owneroccupiedflatschoosehousecombobox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flatsDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.flatsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // owneroccupiedflatsbackbutton
            // 
            this.owneroccupiedflatsbackbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.owneroccupiedflatsbackbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.owneroccupiedflatsbackbutton.FlatAppearance.BorderSize = 0;
            this.owneroccupiedflatsbackbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.owneroccupiedflatsbackbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.owneroccupiedflatsbackbutton.ForeColor = System.Drawing.Color.White;
            this.owneroccupiedflatsbackbutton.Location = new System.Drawing.Point(12, 12);
            this.owneroccupiedflatsbackbutton.Name = "owneroccupiedflatsbackbutton";
            this.owneroccupiedflatsbackbutton.Size = new System.Drawing.Size(131, 38);
            this.owneroccupiedflatsbackbutton.TabIndex = 48;
            this.owneroccupiedflatsbackbutton.Text = "Back";
            this.owneroccupiedflatsbackbutton.UseVisualStyleBackColor = false;
            this.owneroccupiedflatsbackbutton.Click += new System.EventHandler(this.owneroccupiedflatsbackbutton_Click);
            // 
            // owneroccupiedflatschoosehousecombobox
            // 
            this.owneroccupiedflatschoosehousecombobox.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.owneroccupiedflatschoosehousecombobox.FormattingEnabled = true;
            this.owneroccupiedflatschoosehousecombobox.Location = new System.Drawing.Point(405, 86);
            this.owneroccupiedflatschoosehousecombobox.Name = "owneroccupiedflatschoosehousecombobox";
            this.owneroccupiedflatschoosehousecombobox.Size = new System.Drawing.Size(170, 27);
            this.owneroccupiedflatschoosehousecombobox.TabIndex = 53;
            this.owneroccupiedflatschoosehousecombobox.SelectedIndexChanged += new System.EventHandler(this.owneroccupiedflatschoosehousecombobox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(159, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 27);
            this.label1.TabIndex = 52;
            this.label1.Text = "Choose House ID  :";
            // 
            // flatsDataGridView
            // 
            this.flatsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.flatsDataGridView.Location = new System.Drawing.Point(43, 203);
            this.flatsDataGridView.Name = "flatsDataGridView";
            this.flatsDataGridView.RowHeadersWidth = 51;
            this.flatsDataGridView.RowTemplate.Height = 24;
            this.flatsDataGridView.Size = new System.Drawing.Size(737, 200);
            this.flatsDataGridView.TabIndex = 35;
            // 
            // OwnerOccupiedFlats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 518);
            this.Controls.Add(this.flatsDataGridView);
            this.Controls.Add(this.owneroccupiedflatschoosehousecombobox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.owneroccupiedflatsbackbutton);
            this.Name = "OwnerOccupiedFlats";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OwnerOccupiedFlats";
            this.Load += new System.EventHandler(this.OwnerOccupiedFlats_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flatsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button owneroccupiedflatsbackbutton;
        private System.Windows.Forms.ComboBox owneroccupiedflatschoosehousecombobox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView flatsDataGridView;
    }
}