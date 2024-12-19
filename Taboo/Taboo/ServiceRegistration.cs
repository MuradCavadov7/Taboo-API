using Taboo.Services.Abstracts;
using Taboo.Services.Implements;

namespace Taboo
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ILanguageServices, LanguageServices>();
            services.AddScoped<IWordService, WordService>();
            return services;
        }

    }
}
