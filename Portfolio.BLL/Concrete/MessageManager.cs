using AutoMapper;
using Portfolio.BLL.Abstract;
using Portfolio.BLL.Helper;
using Portfolio.DAL.Abstract;
using Portfolio.DTO;
using Portfolio.Entities;
using System.Linq.Expressions;

namespace Portfolio.BLL.Concrete
{
    public class MessageManager(IMessageDAL messageDAL, IMapper mapper) : GenericManager<Message, MessageDTO>(messageDAL, mapper), IMessageService
    {
        public void TChangeStatusFalse(MessageDTO messageDto)
        {
            var message = mapper.Map<Message>(messageDto);
            message.IsRead = false;
            messageDAL.ChangeMessageStatus(message);
            mapper.Map(message, messageDto);
        }

        public void TChangeStatusTrue(MessageDTO messageDto)
        {
            var message = mapper.Map<Message>(messageDto);
            message.IsRead = true;
            messageDAL.ChangeMessageStatus(message);
            _ = mapper.Map<MessageDTO>(message);
        }
    }
}
