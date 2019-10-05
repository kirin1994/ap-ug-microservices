using System.Collections.Generic;
using Eventdlar.Common.Queries;

namespace Eventdlar.Common.Databases
{
    public interface IRepository<in T,Y> where T : IEntity where Y : IQueryResponse
    {
        void add(T resource);
        Y getAll();
    }
}
