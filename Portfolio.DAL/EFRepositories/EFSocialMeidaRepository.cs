using Portfolio.DAL.Abstract;
using Portfolio.DAL.Context;
using Portfolio.DAL.Repository;
using Portfolio.Entities;

namespace Portfolio.DAL.EFRepositories
{
    public class EFSocialMeidaRepository(AppDbContext context) : GenericRepository<SocialMedia>(context) , ISocialMediaDAL 
    {
    }
}
