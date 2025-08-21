using Goal_Mate.Data;
using Goal_Mate.Interface;
using Goal_Mate.Models;
using Microsoft.EntityFrameworkCore;

namespace Goal_Mate.Repository
{
    public class TaskRepository :ITaskRepository
    {
        private readonly Mydbcontext _dbcontext;

        public TaskRepository ( Mydbcontext dbcontext )
        {
            _dbcontext = dbcontext;
        }

        public async Task<UserTask> AddAsync ( UserTask task )
        {

            await _dbcontext.Tasks.AddAsync ( task );
            await _dbcontext.SaveChangesAsync();
            return task;
        }

        public async Task DeleteAsync ( UserTask task )
        {
            var t = await GetByIdAsync(task.TaskId);
            _dbcontext.Remove ( t );
            await _dbcontext.SaveChangesAsync();
        }

        public async Task EditAsync ( UserTask task )
        {
            var t = await GetByIdAsync ( task.TaskId );
            t.Priority = task.Priority;
            t.Title = task.Title;
            t.Description = task.Description;
            t.DueDate = task.DueDate;
            t.CategoryId = task.CategoryId;
            await _dbcontext.SaveChangesAsync ();
        }

        public Task<List<UserTask>> GetAllAsync (string userId)
        {
            return _dbcontext.Tasks.Where ( t => t.UserId == userId ).OrderByDescending ( t => t.Priority ).ThenBy ( t => t.DueDate ).ToListAsync ();
        }

        public async Task<UserTask> GetByIdAsync ( int id )
        {
            return await _dbcontext.Tasks.FirstOrDefaultAsync ( t => t.TaskId == id );
        }
    }
}
