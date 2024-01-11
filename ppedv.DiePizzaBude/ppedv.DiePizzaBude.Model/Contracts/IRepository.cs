using ppedv.DiePizzaBude.Model.DomainModel;

namespace ppedv.DiePizzaBude.Model.Contracts
{
    public interface IRepository
    {
        IQueryable<T> GetAll<T>() where T : Entity;
        T? GetById<T>(int id) where T : Entity;

        void Add<T>(T entity) where T : Entity;
        void Update<T>(T entity) where T : Entity;
        void Delete<T>(T entity) where T : Entity;

        void SaveAll();
    }
}
