using Repository.Interfaces;
using Repository.SqlServer;
using System.Data.SqlClient;
using UnitOfWork.Interfaces;

namespace UnitOfWork.SqlServer
{
    public class UnitOfWorkSqlServerRepository : IUnitOfWorkRepository
    {
        public IInvoiceRepository InvoiceRepository { get; }
        public IInvoiceDetailRepository InvoiceDetailRepository { get; }
        public IClientRepository ClientRepository { get; }
        public IProductRepository ProductRepository { get; }

        public UnitOfWorkSqlServerRepository(SqlConnection context, SqlTransaction transaction)
        {
            InvoiceRepository = new InvoiceRepository(context, transaction);
            InvoiceDetailRepository = new InvoiceDetailRepository(context, transaction);
            ClientRepository = new ClientRepository(context, transaction);
            ProductRepository = new ProductRepository(context, transaction);
        }


    }
}
