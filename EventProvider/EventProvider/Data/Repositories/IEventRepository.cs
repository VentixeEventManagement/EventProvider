using System.Linq.Expressions;
using EventProvider.Data.Entities;
using EventProvider.Data.Interfaces;

namespace EventProvider.Data.Repositories
{
    public interface IEventRepository : IBaseRepository<EventEntity>
    {
    }
}