namespace Models.Common.Interfaces
{
    public interface IRepository<T> : ICrudMethods<T>
    {

    }

    public interface IRepository
    {
        object getById(string id);
    }
}
