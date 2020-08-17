using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repository.SqlServer
{
    public class ProductRepository : Repository, IProductRepository
    {
        public ProductRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public Product Get(int id)
        {
            var command = CreateCommand("select * from products where id = @productId");
            command.Parameters.AddWithValue("@productId", id);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                return new Product
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Name = reader["name"].ToString(),
                    Price = Convert.ToInt32(reader["price"]),
                };
            }
        }

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
