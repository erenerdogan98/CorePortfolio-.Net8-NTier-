using Portfolio.DAL.Abstract;
using Portfolio.DAL.Context;
using Portfolio.DAL.Repository;
using Portfolio.Entities;

namespace Portfolio.DAL.EFRepositories
{
    public class EFContactRepository(AppDbContext context) : GenericRepository<Contact>(context) , IContactDAL
    {
    }
}
