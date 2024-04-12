using AutoMapper;
using Portfolio.BLL.Abstract;
using Portfolio.DAL.Abstract;
using Portfolio.DTO;
using Portfolio.Entities;


namespace Portfolio.BLL.Concrete
{
	public class TestimonialManager(ITestimonialDAL testimonialDAL, IMapper mapper) : GenericManager<Testimonial, TestimonialDTO>(testimonialDAL, mapper), ITestimonialService
	{

	}
}
