using EventProvider.Data.Entities;
namespace EventProvider.Data.Interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<EventEntity>> GetAllAsync();
        Task<EventEntity?> GetAsync(System.Linq.Expressions.Expression<Func<EventEntity, bool>> expression);
    }
}