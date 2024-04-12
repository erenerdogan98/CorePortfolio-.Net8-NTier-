using Portfolio.DTO;

namespace Portfolio.BLL.Abstract
{
    public interface IMessageService : IGenericService<MessageDTO>
    {
        void TChangeStatusTrue(MessageDTO message);
        void TChangeStatusFalse(MessageDTO message);
    }
}
