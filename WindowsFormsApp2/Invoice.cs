using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Invoice : Form
    {
        public Invoice()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
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
        
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string trackNumber = textBox12.Text;
            string shipping_address = textBox2.Text;
            string deliveryAddress = textBox3.Text;
            string weight = textBox4.Text;
            string volume = textBox5.Text;
            string comments = textBox6.Text;
            string transportType = textBox9.Text;
            string state = textBox10.Text;
            string price = textBox11.Text;

            DateBase.DB.AddInvoice(trackNumber, shipping_address, deliveryAddress, weight, volume, comments, transportType, state, price);
        }
    }
}
