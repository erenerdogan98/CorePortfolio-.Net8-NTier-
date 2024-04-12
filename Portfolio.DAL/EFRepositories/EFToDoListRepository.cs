using Portfolio.DAL.Abstract;
using Portfolio.DAL.Context;
using Portfolio.DAL.Repository;
using Portfolio.Entities;

namespace Portfolio.DAL.EFRepositories
{
	public class EFToDoListRepository(AppDbContext context) : GenericRepository<ToDoList>(context), IToDoListDAL
    {
        AppDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

		public void ChangeStatusFalse(ToDoList toDo)
		{
			toDo.Status = false;
			_context.SaveChanges();
		}

		public void ChangeStatusTrue(ToDoList toDo)
		{
			toDo.Status = true;
			_context.SaveChanges();
		}
	}
}
