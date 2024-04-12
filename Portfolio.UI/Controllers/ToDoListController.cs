using Microsoft.AspNetCore.Mvc;
using Portfolio.BLL.Abstract;
using Portfolio.DTO;
using Portfolio.Entities;

namespace Portfolio.UI.Controllers
{
    public class ToDoListController(IToDoListService toDoListService) : Controller
    {

        public async Task<IActionResult> Index()
        {
            var toDos = await toDoListService.TGetAllAsync();
            return View(toDos);
        }
        [HttpGet]
        public IActionResult CreateToDoList()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateToDoList(ToDoListDTO toDoListDto)
        {
            await toDoListService.TAddAsync(toDoListDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateToDoList(int id)
        {
            var toDo = await toDoListService.TGetByIdAsync(id);
            return View(toDo);
        }
        [HttpPost]
        public IActionResult UpdateToDoList(ToDoListDTO toDoDto)
        {
            toDoListService.TUpdate(toDoDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangeToDoListFalse(int id)
        {
            var toDo = await toDoListService.TGetByIdAsync(id);
            toDoListService.TChangeStatusFalse(toDo);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangeToDoListTrue(int id)
        {
            var toDo = await toDoListService.TGetByIdAsync(id);
            toDoListService.TChangeStatusTrue(toDo);
            return RedirectToAction("Index");
        }

        [HttpGet("delete-todo/{id}")]
        public IActionResult DeleteToDoList(int id)
        {
            var toDo = toDoListService.TGetById(id);
            toDoListService.TDeleteAsync(toDo);
            return RedirectToAction("Index");
        }
    }
}
