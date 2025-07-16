using CadastroTarefaAPI.Model;

namespace CadastroTarefaAPI.Repositories
{
    public interface ITaskToDoRepository
    {
        Task<List<TaskToDo>> GetAllAsync();
        Task<TaskToDo> GetByIdAsync(int ind);
        Task DeleteByIdAsync(int id);
        Task UpdateByIdAsync(TaskToDo taskToDo);
        Task CreateAsync(TaskToDo taskToDo);
    }
}
