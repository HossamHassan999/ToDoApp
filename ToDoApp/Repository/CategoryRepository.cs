using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

namespace ToDoApp.Repository
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly ToDoContext _context;

        public CategoryRepository(ToDoContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Set<Category>().ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Set<Category>().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task CreateAsync(Category category)
        {
            await _context.Set<Category>().AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Category category)
        {
            var existingCategory = await GetByIdAsync(id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var category = await GetByIdAsync(id);
            if (category != null)
            {
                _context.Set<Category>().Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}
