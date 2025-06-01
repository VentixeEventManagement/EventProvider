// This code was formatted and refined using AI assistance.
using System.Linq.Expressions;
using EventProvider.Data.Entities;


namespace EventProvider.Data.Interfaces
{
    /// <summary>
    /// Provides data access methods specific to <see cref="EventEntity"/> objects.
    /// Inherits basic CRUD operations from <see cref="IBaseRepository{EventEntity}"/>.
    /// </summary>
    public interface IEventRepository : IBaseRepository<EventEntity>
    {
        // Add event-specific data access methods here if needed in the future.
    }
}