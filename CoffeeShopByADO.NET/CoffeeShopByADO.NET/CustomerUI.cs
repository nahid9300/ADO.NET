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

namespace CoffeeShopByADO.NET
{
    public partial class CustomerUI : Form
    {
        public CustomerUI()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Insert();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Search();
        }


        public void Insert()
        {
            //Connection
            string connectionString = @"Server=DESKTOP-887J8ON; DataBase=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            //INSERT INTO Items (Name, Price) Values ('Black', 120)

            string uniqueCommand = @"SELECT*FROM Customer_Information WHERE Customer_Name='" + customerNameBox.Text + "'";
            if (uniqueCommand.Contains(customerNameBox.Text))
            {
                MessageBox.Show("Customer Already exist");
                return;
            }
            else
            {
                string commandString = @"INSERT INTO Customer_Information (Customer_Name, Cell,Address) Values ('" + customerNameBox.Text + "', '" + cellBox.Text + "','" + addressBox.Text + "')";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Execute
                int isExecuted = sqlCommand.ExecuteNonQuery();

                if (isExecuted > 0)
                {
                    MessageBox.Show("Saved");
                }
                else
                {
                    MessageBox.Show("Not Saved");
                }

                //Close
                sqlConnection.Close();
            }
        }
        public void Update()
        {
            //Connection
            string connectionString = @"Server=DESKTOP-887J8ON; DataBase=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            //DELETE FROM Items WHERE ID = 3
            string commandString = @"UPDATE Customer_Information SET Customer_Name= '" + customerNameBox.Text + "',Cell='" + cellBox.Text + "',Address='" + addressBox.Text + "' WHERE id='" + searchTextBox.Text + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Execute

            int isExecuted = sqlCommand.ExecuteNonQuery();

            if (isExecuted > 0)
            {
                MessageBox.Show("Updated");
            }
            else
            {
                MessageBox.Show("Not Updated");
            }

            //Close
            sqlConnection.Close();
        }
        public void Delete()
        {
            //Connection
            string connectionString = @"Server=DESKTOP-887J8ON; DataBase=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            //DELETE FROM Items WHERE ID = 3
            string commandString = @"DELETE FROM Customer_Information WHERE id = " + searchTextBox.Text + "";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Execute

            int isExecuted = sqlCommand.ExecuteNonQuery();

            if (isExecuted > 0)
            {
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }

            //Close
            sqlConnection.Close();
        }
        public void Show()
        {
            //Connection
            string connectionString = @"Server=DESKTOP-887J8ON; DataBase=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            //SELECT * FROM Items
            string commandString = @"SELECT * FROM Customer_Information";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Execute
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                showDataGrid.DataSource = dataTable;
            }
            else
            {
                showDataGrid.DataSource = null;
                MessageBox.Show("No Data Found");
            }


            //Close
            sqlConnection.Close();
        }
        public void Search()
        {
            //Connection
            string connectionString = @"Server=DESKTOP-887J8ON; DataBase=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            //SELECT * FROM Items
            string commandString = @"SELECT Customer_Name, Cell,Address FROM Customer_Information WHERE id='" + searchTextBox.Text + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Execute
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                showDataGrid.DataSource = dataTable;
            }
            else
            {
                showDataGrid.DataSource = null;
                MessageBox.Show("No Data Found");
            }


            //Close
            sqlConnection.Close();
        }
    }
}
