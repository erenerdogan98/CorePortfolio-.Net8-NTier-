using AutoMapper;
using Portfolio.BLL.Abstract;
using Portfolio.DAL.Abstract;
using Portfolio.DTO;
using Portfolio.Entities;

namespace Portfolio.BLL.Concrete
{
    public class ContactManager(IContactDAL contactDAL, IMapper mapper) : GenericManager<Contact,ContactDTO>(contactDAL, mapper), IContactService
    {
    }
}
