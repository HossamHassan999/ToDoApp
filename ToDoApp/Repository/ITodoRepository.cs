using ToDoApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoApp.Repository
{
    public interface ITodoRepository
    {
        Task<List<ToDo>> GetAllAsync();
        Task<List<ToDo>> GetByCategoryAsync(int id);
        Task<ToDo> GetByIdAsync(int id);
        Task CreateAsync(ToDo toDo);
        Task UpdateAsync(int id, ToDo toDo);
        Task DeleteAsync(int id);
    }
}
