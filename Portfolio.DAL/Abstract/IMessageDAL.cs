using Portfolio.Entities;

namespace Portfolio.DAL.Abstract
{
    public interface IMessageDAL : IGenericDAL<Message>
    {
        void ChangeMessageStatus(Message message);
    }
}
