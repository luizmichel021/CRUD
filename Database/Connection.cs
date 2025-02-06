using MySql.Data.MySqlClient;

namespace CRUD_PRODUCTS.Database
{
    public class Connection
    {
        private string connectionString = "Server=localhost;Database=ProductDB;User=root;Password=123456;Pooling=True;AllowUserVariables=True";


        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}