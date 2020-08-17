using System.Collections.Generic;

namespace Models
{
    public class Invoice
    {
        public int Id { get; set; }
        // clave foranea de Client
        public int ClientId { get; set; }
        // referencia a Client
        public Client Client { get; set; }
        public IEnumerable<InvoiceDetail> Detail { get; set; }
        public decimal Iva { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }

        public Invoice()
        {
            Detail = new List<InvoiceDetail>();
        }
    }
}
