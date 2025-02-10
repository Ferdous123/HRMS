using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuildingManagementSystem
{
    public partial class ManagerPaymentDetails : Form
    {
        private string userName;
        private int managerId;
        private static readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
        SqlConnection con = new SqlConnection(connectionString);

        private Dictionary<int, string> houseDictionary = new Dictionary<int, string>();
        private Dictionary<int, string> flatDictionary = new Dictionary<int, string>();
        private Dictionary<int, string> tenantDictionary = new Dictionary<int, string>();

        public ManagerPaymentDetails(string username)
        {
            InitializeComponent();
            this.userName = username;
            LoadManagerId();
            PopulateHouseComboBox();
            PopulatePaymentTypeComboBox();
        }

        private void LoadManagerId()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT manager_Id FROM ManagerTable WHERE username = @username", conn))
                {
                    cmd.Parameters.AddWithValue("@username", userName);
                    managerId = (int)cmd.ExecuteScalar();
                }
            }
        }

        private void PopulateHouseComboBox()
        {
            managerpaymentdetailshousecombobox.Items.Clear();
            managerpaymentdetailshousecombobox.Items.Add("All");
            houseDictionary.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT h.house_id, h.house_num FROM ManagerHouseTable m JOIN HouseTable h ON m.house_id = h.house_Id WHERE m.manager_id = @managerId", conn))
                {
                    cmd.Parameters.AddWithValue("@managerId", managerId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int houseId = (int)reader["house_id"];
                            string houseNum = reader["house_num"].ToString();
                            houseDictionary[houseId] = houseNum;
                            managerpaymentdetailshousecombobox.Items.Add(houseNum);
                        }
                    }
                }
            }

            managerpaymentdetailshousecombobox.SelectedIndex = 0;
        }

        private void PopulateFlatComboBox(int houseId)
        {
            managerpaymentdetailsflatcombobox.Items.Clear();
            managerpaymentdetailsflatcombobox.Items.Add("All");
            flatDictionary.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT f.flat_id, f.flat_designation FROM HouseFlatTable h JOIN FlatTable f ON h.flat_id = f.flat_Id WHERE h.house_id = @houseId", conn))
                {
                    cmd.Parameters.AddWithValue("@houseId", houseId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int flatId = (int)reader["flat_id"];
                            string flatDesignation = reader["flat_designation"].ToString();
                            flatDictionary[flatId] = flatDesignation;
                            managerpaymentdetailsflatcombobox.Items.Add(flatDesignation);
                        }
                    }
                }
            }

            managerpaymentdetailsflatcombobox.SelectedIndex = 0;
        }


        private void PopulateTenantComboBox(int flatId)
        {
            managerpaymentdetailstenantcombobox.Items.Clear();
            managerpaymentdetailstenantcombobox.Items.Add("All");
            tenantDictionary.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT t.tenant_id, t.name FROM FlatOccupationTable fo JOIN TenantTable t ON fo.tenant_id = t.tenant_Id WHERE fo.flat_id = @flatId", conn))
                {
                    cmd.Parameters.AddWithValue("@flatId", flatId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int tenantId = (int)reader["tenant_id"];
                            string tenantName = reader["name"].ToString();
                            tenantDictionary[tenantId] = tenantName;
                            managerpaymentdetailstenantcombobox.Items.Add(tenantName);
                        }
                    }
                }
            }

            managerpaymentdetailstenantcombobox.SelectedIndex = 0;
        }

        private void PopulatePaymentTypeComboBox()
        {
            managerpaymentdetailspaymenttypecombobox.Items.Clear();
            managerpaymentdetailspaymenttypecombobox.Items.Add("All");
            managerpaymentdetailspaymenttypecombobox.Items.Add("Cash");
            managerpaymentdetailspaymenttypecombobox.Items.Add("Online");
            managerpaymentdetailspaymenttypecombobox.SelectedIndex = 0;
        }

        private void FilterPayments()
        {
            string houseFilter = managerpaymentdetailshousecombobox.SelectedItem?.ToString() ?? "All";
            string flatFilter = managerpaymentdetailsflatcombobox.SelectedItem?.ToString() ?? "All";
            string tenantFilter = managerpaymentdetailstenantcombobox.SelectedItem?.ToString() ?? "All";
            string paymentTypeFilter = managerpaymentdetailspaymenttypecombobox.SelectedItem?.ToString() ?? "All";

            string query = "SELECT p.* FROM PaymentTable p " +
                           "JOIN TenantTable t ON p.payment_by = t.tenant_Id " +
                           "JOIN FlatOccupationTable fo ON t.tenant_Id = fo.tenant_id " +
                           "JOIN FlatTable f ON fo.flat_id = f.flat_Id " +
                           "JOIN HouseFlatTable h ON f.flat_Id = h.flat_id WHERE 1=1";

            if (houseFilter != "All")
            {
                int houseId = houseDictionary.FirstOrDefault(x => x.Value == houseFilter).Key;
                query += " AND h.house_id = @houseId";
            }
            if (flatFilter != "All")
            {
                int flatId = flatDictionary.FirstOrDefault(x => x.Value == flatFilter).Key;
                query += " AND f.flat_Id = @flatId";
            }
            if (tenantFilter != "All")
            {
                int tenantId = tenantDictionary.FirstOrDefault(x => x.Value == tenantFilter).Key;
                query += " AND p.payment_by = @tenantId";
            }
            if (paymentTypeFilter != "All")
            {
                query += " AND p.payment_type = @paymentType";
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (houseFilter != "All")
                    {
                        int houseId = houseDictionary.FirstOrDefault(x => x.Value == houseFilter).Key;
                        cmd.Parameters.AddWithValue("@houseId", houseId);
                    }
                    if (flatFilter != "All")
                    {
                        int flatId = flatDictionary.FirstOrDefault(x => x.Value == flatFilter).Key;
                        cmd.Parameters.AddWithValue("@flatId", flatId);
                    }
                    if (tenantFilter != "All")
                    {
                        int tenantId = tenantDictionary.FirstOrDefault(x => x.Value == tenantFilter).Key;
                        cmd.Parameters.AddWithValue("@tenantId", tenantId);
                    }
                    if (paymentTypeFilter != "All")
                    {
                        cmd.Parameters.AddWithValue("@paymentType", paymentTypeFilter);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        paymentHistorydataGridView.DataSource = dataTable;
                    }
                }
            }
        }

        private void managerpaymentdetailsbackbutton_Click(object sender, EventArgs e)
        {
            ManagerDashBoard managerDashBoard = new ManagerDashBoard(userName);
            managerDashBoard.Show();
            this.Hide();
        }

        private void managerpaymentdetailscashentrybutton_Click(object sender, EventArgs e)
        {
            ManagerPaymentDetailsCashEntry managerPaymentDetailsCashEntry = new ManagerPaymentDetailsCashEntry(userName);
            managerPaymentDetailsCashEntry.Show();
            this.Hide();
        }

        private void ManagerPaymentDetails_Load(object sender, EventArgs e)
        {
            FilterPayments();
        }

        private void managerpaymentdetailshousecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (managerpaymentdetailshousecombobox.SelectedItem.ToString() != "All")
            {
                int houseId = houseDictionary.FirstOrDefault(x => x.Value == managerpaymentdetailshousecombobox.SelectedItem.ToString()).Key;
                PopulateFlatComboBox(houseId);
            }
            else
            {
                managerpaymentdetailsflatcombobox.Items.Clear();
                managerpaymentdetailsflatcombobox.Items.Add("All");
                managerpaymentdetailsflatcombobox.SelectedIndex = 0;
            }
            FilterPayments();
        }

        private void managerpaymentdetailspaymenttypecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterPayments();
        }

        private void managerpaymentdetailsflatcombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (managerpaymentdetailsflatcombobox.SelectedItem.ToString() != "All")
            {
                int flatId = flatDictionary.FirstOrDefault(x => x.Value == managerpaymentdetailsflatcombobox.SelectedItem.ToString()).Key;
                PopulateTenantComboBox(flatId);
            }
            else
            {
                managerpaymentdetailstenantcombobox.Items.Clear();
                managerpaymentdetailstenantcombobox.Items.Add("All");
                managerpaymentdetailstenantcombobox.SelectedIndex = 0;
            }
            FilterPayments();
        }

        private void managerpaymentdetailstenantcombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterPayments();
        }

        private void paymentHistorydataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
