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
using DateBase;
using MySql.Data.MySqlClient;
namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
         
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DB.OpenConnection();

                MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM users WHERE username = @name AND password = @pass", DB.GetConnection());
                command.Parameters.AddWithValue("@name", textBoxName.Text);
                command.Parameters.AddWithValue("@pass", textBoxPass.Text);


                int userCount = Convert.ToInt32(command.ExecuteScalar());

                if (userCount > 0)
                {
                    
                    MessageBox.Show("Вход успешен! Добро пожаловать.");
                    Hide();
                    Menu newForm = new Menu();
                    newForm.Show();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при входе: " + ex.Message);
            }
            finally
            {
                DB.CloseConnection();
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
