using Portfolio.Entities;

namespace Portfolio.DAL.Abstract
{
    public interface IToDoListDAL : IGenericDAL<ToDoList>
    {
        void ChangeStatusTrue(ToDoList toDo);
        void ChangeStatusFalse(ToDoList toDo);
    }
}
