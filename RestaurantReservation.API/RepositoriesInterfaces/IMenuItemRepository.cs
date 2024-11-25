using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.RepositoriesInterfaces
{
    public interface IMenuItemRepository
    {
        Task CreateAsync(MenuItem menuItem);
        Task DeleteAsync(MenuItem menuItem);
        Task<IEnumerable<MenuItem>> GetAllAsync(int pageNumber, int pageSize);
        Task<MenuItem> GetByIdAsync(int id);
        Task UpdateAsync(MenuItem menuItem);
        Task<int> CountAsync();
    }
}