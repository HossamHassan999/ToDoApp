using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Models
{
    public class ToDoContext:DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) {}


        public DbSet<ToDo> ToDo { get; set; }
        
        public DbSet<Category> Category { get; set; }  

    }
}
