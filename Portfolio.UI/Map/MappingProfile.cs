using AutoMapper;
using Portfolio.DTO;
using Portfolio.Entities;

namespace Portfolio.UI.Map
{
	public class MappingProfile : Profile
	{
        public MappingProfile()
        {
            CreateMap<ExperienceDTO, Experience>().ReverseMap();
        }
    }
}
