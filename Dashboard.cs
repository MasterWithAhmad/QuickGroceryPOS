// Ignore Spelling: username

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
using System.Windows.Forms.DataVisualization.Charting;

namespace QuickGrocery
{
    public partial class Dashboard : Form
    {
        private int userId;
        private string username;
        string connectionString = "Data Source=.;Initial Catalog=GroceryPOS;Integrated Security=True;Encrypt=False";
        public Dashboard(int userId, string username)
        {
            InitializeComponent();
            LoadSalesSummary();
            LoadInventoryOverview();
            LoadRecentTransactions();
            LoadTopSellingProducts();
            LoadDashboardData();
            this.userId = userId;
            this.username = username;
            lblWelcomeMessage.Text = "Welcome, " + username + "!";
        }

        private void LoadInventoryOverview()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) AS TotalProducts, " +
                               "(SELECT COUNT(*) FROM Products WHERE Quantity = 0) AS OutOfStock, " +
                               "(SELECT COUNT(*) FROM Products WHERE Quantity < 10) AS LowStock";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        //lblTotalProducts.Text = $"Total Products: {reader["TotalProducts"]}";
                        lblOutOfStock.Text = $"Out of Stock: {reader["OutOfStock"]}";
                        lblLowStock.Text = $"Low Stock : {reader["LowStock"]}";
                    }
                }
            }
        }

        private void LoadSalesSummary()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT " +
                               "(SELECT SUM(TotalAmount) FROM Orders WHERE OrderDate >= DATEADD(DAY, -1, GETDATE())) AS TodaySales, " +
                               "(SELECT SUM(TotalAmount) FROM Orders WHERE OrderDate >= DATEADD(WEEK, -1, GETDATE())) AS WeekSales, " +
                               "(SELECT SUM(TotalAmount) FROM Orders WHERE OrderDate >= DATEADD(MONTH, -1, GETDATE())) AS MonthSales, " +
                               "(SELECT SUM(TotalAmount) FROM Orders WHERE OrderDate >= DATEADD(YEAR, -1, GETDATE())) AS YearSales";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblTodaySales.Text = $"Today's Sales: ${reader["TodaySales"]}";
                        lblWeekSales.Text = $"This Week's Sales: ${reader["WeekSales"]}";
                        lblMonthSales.Text = $"This Month's Sales: ${reader["MonthSales"]}";
                        lblYearSales.Text = $"This Year's Sales: ${reader["YearSales"]}";
                    }
                }
            }
        }

        private void LoadRecentTransactions()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP 5 OrderId, UserId, TotalAmount, OrderDate FROM Orders ORDER BY OrderDate DESC";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvRecentTransactions.DataSource = dt;
            }
        }

        private void LoadTopSellingProducts()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP 5 p.ProductName, SUM(oi.Quantity) AS QuantitySold " +
                               "FROM OrderItems oi " +
                               "JOIN Products p ON oi.ProductId = p.ProductId " +
                               "GROUP BY p.ProductName " +
                               "ORDER BY QuantitySold DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvTopSellingProducts.DataSource = dt;
            }
        }

        private void LoadDashboardData()
        {
            // Initialize the chart and clear any existing series
            chartDashboard.Series.Clear();

            // Create and add the Revenue series
            Series revenueSeries = new Series
            {
                Name = "Revenue",
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.String
            };
            chartDashboard.Series.Add(revenueSeries);

            // Create and add the Sales series
            Series salesSeries = new Series
            {
                Name = "Sales",
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.String
            };
            chartDashboard.Series.Add(salesSeries);

            // Create and add the Products series
            Series productsSeries = new Series
            {
                Name = "Products",
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.String
            };
            chartDashboard.Series.Add(productsSeries);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Calculate Revenue
                string revenueQuery = "SELECT SUM(TotalAmount) AS Revenue FROM Orders";
                SqlCommand revenueCmd = new SqlCommand(revenueQuery, conn);
                object revenueResult = revenueCmd.ExecuteScalar();
                decimal totalRevenue = revenueResult != DBNull.Value ? Convert.ToDecimal(revenueResult) : 0;
                revenueSeries.Points.AddXY("Revenue", totalRevenue);

                // Calculate Sales
                string salesQuery = "SELECT COUNT(*) AS Sales FROM OrderItems";
                SqlCommand salesCmd = new SqlCommand(salesQuery, conn);
                object salesResult = salesCmd.ExecuteScalar();
                int totalSales = salesResult != DBNull.Value ? Convert.ToInt32(salesResult) : 0;
                salesSeries.Points.AddXY("Sales", totalSales);

                // Calculate Product Stock
                string productsQuery = "SELECT COUNT(*) AS Products FROM Products";
                SqlCommand productsCmd = new SqlCommand(productsQuery, conn);
                object productsResult = productsCmd.ExecuteScalar();
                int totalProducts = productsResult != DBNull.Value ? Convert.ToInt32(productsResult) : 0;
                productsSeries.Points.AddXY("Products", totalProducts);
            }

            // Set the chart area titles
            chartDashboard.ChartAreas[0].AxisX.Title = "Categories";
            chartDashboard.ChartAreas[0].AxisY.Title = "Values";
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            Checkout checkoutForm = new Checkout(userId);
            checkoutForm.Show();
        }

        private void btnOrderHistory_Click(object sender, EventArgs e)
        {
            

        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Products products = new Products();
            products.ShowDialog();
            //this.Visible = false;
        }

        private void orderHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderHistory orderHistoryForm = new OrderHistory(userId);
            orderHistoryForm.Show();
        }

        private void checkOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Checkout checkoutForm = new Checkout(userId);
            checkoutForm.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
