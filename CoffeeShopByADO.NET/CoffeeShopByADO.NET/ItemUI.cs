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
    public partial class ItemUI : Form
    {
        public ItemUI()
        {
            InitializeComponent();
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            Insert();

        }
    
    

        private void showButton_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Update();
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
            string uniqueCommand = @"SELECT*FROM Item_Info WHERE Item_Name='" + itemNameBox.Text + "'";
            if (uniqueCommand.Contains(itemNameBox.Text))
            {
                MessageBox.Show("Item Already exist");
                return;
            }

            else
            {
                string commandString = @"INSERT INTO Item_Info (Item_Name, Price) Values ('" + itemNameBox.Text + "', " + itemPriceBox.Text + ")";
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
            string commandString = @"UPDATE Item_Info SET Item_Name= '" + itemNameBox.Text + "',Price='" + itemPriceBox.Text + "' WHERE Item_id='" + searchTextBox.Text + "'";
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
            string commandString = @"DELETE FROM Item_Info WHERE Item_id = " + searchTextBox.Text + "";
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
            string commandString = @"SELECT * FROM Item_Info";
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
            string commandString = @"SELECT Item_Name, Price FROM Item_Info WHERE Item_id='" + searchTextBox.Text + "'";
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
