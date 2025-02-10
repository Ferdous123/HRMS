namespace BuildingManagementSystem
{
    partial class TenantPaymentDetails
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
            this.label2 = new System.Windows.Forms.Label();
            this.paymentH0istorydataGridView = new System.Windows.Forms.DataGridView();
            this.tenantpaymentpaymenttypecombobox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ownerrecivedpaymentcashentrybutton = new System.Windows.Forms.Button();
            this.ownerrecivedpaymentbackbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.paymentH0istorydataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(205, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 27);
            this.label2.TabIndex = 59;
            this.label2.Text = "Filter By :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // paymentH0istorydataGridView
            // 
            this.paymentH0istorydataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.paymentH0istorydataGridView.Location = new System.Drawing.Point(137, 251);
            this.paymentH0istorydataGridView.Name = "paymentH0istorydataGridView";
            this.paymentH0istorydataGridView.RowHeadersWidth = 49;
            this.paymentH0istorydataGridView.RowTemplate.Height = 24;
            this.paymentH0istorydataGridView.Size = new System.Drawing.Size(681, 226);
            this.paymentH0istorydataGridView.TabIndex = 58;
            this.paymentH0istorydataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.paymentH0istorydataGridView_CellContentClick);
            // 
            // tenantpaymentpaymenttypecombobox
            // 
            this.tenantpaymentpaymenttypecombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenantpaymentpaymenttypecombobox.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenantpaymentpaymenttypecombobox.FormattingEnabled = true;
            this.tenantpaymentpaymenttypecombobox.Location = new System.Drawing.Point(387, 165);
            this.tenantpaymentpaymenttypecombobox.Name = "tenantpaymentpaymenttypecombobox";
            this.tenantpaymentpaymenttypecombobox.Size = new System.Drawing.Size(133, 27);
            this.tenantpaymentpaymenttypecombobox.TabIndex = 55;
            this.tenantpaymentpaymenttypecombobox.SelectedIndexChanged += new System.EventHandler(this.tenantpaymentpaymenttypecombobox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(205, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 27);
            this.label4.TabIndex = 54;
            this.label4.Text = "Payment Type :";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(382, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 27);
            this.label6.TabIndex = 49;
            this.label6.Text = "Payment History";
            // 
            // ownerrecivedpaymentcashentrybutton
            // 
            this.ownerrecivedpaymentcashentrybutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ownerrecivedpaymentcashentrybutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.ownerrecivedpaymentcashentrybutton.FlatAppearance.BorderSize = 0;
            this.ownerrecivedpaymentcashentrybutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ownerrecivedpaymentcashentrybutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ownerrecivedpaymentcashentrybutton.ForeColor = System.Drawing.Color.White;
            this.ownerrecivedpaymentcashentrybutton.Location = new System.Drawing.Point(780, 14);
            this.ownerrecivedpaymentcashentrybutton.Name = "ownerrecivedpaymentcashentrybutton";
            this.ownerrecivedpaymentcashentrybutton.Size = new System.Drawing.Size(165, 38);
            this.ownerrecivedpaymentcashentrybutton.TabIndex = 48;
            this.ownerrecivedpaymentcashentrybutton.Text = "Make Payment";
            this.ownerrecivedpaymentcashentrybutton.UseVisualStyleBackColor = false;
            this.ownerrecivedpaymentcashentrybutton.Click += new System.EventHandler(this.ownerrecivedpaymentcashentrybutton_Click);
            // 
            // ownerrecivedpaymentbackbutton
            // 
            this.ownerrecivedpaymentbackbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ownerrecivedpaymentbackbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.ownerrecivedpaymentbackbutton.FlatAppearance.BorderSize = 0;
            this.ownerrecivedpaymentbackbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ownerrecivedpaymentbackbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ownerrecivedpaymentbackbutton.ForeColor = System.Drawing.Color.White;
            this.ownerrecivedpaymentbackbutton.Location = new System.Drawing.Point(17, 14);
            this.ownerrecivedpaymentbackbutton.Name = "ownerrecivedpaymentbackbutton";
            this.ownerrecivedpaymentbackbutton.Size = new System.Drawing.Size(131, 38);
            this.ownerrecivedpaymentbackbutton.TabIndex = 47;
            this.ownerrecivedpaymentbackbutton.Text = "Back";
            this.ownerrecivedpaymentbackbutton.UseVisualStyleBackColor = false;
            this.ownerrecivedpaymentbackbutton.Click += new System.EventHandler(this.ownerrecivedpaymentbackbutton_Click);
            // 
            // TenantPaymentDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 503);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.paymentH0istorydataGridView);
            this.Controls.Add(this.tenantpaymentpaymenttypecombobox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ownerrecivedpaymentcashentrybutton);
            this.Controls.Add(this.ownerrecivedpaymentbackbutton);
            this.Name = "TenantPaymentDetails";
            this.Text = "TenantPaymentDetails";
            this.Load += new System.EventHandler(this.TenantPaymentDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.paymentH0istorydataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView paymentH0istorydataGridView;
        private System.Windows.Forms.ComboBox tenantpaymentpaymenttypecombobox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ownerrecivedpaymentcashentrybutton;
        private System.Windows.Forms.Button ownerrecivedpaymentbackbutton;
    }
}