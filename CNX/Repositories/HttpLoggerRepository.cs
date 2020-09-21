using CNX.Contracts.Entities;
using CNX.Contracts.Interfaces;

namespace CNX.Repositories
{
    public class HttpLoggerRepository : IHttpLoggerRepository
    {
        public void Add(HttpLogModel log)
        {
            using var context = new DatabaseContext();
            context.Logs.Add(log);
            context.SaveChanges();
        }
    }
}
