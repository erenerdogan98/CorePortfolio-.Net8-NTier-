using Portfolio.DAL.Abstract;
using Portfolio.DAL.Context;
using Portfolio.DAL.Repository;
using Portfolio.Entities;

namespace Portfolio.DAL.EFRepositories
{
    public class EFMyPortfolioRepository(AppDbContext context) : GenericRepository<MyPortfolio>(context), IMyPortfolioDAL
    {
    }
}
