using Portfolio.DAL.Abstract;
using Portfolio.DAL.Context;
using Portfolio.DAL.Repository;
using Portfolio.Entities;

namespace Portfolio.DAL.EF
{
    public class EFAboutRepository(AppDbContext context) : GenericRepository<About>(context), IAboutDAL
    {
    }
}
