namespace BuildingManagementSystem
{
    partial class TenantPayment
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.confirmbutton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.amounttextbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.backbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(452, 217);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(104, 26);
            this.dateTimePicker1.TabIndex = 57;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // confirmbutton
            // 
            this.confirmbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.confirmbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.confirmbutton.FlatAppearance.BorderSize = 0;
            this.confirmbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirmbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmbutton.ForeColor = System.Drawing.Color.White;
            this.confirmbutton.Location = new System.Drawing.Point(315, 343);
            this.confirmbutton.Name = "confirmbutton";
            this.confirmbutton.Size = new System.Drawing.Size(131, 38);
            this.confirmbutton.TabIndex = 56;
            this.confirmbutton.Text = "Confirm";
            this.confirmbutton.UseVisualStyleBackColor = false;
            this.confirmbutton.Click += new System.EventHandler(this.confirmbutton_Click);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(213, 217);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(184, 27);
            this.label11.TabIndex = 55;
            this.label11.Text = "Time and Date :";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(213, 156);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(212, 27);
            this.label10.TabIndex = 54;
            this.label10.Text = "Payment Amount :";
            // 
            // amounttextbox
            // 
            this.amounttextbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.amounttextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amounttextbox.Location = new System.Drawing.Point(452, 158);
            this.amounttextbox.Name = "amounttextbox";
            this.amounttextbox.Size = new System.Drawing.Size(104, 26);
            this.amounttextbox.TabIndex = 53;
            this.amounttextbox.TextChanged += new System.EventHandler(this.amounttextbox_TextChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(303, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 27);
            this.label7.TabIndex = 52;
            this.label7.Text = "Make Payment";
            // 
            // backbutton
            // 
            this.backbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.backbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.backbutton.FlatAppearance.BorderSize = 0;
            this.backbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backbutton.ForeColor = System.Drawing.Color.White;
            this.backbutton.Location = new System.Drawing.Point(9, 10);
            this.backbutton.Name = "backbutton";
            this.backbutton.Size = new System.Drawing.Size(131, 38);
            this.backbutton.TabIndex = 51;
            this.backbutton.Text = "Dashboard";
            this.backbutton.UseVisualStyleBackColor = false;
            this.backbutton.Click += new System.EventHandler(this.backbutton_Click);
            // 
            // TenantPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.confirmbutton);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.amounttextbox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.backbutton);
            this.Name = "TenantPayment";
            this.Text = "TenantPayment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button confirmbutton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox amounttextbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button backbutton;
    }
}