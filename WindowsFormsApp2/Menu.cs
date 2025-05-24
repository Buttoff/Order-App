using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Order newForm = new Order();
            newForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Invoice newForm = new Invoice();
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Client newForm = new Client();
            newForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            Worker newForm = new Worker();
            newForm.Show();
        }
    }
}
