using System.Linq.Expressions;
using EventProvider.Data.Entities;

namespace EventProvider.Data.Interfaces
{
    public interface IEventRepository : IBaseRepository<EventEntity>
    {
    }
}