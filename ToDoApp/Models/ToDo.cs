using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models
{
    public class ToDo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DueData { get; set; }

        public bool IsCompleted { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

    }
}
