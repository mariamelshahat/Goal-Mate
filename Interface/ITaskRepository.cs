using Goal_Mate.Models;

namespace Goal_Mate.Interface
{
    public interface ITaskRepository
    {
        Task<UserTask> AddAsync ( UserTask task );
        Task EditAsync ( UserTask task );
        Task DeleteAsync ( UserTask task );
        Task<List<UserTask>> GetAllAsync (string userId);
        Task<UserTask> GetByIdAsync ( int id );
    }
}
