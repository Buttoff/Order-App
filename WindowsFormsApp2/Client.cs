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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Menu newForm = new Menu();
            newForm.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string username = textBox2.Text;
            string numCard = textBox3.Text;
            string address = textBox4.Text;


            DB.AddClient(username, numCard, address);
            LoadDataToDataGridView();
        }

        private void LoadDataToDataGridView()
        {
            string sqlQuery = "SELECT * FROM users";

            DataTable data = DB.GetData(sqlQuery);

            dataGridView1.DataSource = data;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void Client_Load_1(object sender, EventArgs e)
        {
            LoadDataToDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                string id = textBox5.Text;
                string tableName = "users";
                DB.DeletingFromDB(tableName, id);
                LoadDataToDataGridView();
            }
        }
    }
}
