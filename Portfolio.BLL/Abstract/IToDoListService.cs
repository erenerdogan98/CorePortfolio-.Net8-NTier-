using Portfolio.DTO;

namespace Portfolio.BLL.Abstract
{
    public interface IToDoListService : IGenericService<ToDoListDTO>
    {
		void TChangeStatusTrue(ToDoListDTO toDoDto);
		void TChangeStatusFalse(ToDoListDTO toDoDto);
	}
}
