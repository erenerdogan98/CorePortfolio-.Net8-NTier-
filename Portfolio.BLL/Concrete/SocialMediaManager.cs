using AutoMapper;
using Portfolio.BLL.Abstract;
using Portfolio.BLL.Helper;
using Portfolio.DAL.Abstract;
using Portfolio.DTO;
using Portfolio.Entities;
using System.Linq.Expressions;

namespace Portfolio.BLL.Concrete
{
    public class SocialMediaManager(ISocialMediaDAL socialMediaDAL, IMapper mapper) : GenericManager<SocialMedia, SocialMediaDTO>(socialMediaDAL, mapper), ISocialMediaService
    {
        
    }
}
