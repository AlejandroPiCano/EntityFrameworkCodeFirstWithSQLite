namespace TodoItems.Domain
{
    public interface IRepository<T>
    {
        /// <summary>
        /// The Unit of Work.
        /// </summary>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Get todo item by identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetAsync(int id);

        /// <summary>
        /// Get all todo items
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetAllAsync();

        /// Create a todo Item
        /// </summary>
        /// <param name="entity"></param>
        Task CreateAsync(T entity);

        /// <summary>
        /// Update a todo Item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        Task UpdateAsync(int id, T entity);

        /// <summary>
        /// Delete a todo Item 
        /// </summary>
        /// <param name="id"></param>
        Task DeleteAsync(int id);
    }
}