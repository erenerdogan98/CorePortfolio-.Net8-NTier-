using AutoMapper;
using Portfolio.BLL.Abstract;
using Portfolio.BLL.Helper;
using Portfolio.DAL.Abstract;
using Portfolio.DTO;
using Portfolio.Entities;
using System.Linq.Expressions;

namespace Portfolio.BLL.Concrete
{
    public class ExperienceManager(IExperienceDAL experienceDAL, IMapper mapper) : GenericManager<Experience,ExperienceDTO>(experienceDAL, mapper), IExperienceService
    {
		//public async Task TAddAsync(ExperienceDTO experience)
		//      {
		//          var entityDto = mapper.Map<Experience>(experience);
		//          await experienceDAL.AddAsync(entityDto);
		//      }

		//      public async Task TDeleteAsync(ExperienceDTO experience)
		//      {
		//          var entityDto = mapper.Map<Experience>(experience);
		//          experienceDAL.Delete(entityDto);
		//      }

		//      public async Task<IEnumerable<ExperienceDTO>> TGetAllAsync()
		//      {
		//          var experiences = await experienceDAL.GetAllAsync();
		//          var dtos = mapper.Map<IEnumerable<ExperienceDTO>>(experiences);
		//          return dtos;
		//      }

		//      public async Task<IEnumerable<ExperienceDTO>> TGetAllAsync(Expression<Func<ExperienceDTO, bool>> filter)
		//      {
		//	var expression = FilterExpressionConverter<Experience, ExperienceDTO>.Convert(filter);
		//	var entities = await experienceDAL.GetAllAsync(expression);
		//          var dtos = mapper.Map<IEnumerable<ExperienceDTO>>(entities);
		//          return dtos;
		//      }

		//      public ExperienceDTO TGetById(int id)
		//      {
		//          var experience = experienceDAL.GetById(id);
		//          var experienceDto = mapper.Map<ExperienceDTO>(experience);
		//          return experienceDto;
		//      }

		//      public async Task<ExperienceDTO> TGetByIdAsync(int id)
		//      {
		//          var experience = await experienceDAL.GetByIdAsync(id);
		//          var dto = mapper.Map<ExperienceDTO>(experience);
		//          return dto;
		//      }

		//      public void TUpdate(ExperienceDTO experience)
		//      {
		//          var entity = mapper.Map<Experience>(experience);
		//          experienceDAL.Update(entity);
		//      }
	}
}
