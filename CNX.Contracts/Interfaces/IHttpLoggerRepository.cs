using CNX.Contracts.Entities;

namespace CNX.Contracts.Interfaces
{
    public interface IHttpLoggerRepository
    {
        void Add(HttpLogModel log);
    }
}
