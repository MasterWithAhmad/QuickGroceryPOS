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

namespace QuickGrocery
{
    public partial class OrderHistory : Form
    {
        string connectionString = "Data Source=.;Initial Catalog=GroceryPOS;Integrated Security=True;Encrypt=False";
        private int userId;
        public OrderHistory(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadOrderHistory();
            SetupOrderHistoryListView();
            DisableFormMove();
            cmbSort.SelectedIndex = 0; // Default sorting by Order ID
        }

        private void DisableFormMove()
        {
            this.Load += (s, e) =>
            {
                // Disable the ability to move the form
                var cp = CreateParams;
                cp.Style &= ~0x00040000; // WS_SYSMENU
                                         //this.CreateParams = cp;
            };
        }

        // Override WndProc to ignore the form's move messages
        protected override void WndProc(ref Message m)
        {
            const int WM_NCLBUTTONDOWN = 0x00A1;
            const int HTCAPTION = 0x0002;

            if (m.Msg == WM_NCLBUTTONDOWN && m.WParam.ToInt32() == HTCAPTION)
            {
                return;
            }
            base.WndProc(ref m);
        }

        private void SetupOrderHistoryListView()
        {
            lvOrderHistory.View = View.Details;
            lvOrderHistory.Columns.Add("Order ID", 250);
            lvOrderHistory.Columns.Add("Total Amount", 355);
            lvOrderHistory.Columns.Add("Payment Method", 300);
            lvOrderHistory.Columns.Add("Order Date", 350);
        }

        private void LoadOrderHistory()
        {
            string sortColumn = "OrderId";
            string sortOrder = "ASC";
            if (cmbSort.SelectedItem != null)
            {
                switch (cmbSort.SelectedItem.ToString())
                {
                    case "Total Amount":
                        sortColumn = "TotalAmount";
                        break;
                    case "Payment Method":
                        sortColumn = "PaymentMethod";
                        break;
                    case "Order Date":
                        sortColumn = "OrderDate";
                        break;
                }
            }

            string query = $@"
                SELECT OrderId, TotalAmount, PaymentMethod, OrderDate 
                FROM Orders 
                WHERE UserId = @UserId 
                AND (OrderId LIKE '%' + @SearchText + '%' 
                OR PaymentMethod LIKE '%' + @SearchText + '%' 
                OR TotalAmount LIKE '%' + @SearchText + '%' 
                OR OrderDate LIKE '%' + @SearchText + '%')
                ORDER BY {sortColumn} {sortOrder}";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@UserId", userId);
                adapter.SelectCommand.Parameters.AddWithValue("@SearchText", txtSearch.Text);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                lvOrderHistory.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["OrderId"].ToString());
                    item.SubItems.Add("$" + Convert.ToDecimal(row["TotalAmount"]).ToString("0.00"));
                    item.SubItems.Add(row["PaymentMethod"].ToString());
                    item.SubItems.Add(Convert.ToDateTime(row["OrderDate"]).ToString("MM/dd/yyyy HH:mm:ss"));

                    lvOrderHistory.Items.Add(item);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadOrderHistory();
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadOrderHistory();
        }
    }
}
