using Repository.Interfaces;

namespace UnitOfWork.Interfaces
{
    public interface IUnitOfWorkRepository
    {
        IInvoiceRepository InvoiceRepository { get; }
        IInvoiceDetailRepository InvoiceDetailRepository { get; }
        IClientRepository ClientRepository { get; }
        IProductRepository ProductRepository { get; }
    }
}
