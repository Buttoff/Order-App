using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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


        public static void AddOrder(
            string clientNumber,
            string shippingAddress,
            string deliveryAddress,
            string packingType,
            string transportType
        )
        {
            try
            {
                DB.OpenConnection();

                string query = @"INSERT INTO orders (client_number, delivery_address, shipping_address, type_packing, type_trans)
                         VALUES
                         (@client_number, @deliveryAddress, @shipping_address, @type_packing, @type_trans)";

                MySqlCommand cmd = new MySqlCommand(query, DB.GetConnection());

                cmd.Parameters.AddWithValue("@client_number", clientNumber);
                cmd.Parameters.AddWithValue("@deliveryAddress", deliveryAddress);
                cmd.Parameters.AddWithValue("@shipping_address", shippingAddress);
                cmd.Parameters.AddWithValue("@type_packing", packingType);
                cmd.Parameters.AddWithValue("@type_trans", transportType);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Заказ успешно добавлен!");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Ошибка при добавлении заказа: {ex.Message}\nStackTrace: {ex.StackTrace}\nErrorCode: {ex.Number}");
            }
            finally
            {
                DB.CloseConnection();
            }
        }
        public static DataTable GetData(string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                OpenConnection();
                using (MySqlCommand command = new MySqlCommand(query, GetConnection()))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
                CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении данных: " + ex.Message);
            }
            return dataTable;
        }

        public static void AddWorker(
           string full_name,
           string address,
           string rank
       )
        {
            try
            {
                DB.OpenConnection();

                string query = @"INSERT INTO workers (full_name, address, rank)
                         VALUES
                         (@full_name, @address, @rank)";

                MySqlCommand cmd = new MySqlCommand(query, DB.GetConnection());

                cmd.Parameters.AddWithValue("@full_name", full_name);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@rank", rank);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Сотрудник добавлен!");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Ошибка при добавлении сотрудника: {ex.Message}\nStackTrace: {ex.StackTrace}\nErrorCode: {ex.Number}");
            }
            finally
            {
                DB.CloseConnection();
            }
        }



        public static void AddClient(
            string username,
            string numCard,
            string address
        )
        {
            try
            {
                DB.OpenConnection();

                string query = @"INSERT INTO users (username, address, num_cards)
                         VALUES
                         (@username, @numCard, @address)";

                MySqlCommand cmd = new MySqlCommand(query, DB.GetConnection());

                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@numCard", numCard);
                cmd.Parameters.AddWithValue("@address", address);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Клиент успешно добавлен!");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Ошибка при добавлении клиента: {ex.Message}\nStackTrace: {ex.StackTrace}\nErrorCode: {ex.Number}");
            }
            finally
            {
                DB.CloseConnection();
            }
        }


        public static void DeletingFromDB(string tableName, string id)
        {
            try
            {
                DB.OpenConnection();
                string query = $"DELETE FROM {tableName} WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, DB.GetConnection());
                cmd.Parameters.AddWithValue("@id", int.Parse(id));
                cmd.ExecuteNonQuery();

                MessageBox.Show("");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Введите число!");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}\nStackTrace: {ex.StackTrace}\nErrorCode: {ex.Number}");
            }
            finally
            {
                DB.CloseConnection();
            }
        }
    }



}



