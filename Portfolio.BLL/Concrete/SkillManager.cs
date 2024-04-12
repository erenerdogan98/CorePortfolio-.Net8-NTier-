using AutoMapper;
using Portfolio.BLL.Abstract;
using Portfolio.DAL.Abstract;
using Portfolio.DTO;
using Portfolio.Entities;


namespace Portfolio.BLL.Concrete
{
	public class SkillManager(ISkillDAL skillDAL, IMapper mapper) : GenericManager<Skill, SkillDTO>(skillDAL, mapper), ISkillService
	{
		
	}
}
