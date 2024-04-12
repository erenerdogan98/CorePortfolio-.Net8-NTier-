using AutoMapper;
using Portfolio.DTO;
using Portfolio.Entities;

namespace Portfolio.BLL.Helper
{
	public class MapProfile : Profile
	{
        public MapProfile()
        {
			CreateMap<AboutDTO,About>().ReverseMap();
			CreateMap<ContactDTO,Contact>().ReverseMap();
			CreateMap<ExperienceDTO, Experience>().ReverseMap();
			CreateMap<FeatureDTO, Feature>().ReverseMap();
			CreateMap<MessageDTO, Message>().ReverseMap();
			CreateMap<MyPortfolioDTO, MyPortfolio>().ReverseMap();
			CreateMap<SkillDTO, Skill>().ReverseMap();
			CreateMap<SocialMediaDTO, SocialMedia>().ReverseMap();
			CreateMap<TestimonialDTO, Testimonial>().ReverseMap();
			CreateMap<ToDoListDTO, ToDoList>().ReverseMap();
		}
    }
}
