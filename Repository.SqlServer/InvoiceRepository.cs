using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repository.SqlServer
{
    public class InvoiceRepository : Repository, IInvoiceRepository
    {
        public InvoiceRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public void Create(Invoice model)
        {
            var query = "insert into invoices (clientid, iva, subtotal, total) output INSERTED.ID values (@clientid, @iva, @subtotal, @total)";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@clientid", model.ClientId);
            command.Parameters.AddWithValue("@iva", model.Iva);
            command.Parameters.AddWithValue("@subtotal", model.SubTotal);
            command.Parameters.AddWithValue("@total", model.Total);
            model.Id = Convert.ToInt32(command.ExecuteScalar());
        }

        public void Delete(int id)
        {
            var command = CreateCommand("DELETE FROM invoices WHERE id = @id");
            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();
        }

        public Invoice Get(int id)
        {
            var result = new Invoice();
            var command = CreateCommand("select * from invoices where id = @id");
            command.Parameters.AddWithValue("@id", id);
            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                result.Id = Convert.ToInt32(reader["id"]);
                result.Iva = Convert.ToInt32(reader["iva"]);
                result.SubTotal = Convert.ToInt32(reader["subtotal"]);
                result.Total = Convert.ToInt32(reader["total"]);
                result.ClientId = Convert.ToInt32(reader["clientid"]);
            }
            return result;
        }

        public IEnumerable<Invoice> GetAll()
        {
            var result = new List<Invoice>();

            var command = CreateCommand("select * from invoices");
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Invoice
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Iva = Convert.ToInt32(reader["iva"]),
                        SubTotal = Convert.ToInt32(reader["subtotal"]),
                        Total = Convert.ToInt32(reader["total"]),
                        ClientId = Convert.ToInt32(reader["clientid"])
                    });
                }
            }

            return result;
        }

        public void Update(Invoice model)
        {
            var query = "update invoices set clientId = @clientId, iva = @iva, subTotal = @subTotal, total = @total WHERE id = @id";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@clientId", model.ClientId);
            command.Parameters.AddWithValue("@iva", model.Iva);
            command.Parameters.AddWithValue("@subTotal", model.SubTotal);
            command.Parameters.AddWithValue("@total", model.Total);
            command.Parameters.AddWithValue("@id", model.Id);

            command.ExecuteNonQuery();
        }
    }
}
