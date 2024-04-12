using Portfolio.DAL.Abstract;
using Portfolio.DAL.Context;
using Portfolio.DAL.Repository;
using Portfolio.Entities;

namespace Portfolio.DAL.EFRepositories
{
    public class EFTestimonialRepository(AppDbContext context) : GenericRepository<Testimonial>(context), ITestimonialDAL
    {
    }
}
