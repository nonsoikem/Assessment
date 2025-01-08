using Assessment.Application.Mappings;
using Assessment.Application.Services;
using Assessment.Domain.Interfaces.IRepository;
using Assessment.Domain.Interfaces.IServices;
using Assessment.Infrastructure.DatabaseContext;
using Assessment.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Api.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            
            services.AddScoped<IScoreService, ScoreService>();
            services.AddScoped<ICountryService, CountryService>();

            
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Using In-Memory Database as stated in the assessement
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("AssessmentDb"));

            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }

}
