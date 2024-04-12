using Portfolio.DAL.Abstract;
using Portfolio.DAL.Context;
using Portfolio.DAL.Repository;
using Portfolio.Entities;

namespace Portfolio.DAL.EFRepositories
{
    public class EFSkillRepository(AppDbContext context) : GenericRepository<Skill>(context), ISkillDAL 
    {
    }
}
