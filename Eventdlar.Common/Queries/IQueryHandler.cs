using System.Threading.Tasks;
using RawRabbit;

namespace Eventdlar.Common.Queries
{
    public interface IQueryHandler<in T, Y> where T : IQuery where Y : IQueryResponse
    {
        Task<Y> HandleAsync(T query, IBusClient busClient);
    }
}
