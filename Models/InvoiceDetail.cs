namespace Models
{
    public class InvoiceDetail
    {
        public int Id { get; set; }
        // clave foranea de Product
        public int ProductId { get; set; }
        // referencia a Product
        public Product Product { get; set; }
        // clave foranea de Invoice
        public int InvoiceId { get; set; }
        // referencia a Invoice
        public Invoice Invoice { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Iva { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
    }
}
