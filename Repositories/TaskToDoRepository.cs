using CadastroTarefaAPI.DbContextGeneral;
using CadastroTarefaAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CadastroTarefaAPI.Repositories
{
    public class TaskToDoRepository: ITaskToDoRepository
    {
        private readonly PrincipalDbContext _context;
        
        public TaskToDoRepository(PrincipalDbContext context)
        {
            _context = context;
        }
        public async Task<List<TaskToDo>> GetAllAsync()
        {
            return await _context.TasksToDo.ToListAsync();
        }
        public async Task<TaskToDo> GetByIdAsync(int id)
        {
            return await _context.TasksToDo.FindAsync(id);
        }
        public async Task DeleteByIdAsync(int id)
        {
            var task = await GetByIdAsync(id);
            if (task != null)
            {
                _context.TasksToDo.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateByIdAsync(TaskToDo taskToDo)
        {
            _context.TasksToDo.Update(taskToDo);
            await _context.SaveChangesAsync();
        }
        public async Task CreateAsync(TaskToDo taskToDo)
        {
            await _context.TasksToDo.AddAsync(taskToDo);
            await _context.SaveChangesAsync();
        }
    }
}
