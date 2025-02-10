namespace BuildingManagementSystem
{
    partial class ManagerLog
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.managerlogsbackbutton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(47, 179);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(865, 255);
            this.panel1.TabIndex = 54;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(377, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 27);
            this.label7.TabIndex = 34;
            this.label7.Text = "Grid Box";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(409, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 27);
            this.label6.TabIndex = 48;
            this.label6.Text = "Log History";
            // 
            // managerlogsbackbutton
            // 
            this.managerlogsbackbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.managerlogsbackbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.managerlogsbackbutton.FlatAppearance.BorderSize = 0;
            this.managerlogsbackbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.managerlogsbackbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managerlogsbackbutton.ForeColor = System.Drawing.Color.White;
            this.managerlogsbackbutton.Location = new System.Drawing.Point(12, 12);
            this.managerlogsbackbutton.Name = "managerlogsbackbutton";
            this.managerlogsbackbutton.Size = new System.Drawing.Size(131, 38);
            this.managerlogsbackbutton.TabIndex = 47;
            this.managerlogsbackbutton.Text = "Back";
            this.managerlogsbackbutton.UseVisualStyleBackColor = false;
            this.managerlogsbackbutton.Click += new System.EventHandler(this.managerlogsbackbutton_Click);
            // 
            // ManagerLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 503);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.managerlogsbackbutton);
            this.Name = "ManagerLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManagerLog";
            this.Load += new System.EventHandler(this.ManagerLog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button managerlogsbackbutton;
    }
}