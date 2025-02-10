using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuildingManagementSystem
{
    public partial class ManagerLog : Form
    {
        private string userName;

        public ManagerLog(string username)
        {
            InitializeComponent();
            this.userName = username;
        }

        private void managerlogsbackbutton_Click(object sender, EventArgs e)
        {
            ManagerDashBoard managerDashBoard = new ManagerDashBoard(userName);
            managerDashBoard.Show();
            this.Hide();
        }

        private void ManagerLog_Load(object sender, EventArgs e)
        {

        }
    }
}
