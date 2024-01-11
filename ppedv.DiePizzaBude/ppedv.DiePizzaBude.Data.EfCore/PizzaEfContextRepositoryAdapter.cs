using Microsoft.Extensions.Logging;
using ppedv.DiePizzaBude.Model.Contracts;
using ppedv.DiePizzaBude.Model.DomainModel;

namespace ppedv.DiePizzaBude.Data.EfCore
{
    public class PizzaEfContextRepositoryAdapter : IRepository
    {
        readonly PizzaEfContext context;

        public PizzaEfContextRepositoryAdapter(string conString, ILoggerFactory logFac)
        {
            var log = logFac.CreateLogger<PizzaEfContextRepositoryAdapter>();
            log.LogInformation("new PizzaEfContextRepositoryAdapter");
            context = new PizzaEfContext(conString, logFac);
        }

        public void Add<T>(T entity) where T : Entity
        {
            context.Add(entity);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            context.Remove(entity);
        }

        public IQueryable<T> GetAll<T>() where T : Entity
        {
            return context.Set<T>();
        }

        public T? GetById<T>(int id) where T : Entity
        {
            return context.Set<T>().Find(id);
        }

        public void SaveAll()
        {
            context.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            context.Update(entity);
        }
    }
}
