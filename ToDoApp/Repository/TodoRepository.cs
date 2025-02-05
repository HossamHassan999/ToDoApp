using ToDoApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ToDoContext _context;

        public TodoRepository(ToDoContext context)
        {
            _context = context;
        }

        public async Task<List<ToDo>> GetAllAsync()
        {
            return await _context.ToDo.ToListAsync();
        }

        public async Task<ToDo> GetByIdAsync(int id)
        {
            return await _context.ToDo.FirstOrDefaultAsync(T => T.Id == id);
        }

        public async Task<List<ToDo>> GetByCategoryAsync(int id)
        {

            return await _context.ToDo.Where(T => T.CategoryId ==id).ToListAsync();

        }

        public async Task CreateAsync(ToDo toDo)
        {
            await _context.ToDo.AddAsync(toDo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, ToDo toDo)
        {
            var todo = await GetByIdAsync(id);
            if (todo != null)
            {
                todo.Name = toDo.Name;
                todo.Description = toDo.Description;
                todo.DueData = toDo.DueData.Date;
                todo.IsCompleted = toDo.IsCompleted;
                todo.CategoryId = toDo.CategoryId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var todo = await GetByIdAsync(id);
            if (todo != null)
            {
                _context.ToDo.Remove(todo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
