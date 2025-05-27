using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DateBase;

namespace WindowsFormsApp2
{
    public partial class Worker : Form
    {
        public Worker()
        {
            InitializeComponent();
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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }



        private void button3_Click(object sender, EventArgs e)
        {
            string full_name = textBox2.Text;
            string address = textBox3.Text;
            string rank = textBox4.Text;

            DB.AddWorker(full_name, address, rank);
        }

        private void LoadDataToDataGridView()
        {
            string sqlQuery = "SELECT * FROM workers";

            DataTable data = DB.GetData(sqlQuery);

            dataGridView1.DataSource = data;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Worker_Load(object sender, EventArgs e)
        {
            LoadDataToDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox7.Text;
            string tableName = "workers";
            DB.DeletingFromDB(tableName, id);
            LoadDataToDataGridView();
        }
    }
}
