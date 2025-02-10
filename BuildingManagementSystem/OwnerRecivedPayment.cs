using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace BuildingManagementSystem
{
    public partial class OwnerRecivedPayment : Form
    {
        private string userName;
        private int ownerId;
        private static readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
        SqlConnection con = new SqlConnection(connectionString);

        private Dictionary<int, string> houseDictionary = new Dictionary<int, string>();
        private Dictionary<int, string> flatDictionary = new Dictionary<int, string>();
        private Dictionary<int, string> tenantDictionary = new Dictionary<int, string>();

        public OwnerRecivedPayment(string userName)
        {
            InitializeComponent();
            this.userName = userName;
            LoadOwnerId();
            PopulateHouseComboBox();
            PopulatePaymentTypeComboBox();
        }

        private void LoadOwnerId()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT owner_Id FROM OwnerTable WHERE username = @username", conn))
                {
                    cmd.Parameters.AddWithValue("@username", userName);
                    ownerId = (int)cmd.ExecuteScalar();
                }
            }
        }

        private void PopulateHouseComboBox()
        {
            ownerrecivedpaymenthousecombobox.Items.Clear();
            ownerrecivedpaymenthousecombobox.Items.Add("All");
            houseDictionary.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT h.house_id, h.house_num FROM OwnerHouseTable o JOIN HouseTable h ON o.house_id = h.house_Id WHERE o.owner_id = @ownerId", conn))
                {
                    cmd.Parameters.AddWithValue("@ownerId", ownerId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int houseId = (int)reader["house_id"];
                            string houseNum = reader["house_num"].ToString();
                            houseDictionary[houseId] = houseNum;
                            ownerrecivedpaymenthousecombobox.Items.Add(houseNum);
                        }
                    }
                }
            }

            ownerrecivedpaymenthousecombobox.SelectedIndex = 0;
        }

        private void PopulateFlatComboBox(int houseId)
        {
            ownerrecivedpaymentflatcombobox.Items.Clear();
            ownerrecivedpaymentflatcombobox.Items.Add("All");
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
                            ownerrecivedpaymentflatcombobox.Items.Add(flatDesignation);
                        }
                    }
                }
            }

            ownerrecivedpaymentflatcombobox.SelectedIndex = 0;
        }

        private void PopulateTenantComboBox(int flatId)
        {
            ownerrecivedpaymenttenantcombobox.Items.Clear();
            ownerrecivedpaymenttenantcombobox.Items.Add("All");
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
                            ownerrecivedpaymenttenantcombobox.Items.Add(tenantName);
                        }
                    }
                }
            }

            ownerrecivedpaymenttenantcombobox.SelectedIndex = 0;
        }

        private void PopulatePaymentTypeComboBox()
        {
            ownerrecivedpaymentpaymenttypecombobox.Items.Clear();
            ownerrecivedpaymentpaymenttypecombobox.Items.Add("All");
            ownerrecivedpaymentpaymenttypecombobox.Items.Add("Cash");
            ownerrecivedpaymentpaymenttypecombobox.Items.Add("Online");
            ownerrecivedpaymentpaymenttypecombobox.SelectedIndex = 0;
        }

        private void FilterPayments()
        {
            string houseFilter = ownerrecivedpaymenthousecombobox.SelectedItem?.ToString() ?? "All";
            string flatFilter = ownerrecivedpaymentflatcombobox.SelectedItem?.ToString() ?? "All";
            string tenantFilter = ownerrecivedpaymenttenantcombobox.SelectedItem?.ToString() ?? "All";
            string paymentTypeFilter = ownerrecivedpaymentpaymenttypecombobox.SelectedItem?.ToString() ?? "All";

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

        private void ownerrecivedpaymenthousecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ownerrecivedpaymenthousecombobox.SelectedItem.ToString() != "All")
            {
                int houseId = houseDictionary.FirstOrDefault(x => x.Value == ownerrecivedpaymenthousecombobox.SelectedItem.ToString()).Key;
                PopulateFlatComboBox(houseId);
            }
            else
            {
                ownerrecivedpaymentflatcombobox.Items.Clear();
                ownerrecivedpaymentflatcombobox.Items.Add("All");
                ownerrecivedpaymentflatcombobox.SelectedIndex = 0;
            }
            FilterPayments();
        }

        private void ownerrecivedpaymentflatcombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ownerrecivedpaymentflatcombobox.SelectedItem.ToString() != "All")
            {
                int flatId = flatDictionary.FirstOrDefault(x => x.Value == ownerrecivedpaymentflatcombobox.SelectedItem.ToString()).Key;
                PopulateTenantComboBox(flatId);
            }
            else
            {
                ownerrecivedpaymenttenantcombobox.Items.Clear();
                ownerrecivedpaymenttenantcombobox.Items.Add("All");
                ownerrecivedpaymenttenantcombobox.SelectedIndex = 0;
            }
            FilterPayments();
        }

        private void ownerrecivedpaymenttenantcombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterPayments();
        }

        private void ownerrecivedpaymentpaymenttypecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterPayments();
        }

        private void ownerrecivedpaymentbackbutton_Click(object sender, EventArgs e)
        {
            OwnerDashboard ownerDashboard = new OwnerDashboard(userName);
            ownerDashboard.Show();
            this.Hide();
        }

        private void ownerrecivedpaymentcashentrybutton_Click(object sender, EventArgs e)
        {
            OwnerRecivedPaymentCashEntry ownerRecivedPaymentCashEntry = new OwnerRecivedPaymentCashEntry(userName);
            ownerRecivedPaymentCashEntry.Show();
            this.Hide();
        }

        private void OwnerRecivedPayment_Load(object sender, EventArgs e)
        {
            FilterPayments();
        }

        private void paymentHistorydataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
