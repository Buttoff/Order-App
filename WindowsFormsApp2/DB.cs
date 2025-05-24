using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DateBase
{
    public static class DB
    {
        private static readonly string connectionString = "server=localhost;port=3306;username=root;password=root;database=practic";
        private static MySqlConnection connection;

        public static MySqlConnection GetConnection()
        {
            if (connection == null)
                connection = new MySqlConnection(connectionString);
            return connection;
        }

        public static void OpenConnection()
        {
            if (GetConnection().State == System.Data.ConnectionState.Closed)
                GetConnection().Open();
        }

        public static void CloseConnection()
        {
            if (GetConnection().State == System.Data.ConnectionState.Open)
                GetConnection().Close();
        }
        public static void AddInvoice(
        string trackNumber,
        string shipping_address,
        string deliveryAddress,
        string weight,
        string volume,
        string comments,
        string transportType,
        string state,
        string price)
        {
            try
            {
                DB.OpenConnection();
                MessageBox.Show(trackNumber);
               

                string query = @"INSERT INTO invoices 
                         (track_number, shipping_address, delivery_address, weight, voulme, comment, transport_type, state, price)
                         VALUES
                         (@trackNumber, @shipping_address, @deliveryAddress, @weight, @volume, @comments, @transportType, @state, @price)";

                MySqlCommand cmd = new MySqlCommand(query, DB.GetConnection());

                cmd.Parameters.AddWithValue("@trackNumber", trackNumber);
                cmd.Parameters.AddWithValue("@shipping_address", shipping_address);
                cmd.Parameters.AddWithValue("@deliveryAddress", deliveryAddress);
                cmd.Parameters.AddWithValue("@weight", weight);
                cmd.Parameters.AddWithValue("@volume", volume);
                cmd.Parameters.AddWithValue("@comments", comments);
                cmd.Parameters.AddWithValue("@transportType", transportType);
                cmd.Parameters.AddWithValue("@state", state);
                cmd.Parameters.AddWithValue("@price", price);


                cmd.ExecuteNonQuery();

                MessageBox.Show("Накладная успешно добавлена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении накладной: " + ex.Message);
            }
            finally
            {
                DB.CloseConnection();
            }
        }

    }
}


