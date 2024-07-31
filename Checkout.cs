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
    public partial class Checkout : Form
    {
        string connectionString = "Data Source=.;Initial Catalog=GroceryPOS;Integrated Security=True;Encrypt=False";
        decimal totalAmount = 0;
        private int userId;
        public Checkout(int userId)
        {
            InitializeComponent();
            SetupCartListView();
            LoadProducts();
            DisableFormMove();
            this.userId = userId;

            // Products
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.ClientSize = new System.Drawing.Size(800, 450);
            ////this.Controls.Add(this.lblTitle);
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            //this.MaximizeBox = false;
            //this.MinimizeBox = true;
            //this.Name = "Products";
            //this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            //this.Text = "Products Management";
            //this.ResumeLayout(false);
            //this.PerformLayout();
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

        private void SetupCartListView()
        {
            lvCart.View = View.Details;
            lvCart.Columns.Add("Product ID", 100);
            lvCart.Columns.Add("Product Name", 150);
            lvCart.Columns.Add("Price", 150);
            lvCart.Columns.Add("Quantity", 100);
            lvCart.Columns.Add("Total", 230);
        }


        private void LoadProducts()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ProductId, ProductName, Price FROM Products";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvProducts.DataSource = dt;
                dgvProducts.Columns["ProductId"].Visible = false;
                dgvProducts.Columns["Price"].DefaultCellStyle.Format = "c"; // Format as currency
            }
        }
        private int GetCurrentUserId()
        {
            // Implementation to get the current user's ID
            // This can be through session management or a login system
            return 1; // Placeholder
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Products WHERE ProductName LIKE @SearchText";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@SearchText", "%" + txtSearchProduct.Text + "%");
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    ListViewItem item = new ListViewItem(row["ProductId"].ToString());
                    item.SubItems.Add(row["ProductName"].ToString());
                    item.SubItems.Add("$" + Convert.ToDecimal(row["Price"]).ToString("0.00"));
                    item.SubItems.Add("1"); // Default quantity
                    item.SubItems.Add("$" + Convert.ToDecimal(row["Price"]).ToString("0.00")); // Total = Price * Quantity

                    lvCart.Items.Add(item);
                    totalAmount += Convert.ToDecimal(row["Price"]);
                    lblTotalAmount.Text = "Total: $" + totalAmount.ToString("0.00");
                }
                else
                {
                    MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (lvCart.SelectedItems.Count > 0)
            {
                ListViewItem item = lvCart.SelectedItems[0];
                decimal itemTotal = Convert.ToDecimal(item.SubItems[4].Text.Replace("$", ""));
                totalAmount -= itemTotal;
                lblTotalAmount.Text = "Total: $" + totalAmount.ToString("0.00");

                lvCart.Items.Remove(item);
            }
        }

        private void btnProcessPayment_Click(object sender, EventArgs e)
        {
            if (lvCart.Items.Count == 0)
            {
                MessageBox.Show("Cart is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string paymentMethod = cmbPaymentMethod.SelectedItem.ToString();
                string query = "INSERT INTO Orders (UserId, TotalAmount, PaymentMethod, OrderDate) OUTPUT INSERTED.OrderId VALUES (@UserId, @TotalAmount, @PaymentMethod, @OrderDate)";
                int orderId;

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                    cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                    orderId = (int)cmd.ExecuteScalar();
                }

                foreach (ListViewItem item in lvCart.Items)
                {
                    query = "INSERT INTO OrderItems (OrderId, ProductId, Quantity, Price) VALUES (@OrderId, @ProductId, @Quantity, @Price)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderId", orderId);
                        cmd.Parameters.AddWithValue("@ProductId", int.Parse(item.SubItems[0].Text));
                        cmd.Parameters.AddWithValue("@Quantity", int.Parse(item.SubItems[3].Text));
                        cmd.Parameters.AddWithValue("@Price", decimal.Parse(item.SubItems[2].Text.Replace("$", "")));
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Payment processed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lvCart.Items.Clear();
                totalAmount = 0;
                lblTotalAmount.Text = "Total: $0.00";
            }
        }

        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];
                int productId = Convert.ToInt32(row.Cells["ProductId"].Value);
                string productName = row.Cells["ProductName"].Value.ToString();
                decimal price = Convert.ToDecimal(row.Cells["Price"].Value);

                ListViewItem item = new ListViewItem(productId.ToString());
                item.SubItems.Add(productName);
                item.SubItems.Add("$" + price.ToString("0.00"));
                item.SubItems.Add("1"); // Default quantity
                item.SubItems.Add("$" + price.ToString("0.00")); // Total = Price * Quantity

                lvCart.Items.Add(item);
                totalAmount += price;
                lblTotalAmount.Text = "Total: $" + totalAmount.ToString("0.00");
            }
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            string filterExpression = string.Format("ProductName LIKE '%{0}%'", txtSearchProduct.Text);
            (dgvProducts.DataSource as DataTable).DefaultView.RowFilter = filterExpression;
        }
    }
}
