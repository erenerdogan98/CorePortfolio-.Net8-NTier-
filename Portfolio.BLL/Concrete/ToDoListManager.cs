using AutoMapper;
using Portfolio.BLL.Abstract;
using Portfolio.DAL.Abstract;
using Portfolio.DTO;
using Portfolio.Entities;
using System.Linq.Expressions;

namespace Portfolio.BLL.Concrete
{
	public class ToDoListManager(IToDoListDAL toDoListDAL, IMapper mapper) : GenericManager<ToDoList, ToDoListDTO>(toDoListDAL,mapper), IToDoListService
	{


		public void TChangeStatusFalse(ToDoListDTO toDoDto)
		{
			var toDo = mapper.Map<ToDoList>(toDoDto);
			toDo.Status = false;
			toDoListDAL.ChangeStatusFalse(toDo);
			mapper.Map(toDo, toDoDto);
		}

		public void TChangeStatusTrue(ToDoListDTO toDoDto)
		{
			var toDo = mapper.Map<ToDoList>(toDoDto);
			toDo.Status = true;
			toDoListDAL.ChangeStatusTrue(toDo);
			mapper.Map(toDo, toDoDto);
		}

	}
}
