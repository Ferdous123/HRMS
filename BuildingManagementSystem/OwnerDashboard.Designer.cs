namespace BuildingManagementSystem
{
    partial class OwnerDashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ownernamelabel = new System.Windows.Forms.Label();
            this.ownerusernamlabel = new System.Windows.Forms.Label();
            this.ownerratinglabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.profilebutton = new System.Windows.Forms.Button();
            this.managerbutton = new System.Windows.Forms.Button();
            this.tenantsbutton = new System.Windows.Forms.Button();
            this.dashboardbutton = new System.Windows.Forms.Button();
            this.ownerlogoutbutton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.occupiedflatsbutton = new System.Windows.Forms.Button();
            this.recivedpaymentbutton = new System.Windows.Forms.Button();
            this.electricbillentrybutton = new System.Windows.Forms.Button();
            this.logbutton = new System.Windows.Forms.Button();
            this.noticebutton = new System.Windows.Forms.Button();
            this.tenantapplicationbutton = new System.Windows.Forms.Button();
            this.flatfinencialbutton = new System.Windows.Forms.Button();
            this.ownerprofilepanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.manageflatsbutton = new System.Windows.Forms.Button();
            this.managehousesbutton = new System.Windows.Forms.Button();
            this.changepasswordbutton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.piechart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.barchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            this.ownerprofilepanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.piechart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barchart)).BeginInit();
            this.SuspendLayout();
            // 
            // ownernamelabel
            // 
            this.ownernamelabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ownernamelabel.AutoSize = true;
            this.ownernamelabel.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ownernamelabel.Location = new System.Drawing.Point(12, 9);
            this.ownernamelabel.Name = "ownernamelabel";
            this.ownernamelabel.Size = new System.Drawing.Size(68, 21);
            this.ownernamelabel.TabIndex = 20;
            this.ownernamelabel.Text = "Name:";
            // 
            // ownerusernamlabel
            // 
            this.ownerusernamlabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ownerusernamlabel.AutoSize = true;
            this.ownerusernamlabel.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ownerusernamlabel.Location = new System.Drawing.Point(12, 39);
            this.ownerusernamlabel.Name = "ownerusernamlabel";
            this.ownerusernamlabel.Size = new System.Drawing.Size(107, 21);
            this.ownerusernamlabel.TabIndex = 21;
            this.ownerusernamlabel.Text = "Username:";
            // 
            // ownerratinglabel
            // 
            this.ownerratinglabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ownerratinglabel.AutoSize = true;
            this.ownerratinglabel.Enabled = false;
            this.ownerratinglabel.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ownerratinglabel.Location = new System.Drawing.Point(12, 70);
            this.ownerratinglabel.Name = "ownerratinglabel";
            this.ownerratinglabel.Size = new System.Drawing.Size(78, 21);
            this.ownerratinglabel.TabIndex = 22;
            this.ownerratinglabel.Text = "Rating :";
            this.ownerratinglabel.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.panel1.Controls.Add(this.profilebutton);
            this.panel1.Controls.Add(this.managerbutton);
            this.panel1.Controls.Add(this.tenantsbutton);
            this.panel1.Controls.Add(this.dashboardbutton);
            this.panel1.Location = new System.Drawing.Point(0, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 411);
            this.panel1.TabIndex = 23;
            // 
            // profilebutton
            // 
            this.profilebutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.profilebutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.profilebutton.FlatAppearance.BorderSize = 2;
            this.profilebutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.profilebutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profilebutton.ForeColor = System.Drawing.Color.White;
            this.profilebutton.Location = new System.Drawing.Point(30, 307);
            this.profilebutton.Name = "profilebutton";
            this.profilebutton.Size = new System.Drawing.Size(131, 38);
            this.profilebutton.TabIndex = 25;
            this.profilebutton.Text = "Profile";
            this.profilebutton.UseVisualStyleBackColor = false;
            this.profilebutton.Click += new System.EventHandler(this.profilebutton_Click);
            // 
            // managerbutton
            // 
            this.managerbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.managerbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.managerbutton.FlatAppearance.BorderSize = 2;
            this.managerbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.managerbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managerbutton.ForeColor = System.Drawing.Color.White;
            this.managerbutton.Location = new System.Drawing.Point(30, 215);
            this.managerbutton.Name = "managerbutton";
            this.managerbutton.Size = new System.Drawing.Size(131, 38);
            this.managerbutton.TabIndex = 25;
            this.managerbutton.Text = "Manager";
            this.managerbutton.UseVisualStyleBackColor = false;
            this.managerbutton.Click += new System.EventHandler(this.managerbutton_Click);
            // 
            // tenantsbutton
            // 
            this.tenantsbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tenantsbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.tenantsbutton.FlatAppearance.BorderSize = 2;
            this.tenantsbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tenantsbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenantsbutton.ForeColor = System.Drawing.Color.White;
            this.tenantsbutton.Location = new System.Drawing.Point(30, 128);
            this.tenantsbutton.Name = "tenantsbutton";
            this.tenantsbutton.Size = new System.Drawing.Size(131, 38);
            this.tenantsbutton.TabIndex = 25;
            this.tenantsbutton.Text = "Tenants";
            this.tenantsbutton.UseVisualStyleBackColor = false;
            this.tenantsbutton.Click += new System.EventHandler(this.tenantsbutton_Click);
            // 
            // dashboardbutton
            // 
            this.dashboardbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dashboardbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.dashboardbutton.FlatAppearance.BorderSize = 2;
            this.dashboardbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardbutton.ForeColor = System.Drawing.Color.White;
            this.dashboardbutton.Location = new System.Drawing.Point(30, 42);
            this.dashboardbutton.Name = "dashboardbutton";
            this.dashboardbutton.Size = new System.Drawing.Size(141, 47);
            this.dashboardbutton.TabIndex = 25;
            this.dashboardbutton.Text = "Dashboard";
            this.dashboardbutton.UseVisualStyleBackColor = false;
            this.dashboardbutton.Click += new System.EventHandler(this.dashboardbutton_Click);
            // 
            // ownerlogoutbutton
            // 
            this.ownerlogoutbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ownerlogoutbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.ownerlogoutbutton.FlatAppearance.BorderSize = 0;
            this.ownerlogoutbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ownerlogoutbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ownerlogoutbutton.ForeColor = System.Drawing.Color.White;
            this.ownerlogoutbutton.Location = new System.Drawing.Point(809, 12);
            this.ownerlogoutbutton.Name = "ownerlogoutbutton";
            this.ownerlogoutbutton.Size = new System.Drawing.Size(131, 38);
            this.ownerlogoutbutton.TabIndex = 24;
            this.ownerlogoutbutton.Text = "Logout";
            this.ownerlogoutbutton.UseVisualStyleBackColor = false;
            this.ownerlogoutbutton.Click += new System.EventHandler(this.ownerlogoutbutton_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(285, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 21);
            this.label3.TabIndex = 27;
            this.label3.Text = "Rent Collection trend";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(685, 310);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 21);
            this.label4.TabIndex = 28;
            this.label4.Text = "Dues Distribution";
            this.label4.Visible = false;
            // 
            // occupiedflatsbutton
            // 
            this.occupiedflatsbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.occupiedflatsbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.occupiedflatsbutton.FlatAppearance.BorderSize = 0;
            this.occupiedflatsbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.occupiedflatsbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.occupiedflatsbutton.ForeColor = System.Drawing.Color.White;
            this.occupiedflatsbutton.Location = new System.Drawing.Point(242, 150);
            this.occupiedflatsbutton.Name = "occupiedflatsbutton";
            this.occupiedflatsbutton.Size = new System.Drawing.Size(141, 59);
            this.occupiedflatsbutton.TabIndex = 29;
            this.occupiedflatsbutton.Text = "Occupied Flats";
            this.occupiedflatsbutton.UseVisualStyleBackColor = false;
            this.occupiedflatsbutton.Click += new System.EventHandler(this.occupiedflatsbutton_Click);
            // 
            // recivedpaymentbutton
            // 
            this.recivedpaymentbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.recivedpaymentbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.recivedpaymentbutton.FlatAppearance.BorderSize = 0;
            this.recivedpaymentbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recivedpaymentbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recivedpaymentbutton.ForeColor = System.Drawing.Color.White;
            this.recivedpaymentbutton.Location = new System.Drawing.Point(425, 151);
            this.recivedpaymentbutton.Name = "recivedpaymentbutton";
            this.recivedpaymentbutton.Size = new System.Drawing.Size(141, 59);
            this.recivedpaymentbutton.TabIndex = 30;
            this.recivedpaymentbutton.Text = "Received Payment";
            this.recivedpaymentbutton.UseVisualStyleBackColor = false;
            this.recivedpaymentbutton.Click += new System.EventHandler(this.recivedpaymentbutton_Click);
            // 
            // electricbillentrybutton
            // 
            this.electricbillentrybutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.electricbillentrybutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.electricbillentrybutton.FlatAppearance.BorderSize = 0;
            this.electricbillentrybutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.electricbillentrybutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.electricbillentrybutton.ForeColor = System.Drawing.Color.White;
            this.electricbillentrybutton.Location = new System.Drawing.Point(610, 153);
            this.electricbillentrybutton.Name = "electricbillentrybutton";
            this.electricbillentrybutton.Size = new System.Drawing.Size(141, 59);
            this.electricbillentrybutton.TabIndex = 31;
            this.electricbillentrybutton.Text = "Electric Bill Entry";
            this.electricbillentrybutton.UseVisualStyleBackColor = false;
            this.electricbillentrybutton.Click += new System.EventHandler(this.electricbillentrybutton_Click);
            // 
            // logbutton
            // 
            this.logbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.logbutton.FlatAppearance.BorderSize = 0;
            this.logbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logbutton.ForeColor = System.Drawing.Color.White;
            this.logbutton.Location = new System.Drawing.Point(793, 150);
            this.logbutton.Name = "logbutton";
            this.logbutton.Size = new System.Drawing.Size(141, 59);
            this.logbutton.TabIndex = 32;
            this.logbutton.Text = "Log";
            this.logbutton.UseVisualStyleBackColor = false;
            this.logbutton.Click += new System.EventHandler(this.logbutton_Click);
            // 
            // noticebutton
            // 
            this.noticebutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.noticebutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.noticebutton.FlatAppearance.BorderSize = 0;
            this.noticebutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.noticebutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noticebutton.ForeColor = System.Drawing.Color.White;
            this.noticebutton.Location = new System.Drawing.Point(301, 287);
            this.noticebutton.Name = "noticebutton";
            this.noticebutton.Size = new System.Drawing.Size(141, 59);
            this.noticebutton.TabIndex = 33;
            this.noticebutton.Text = "Notice";
            this.noticebutton.UseVisualStyleBackColor = false;
            this.noticebutton.Click += new System.EventHandler(this.noticebutton_Click);
            // 
            // tenantapplicationbutton
            // 
            this.tenantapplicationbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tenantapplicationbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.tenantapplicationbutton.FlatAppearance.BorderSize = 0;
            this.tenantapplicationbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tenantapplicationbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenantapplicationbutton.ForeColor = System.Drawing.Color.White;
            this.tenantapplicationbutton.Location = new System.Drawing.Point(510, 287);
            this.tenantapplicationbutton.Name = "tenantapplicationbutton";
            this.tenantapplicationbutton.Size = new System.Drawing.Size(141, 59);
            this.tenantapplicationbutton.TabIndex = 34;
            this.tenantapplicationbutton.Text = "Tenant Application";
            this.tenantapplicationbutton.UseVisualStyleBackColor = false;
            // 
            // flatfinencialbutton
            // 
            this.flatfinencialbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flatfinencialbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.flatfinencialbutton.FlatAppearance.BorderSize = 0;
            this.flatfinencialbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flatfinencialbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatfinencialbutton.ForeColor = System.Drawing.Color.White;
            this.flatfinencialbutton.Location = new System.Drawing.Point(708, 287);
            this.flatfinencialbutton.Name = "flatfinencialbutton";
            this.flatfinencialbutton.Size = new System.Drawing.Size(141, 59);
            this.flatfinencialbutton.TabIndex = 35;
            this.flatfinencialbutton.Text = "Flat Financials";
            this.flatfinencialbutton.UseVisualStyleBackColor = false;
            this.flatfinencialbutton.Click += new System.EventHandler(this.flatfinencialbutton_Click);
            // 
            // ownerprofilepanel
            // 
            this.ownerprofilepanel.Controls.Add(this.pictureBox1);
            this.ownerprofilepanel.Controls.Add(this.manageflatsbutton);
            this.ownerprofilepanel.Controls.Add(this.managehousesbutton);
            this.ownerprofilepanel.Controls.Add(this.changepasswordbutton);
            this.ownerprofilepanel.Controls.Add(this.label8);
            this.ownerprofilepanel.Controls.Add(this.label7);
            this.ownerprofilepanel.Controls.Add(this.label6);
            this.ownerprofilepanel.Controls.Add(this.label5);
            this.ownerprofilepanel.Location = new System.Drawing.Point(209, 95);
            this.ownerprofilepanel.Name = "ownerprofilepanel";
            this.ownerprofilepanel.Size = new System.Drawing.Size(731, 396);
            this.ownerprofilepanel.TabIndex = 36;
            this.ownerprofilepanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ownerprofilepanel_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BuildingManagementSystem.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(545, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // manageflatsbutton
            // 
            this.manageflatsbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.manageflatsbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.manageflatsbutton.FlatAppearance.BorderSize = 0;
            this.manageflatsbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manageflatsbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageflatsbutton.ForeColor = System.Drawing.Color.White;
            this.manageflatsbutton.Location = new System.Drawing.Point(499, 226);
            this.manageflatsbutton.Name = "manageflatsbutton";
            this.manageflatsbutton.Size = new System.Drawing.Size(150, 59);
            this.manageflatsbutton.TabIndex = 27;
            this.manageflatsbutton.Text = "Manage Flats";
            this.manageflatsbutton.UseVisualStyleBackColor = false;
            this.manageflatsbutton.Click += new System.EventHandler(this.manageflatsbutton_Click);
            // 
            // managehousesbutton
            // 
            this.managehousesbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.managehousesbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.managehousesbutton.FlatAppearance.BorderSize = 0;
            this.managehousesbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.managehousesbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managehousesbutton.ForeColor = System.Drawing.Color.White;
            this.managehousesbutton.Location = new System.Drawing.Point(83, 226);
            this.managehousesbutton.Name = "managehousesbutton";
            this.managehousesbutton.Size = new System.Drawing.Size(150, 59);
            this.managehousesbutton.TabIndex = 26;
            this.managehousesbutton.Text = "Manage Houses";
            this.managehousesbutton.UseVisualStyleBackColor = false;
            this.managehousesbutton.Click += new System.EventHandler(this.managehousesbutton_Click);
            // 
            // changepasswordbutton
            // 
            this.changepasswordbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.changepasswordbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(14)))), ((int)(((byte)(28)))));
            this.changepasswordbutton.FlatAppearance.BorderSize = 0;
            this.changepasswordbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changepasswordbutton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changepasswordbutton.ForeColor = System.Drawing.Color.White;
            this.changepasswordbutton.Location = new System.Drawing.Point(292, 226);
            this.changepasswordbutton.Name = "changepasswordbutton";
            this.changepasswordbutton.Size = new System.Drawing.Size(150, 59);
            this.changepasswordbutton.TabIndex = 25;
            this.changepasswordbutton.Text = "Change Password";
            this.changepasswordbutton.UseVisualStyleBackColor = false;
            this.changepasswordbutton.Click += new System.EventHandler(this.changepasswordbutton_Click);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(60, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 21);
            this.label8.TabIndex = 24;
            this.label8.Text = "Phone Number :";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(60, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 21);
            this.label7.TabIndex = 23;
            this.label7.Text = "Email : ";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(60, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 21);
            this.label6.TabIndex = 22;
            this.label6.Text = "User Name :";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(60, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 21);
            this.label5.TabIndex = 21;
            this.label5.Text = "Name :";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // piechart
            // 
            chartArea1.Name = "ChartArea1";
            this.piechart.ChartAreas.Add(chartArea1);
            this.piechart.Enabled = false;
            legend1.Name = "Legend1";
            this.piechart.Legends.Add(legend1);
            this.piechart.Location = new System.Drawing.Point(643, 339);
            this.piechart.Name = "piechart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.piechart.Series.Add(series1);
            this.piechart.Size = new System.Drawing.Size(248, 131);
            this.piechart.TabIndex = 1;
            this.piechart.Text = "chart2";
            this.piechart.Visible = false;
            // 
            // barchart
            // 
            chartArea2.Name = "ChartArea1";
            this.barchart.ChartAreas.Add(chartArea2);
            this.barchart.Enabled = false;
            legend2.Name = "Legend1";
            this.barchart.Legends.Add(legend2);
            this.barchart.Location = new System.Drawing.Point(264, 339);
            this.barchart.Name = "barchart";
            this.barchart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.barchart.Series.Add(series2);
            this.barchart.Size = new System.Drawing.Size(245, 128);
            this.barchart.TabIndex = 0;
            this.barchart.Text = "chart1";
            this.barchart.Visible = false;
            this.barchart.Click += new System.EventHandler(this.barchart_Click);
            // 
            // OwnerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(952, 503);
            this.Controls.Add(this.piechart);
            this.Controls.Add(this.barchart);
            this.Controls.Add(this.ownerprofilepanel);
            this.Controls.Add(this.flatfinencialbutton);
            this.Controls.Add(this.tenantapplicationbutton);
            this.Controls.Add(this.noticebutton);
            this.Controls.Add(this.logbutton);
            this.Controls.Add(this.electricbillentrybutton);
            this.Controls.Add(this.recivedpaymentbutton);
            this.Controls.Add(this.occupiedflatsbutton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ownerlogoutbutton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ownerratinglabel);
            this.Controls.Add(this.ownerusernamlabel);
            this.Controls.Add(this.ownernamelabel);
            this.Name = "OwnerDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OwnerDashboard";
            this.Load += new System.EventHandler(this.OwnerDashboard_Load);
            this.panel1.ResumeLayout(false);
            this.ownerprofilepanel.ResumeLayout(false);
            this.ownerprofilepanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.piechart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barchart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ownernamelabel;
        private System.Windows.Forms.Label ownerusernamlabel;
        private System.Windows.Forms.Label ownerratinglabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ownerlogoutbutton;
        private System.Windows.Forms.Button tenantsbutton;
        private System.Windows.Forms.Button dashboardbutton;
        private System.Windows.Forms.Button profilebutton;
        private System.Windows.Forms.Button managerbutton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button occupiedflatsbutton;
        private System.Windows.Forms.Button recivedpaymentbutton;
        private System.Windows.Forms.Button electricbillentrybutton;
        private System.Windows.Forms.Button logbutton;
        private System.Windows.Forms.Button noticebutton;
        private System.Windows.Forms.Button tenantapplicationbutton;
        private System.Windows.Forms.Button flatfinencialbutton;
        private System.Windows.Forms.Panel ownerprofilepanel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button manageflatsbutton;
        private System.Windows.Forms.Button managehousesbutton;
        private System.Windows.Forms.Button changepasswordbutton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart piechart;
        private System.Windows.Forms.DataVisualization.Charting.Chart barchart;
    }
}