using AutoMapper;
using Portfolio.BLL.Abstract;
using Portfolio.DAL.Abstract;
using Portfolio.DTO;
using Portfolio.Entities;


namespace Portfolio.BLL.Concrete
{
    public class MyPortfolioManager(IMyPortfolioDAL portfolioDAL, IMapper mapper) : GenericManager<MyPortfolio, MyPortfolioDTO>(portfolioDAL, mapper) , IMyPortfolioService
    {
       
    }
}
