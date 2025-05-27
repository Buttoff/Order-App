using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DateBase;
using MySql.Data.MySqlClient;
using OrderSummaryApp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Menu newForm = new Menu();
            newForm.Show();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            string clientNumber = textBox2.Text;
            string shipping_address = textBox3.Text;
            string deliveryAddress = textBox4.Text;
            string packingType = textBox5.Text;
            string transportType = textBox6.Text;

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string clientNumber = textBox2.Text;
            string shippingAddress = textBox3.Text;
            string deliveryAddress = textBox4.Text;
            string packingType = textBox5.Text;
            string transportType = textBox6.Text;
            DB.AddOrder(clientNumber, shippingAddress, deliveryAddress, packingType, transportType);
            LoadDataToDataGridView();

        }



        private void LoadDataToDataGridView()
        {
            string sqlQuery = "SELECT * FROM orders";

            DataTable data = DB.GetData(sqlQuery);

            dataGridView1.DataSource = data; 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Order_Load(object sender, EventArgs e)
        {
            LoadDataToDataGridView();
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string id = textBox7.Text;
            string tableName = "orders";
            DB.DeletingFromDB(tableName, id);
            LoadDataToDataGridView();
        }
    }
 }

