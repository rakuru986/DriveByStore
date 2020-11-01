namespace Models.Common.Interfaces
{
    public interface IEntity { }

    public interface IEntity<out TData> : IEntity
    {
        TData Data { get; }
    }
}
