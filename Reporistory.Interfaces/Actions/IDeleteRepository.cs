namespace Repository.Interfaces.Actions
{
    public interface IDeleteRepository<T>
    {
        void Delete(T id);
    }
}
