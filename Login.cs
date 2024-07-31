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
    public partial class Login : Form
    {
        string connectionString = "Data Source=.;Initial Catalog=GroceryPOS;Integrated Security=True;Encrypt=False";
        public Login()
        {
            InitializeComponent();
        }
        
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    int userId = (int)reader["UserId"];
                    string fullName = reader["Username"].ToString();

                    Dashboard dashboard = new Dashboard(userId, fullName);
                    this.Hide();
                    dashboard.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }    
}
