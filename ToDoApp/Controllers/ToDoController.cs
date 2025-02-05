using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoApp.Models;
using ToDoApp.Repository;

namespace ToDoApp.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ITodoRepository _todoRepository;

        private readonly ICategoryRepository _categoryRepository;

        public ToDoController(ITodoRepository todoRepository , ICategoryRepository categoryRepository)
        {
            _todoRepository= todoRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            var Catogerylist = await _categoryRepository.GetAllAsync();

            return View("Index",Catogerylist);
        }


        public async Task<IActionResult> ToDoListByCategory(int id)
        {
            var todoList = await _todoRepository.GetByCategoryAsync(id);

            // Ensure that the list is not empty before passing it to the view.
            if (todoList == null || !todoList.Any())
            {
                // Optional: return a not found or an empty result if the list is empty
                return View();  // You can create a NoToDos view if necessary
            }

            return View(todoList);
        }

        public async Task<IActionResult> Edit(int id )
        {
            ToDo todo = await _todoRepository.GetByIdAsync(id);

            ViewBag.Category = await _categoryRepository.GetAllAsync();

            return View("ToDoEdit", todo);

        }

        public async Task<IActionResult> SaveEdit(int id , ToDo todo)
        {
           await _todoRepository.UpdateAsync(id, todo);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteToDo(int id )
        {
            await _todoRepository.DeleteAsync(id);

            return RedirectToAction("Index");

        }


        public async Task<IActionResult> NewToDo()
        {
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Category = new SelectList(categories, "Id", "Name");

            return View("NewToDo");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveToDo(ToDo toDo)
        {

            await _todoRepository.CreateAsync(toDo);
    
            return RedirectToAction("Index");
        }
    }
}
