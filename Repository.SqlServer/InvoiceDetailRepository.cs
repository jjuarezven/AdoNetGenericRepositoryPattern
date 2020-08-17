using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repository.SqlServer
{
    public class InvoiceDetailRepository : Repository, IInvoiceDetailRepository
    {
        public InvoiceDetailRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public void Create(IEnumerable<InvoiceDetail> model, int invoiceId)
        {
            foreach (var detail in model)
            {
                var query = "insert into invoicedetail (invoiceid,productid, quantity, price, iva, subtotal, total) values (@invoiceid, @productid, @quantity, @price, @iva, @subtotal, @total)";
                var command = CreateCommand(query);

                command.Parameters.AddWithValue("@invoiceid", invoiceId);
                command.Parameters.AddWithValue("@productid", detail.ProductId);
                command.Parameters.AddWithValue("@quantity", detail.Quantity);
                command.Parameters.AddWithValue("@price", detail.Price);
                command.Parameters.AddWithValue("@iva", detail.Iva);
                command.Parameters.AddWithValue("@subtotal", detail.SubTotal);
                command.Parameters.AddWithValue("@total", detail.Total);
                command.ExecuteNonQuery();
            }
        }

        public InvoiceDetail Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InvoiceDetail> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InvoiceDetail> GetAllByInvoiceId(int invoiceId)
        {
            var result = new List<InvoiceDetail>();
            var command = CreateCommand("select * from invoiceDetail where invoiceId = @invoiceId");
            command.Parameters.AddWithValue("@invoiceId", invoiceId);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new InvoiceDetail
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        ProductId = Convert.ToInt32(reader["productid"]),
                        Quantity = Convert.ToInt32(reader["quantity"]),
                        Iva = Convert.ToInt32(reader["iva"]),
                        SubTotal = Convert.ToInt32(reader["subtotal"]),
                        Total = Convert.ToInt32(reader["total"])
                    });
                }
            }

            return result;
        }

        public void RemoveByInvoiceId(int invoiceId)
        {
            var command = CreateCommand("DELETE FROM invoicedetail WHERE invoiceId = @invoiceId");
            command.Parameters.AddWithValue("@invoiceId", invoiceId);

            command.ExecuteNonQuery();
        }
    }
}
