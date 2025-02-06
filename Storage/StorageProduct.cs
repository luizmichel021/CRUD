using CRUD_PRODUCTS.Database;
using CRUD_PRODUCTS.Models;
using MySql.Data.MySqlClient;


namespace CRUD_PRODUCTS.Storage
{
    public class StorageProduct
    {
        private readonly Connection db = new Connection();


        public int CreateProduct(Product product)
        {   
            
            using(var connection = db.GetConnection())
            {
                connection.Open();
                var command = new MySqlCommand("INSERT INTO Products (NOME , PRECO, QUANTIDADE ) values (@NOME , @PRECO, @QUANTIDADE);", connection);
                command.Parameters.AddWithValue("@NOME", product.Nome);
                command.Parameters.AddWithValue("@PRECO", product.Preco);
                command.Parameters.AddWithValue("@QUANTIDADE", product.Quantidade);

                var ret = command.ExecuteNonQuery();

                if (ret !=0)
                {
                    var commandret = new MySqlCommand( "SELECT LAST_INSERT_ID();", connection);
                    var retc = commandret.ExecuteScalar();
                    int id = Convert.ToInt32(retc);
                    return id;                    
                }
                else
                {
                    return 0;
                }
            }
        }

        public Product? GetProduct(int id)
        {
            using (var connection = db.GetConnection())
            {
                connection.Open();
        
                var command = new MySqlCommand("SELECT ID, NOME, PRECO, QUANTIDADE FROM Products WHERE ID = @ID", connection);
                command.Parameters.AddWithValue("@ID", id);

                using (var reader = command.ExecuteReader()) 
                {
                    if (reader.Read()) 
                    {
                        return new Product
                        {
                            Id = reader.GetInt32("ID"),
                            Nome = reader.GetString("NOME"),
                            Preco = reader.GetDouble("PRECO"),
                            Quantidade = reader.GetInt32("QUANTIDADE")
                        };
                    }
                }
            }

             return null;
        }

        public bool UpdateProduct(Product product)
        {
            using(var connection = db.GetConnection())
            {
                connection.Open();
                var command = new MySqlCommand("UPDATE Products SET NOME = @NOME , PRECO = @PRECO, QUANTIDADE = @QUANTIDADE WHERE ID = @ID;", connection);
                command.Parameters.AddWithValue("@NOME", product.Nome);
                command.Parameters.AddWithValue("@PRECO", product.Preco);
                command.Parameters.AddWithValue("@QUANTIDADE", product.Quantidade);
                command.Parameters.AddWithValue("@ID", product.Id);

                var ret = command.ExecuteNonQuery();
                if(ret != 0)
                {
                    return true;
                }
                else
                {
                    return false ;
                }
                               
            }
        }  

    
        public bool DeleteProduct(int id)
        {
            using(var connection = db.GetConnection())
            {
                connection.Open();
                var command = new MySqlCommand("UPDATE Products SET ATIVO = false WHERE ID = @ID;",connection);
                command.Parameters.AddWithValue("@ID", id);
                var ret = command.ExecuteNonQuery();
                if (ret != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


    }
}