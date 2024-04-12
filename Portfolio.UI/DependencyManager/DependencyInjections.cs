using Portfolio.BLL.Abstract;
using Portfolio.BLL.Concrete;
using Portfolio.BLL.Helper;
using Portfolio.DAL.Abstract;
using Portfolio.DAL.Context;
using Portfolio.DAL.EF;
using Portfolio.DAL.EFRepositories;
using Portfolio.DAL.Repository;
using Portfolio.UI.Map;

namespace Portfolio.UI.DependencyManager
{
    public static class DependencyInjections
    {
        public static void ConfigureMyServices(this IServiceCollection services)
        {
            // for db context injection
            services.AddDbContext<AppDbContext>();
            // DAL dependencies
            services.AddScoped<IAboutDAL, EFAboutRepository>();
            services.AddScoped<IContactDAL, EFContactRepository>();
            services.AddScoped<IExperienceDAL, EFExperienceRepository>();
            services.AddScoped<IFeatureDAL, EFFeatureRepository>();
            services.AddScoped<IMessageDAL, EFMessageRepository>();
            services.AddScoped<IMyPortfolioDAL, EFMyPortfolioRepository>();
            services.AddScoped<ISkillDAL, EFSkillRepository>();
            services.AddScoped<ISocialMediaDAL, EFSocialMeidaRepository>();
            services.AddScoped<ITestimonialDAL, EFTestimonialRepository>();
            services.AddScoped<IToDoListDAL, EFToDoListRepository>();
            services.AddScoped(typeof(IGenericDAL<>), typeof(GenericRepository<>));

            // BLL dependencies
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IExperienceService, ExperienceManager>();
            services.AddScoped<IFeatureService, FeatureManager>();
            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<IMyPortfolioService, MyPortfolioManager>();
            services.AddScoped<ISkillService, SkillManager>();
            services.AddScoped<ISocialMediaService, SocialMediaManager>();
            services.AddScoped<ITestimonialService, TestimonialManager>();
            services.AddScoped<IToDoListService, ToDoListManager>();

            // mapping
            services.AddAutoMapper(typeof(MapProfile));
        }
    }
}
