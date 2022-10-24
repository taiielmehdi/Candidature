using Candidature.Business.Interfaces;
using Candidature.Business.Repositories;
using Candidature.Data.Contexts;

namespace Candidature.Front.Extensions
{
    public static class DependenciesExtensions
    {
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<CandidatureContext>();
            services.AddScoped<ICandidat, CandidatRepository>();
            services.AddScoped<IRef, RefRepository>();

            return services;
        }
    }
}
