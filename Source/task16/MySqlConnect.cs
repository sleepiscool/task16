using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace task16
{
    internal class MySqll
    {
        public static void ConnectToDataBAse()
        {
            try
            {
                using (
                    var connection =new MySqlConnection("server=localhost;uid=root;pwd=root;database=databasetask16;"))
                {
                    connection.Open();
                    var transaction = connection.BeginTransaction();
                    try
                    {
                        var command = connection.CreateCommand();
                        command.Connection = connection;
                        command.Transaction = transaction;

                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
