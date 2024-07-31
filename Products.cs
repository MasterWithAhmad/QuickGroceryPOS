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
    public partial class Products : Form
    {
        string connectionString = "Data Source=.;Initial Catalog=GroceryPOS;Integrated Security=True;Encrypt=False";
        public Products()
        {
            InitializeComponent();
            LoadProducts();
            SetupListView();
            DisableFormMove();
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

        private void SetupListView()
        {
            lvProducts.View = View.Details;
            lvProducts.Columns.Add("Product ID", 200);
            lvProducts.Columns.Add("Product Name", 330);
            lvProducts.Columns.Add("Price", 300);
            lvProducts.Columns.Add("Quantity", 300);
        }

        private void LoadProducts()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Products";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                lvProducts.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["ProductId"].ToString());
                    item.SubItems.Add(row["ProductName"].ToString());
                    item.SubItems.Add("$" + Convert.ToDecimal(row["Price"]).ToString("0.00"));
                    item.SubItems.Add(row["Quantity"].ToString());
                    lvProducts.Items.Add(item);
                }
            }
        }

        private void ClearForm()
        {
            txtProductId.Text = "";
            txtProductName.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
            btnSave.Text = "Save";
            txtProductName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query;
                if (string.IsNullOrEmpty(txtProductId.Text)) // Insert new product
                {
                    query = "INSERT INTO Products (ProductName, Price, Quantity) VALUES (@ProductName, @Price, @Quantity)";
                }
                else // Update existing product
                {
                    query = "UPDATE Products SET ProductName=@ProductName, Price=@Price, Quantity=@Quantity WHERE ProductId=@ProductId";
                }
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                    cmd.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text));
                    cmd.Parameters.AddWithValue("@Quantity", int.Parse(txtQuantity.Text));
                    if (!string.IsNullOrEmpty(txtProductId.Text))
                    {
                        cmd.Parameters.AddWithValue("@ProductId", int.Parse(txtProductId.Text));
                    }
                    cmd.ExecuteNonQuery();
                }
                LoadProducts();
                ClearForm();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProductName.Text) || !string.IsNullOrEmpty(txtPrice.Text) || !string.IsNullOrEmpty(txtQuantity.Text))
            {
                DialogResult result = MessageBox.Show("Are you sure you want to cancel?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ClearForm();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Products WHERE ProductName LIKE @SearchText";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@SearchText", "%" + txtSearch.Text + "%");
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                lvProducts.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["ProductId"].ToString());
                    item.SubItems.Add(row["ProductName"].ToString());
                    item.SubItems.Add("$" + Convert.ToDecimal(row["Price"]).ToString("0.00"));
                    item.SubItems.Add(row["Quantity"].ToString());
                    lvProducts.Items.Add(item);
                }
            }
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sortBy = cmbSort.SelectedItem.ToString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = $"SELECT * FROM Products ORDER BY {sortBy}";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                lvProducts.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["ProductId"].ToString());
                    item.SubItems.Add(row["ProductName"].ToString());
                    item.SubItems.Add("$" + Convert.ToDecimal(row["Price"]).ToString("0.00"));
                    item.SubItems.Add(row["Quantity"].ToString());
                    lvProducts.Items.Add(item);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvProducts.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected product?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ListViewItem item = lvProducts.SelectedItems[0];
                    int productId = int.Parse(item.SubItems[0].Text);
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Products WHERE ProductId=@ProductId";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@ProductId", productId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadProducts();
                }
            }
        }

        private void lvProducts_DoubleClick(object sender, EventArgs e)
        {
            if (lvProducts.SelectedItems.Count > 0)
            {
                ListViewItem item = lvProducts.SelectedItems[0];
                txtProductId.Text = item.SubItems[0].Text;
                txtProductName.Text = item.SubItems[1].Text;
                txtPrice.Text = item.SubItems[2].Text.Replace("$", "");
                txtQuantity.Text = item.SubItems[3].Text;
                //btnSave.Text = "Save Changes";
            }
        }
    }
}
