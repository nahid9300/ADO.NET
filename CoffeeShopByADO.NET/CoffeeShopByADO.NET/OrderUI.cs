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
    public partial class OrderUI : Form
    {
        public OrderUI()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Insert();

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            update();
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
            string commandString = @"INSERT INTO OrderInfo (Ordered_Product_Name, Quantity) Values ('" + orderNameBox.Text + "', " + quantityBox.Text + ")";
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
        public void update()
        {
            //Connection
            string connectionString = @"Server=DESKTOP-887J8ON; DataBase=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            //DELETE FROM Items WHERE ID = 3
            string commandString = @"UPDATE OrderInfo SET Ordered_Product_Name= '" + orderNameBox.Text + "',Quantity='" + quantityBox.Text + "' WHERE Order_id='" + searchTextBox.Text + "'";
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
            string commandString = @"DELETE FROM OrderInfo WHERE Order_id = " + searchTextBox.Text + "";
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
            string commandString = @"SELECT * FROM OrderInfo";
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
            string commandString = @"SELECT Ordered_Product_Name, Quantity FROM OrderInfo WHERE Order_id='" + searchTextBox.Text + "'";
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
