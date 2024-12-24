using Microsoft.AspNetCore.Diagnostics;
using Taboo.DAL;
using Taboo.Enums;
using Taboo.Exceptions;
using Taboo.ExternalServices.Abstracts;
using Taboo.ExternalServices.Implements;
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
            services.AddScoped<IGameService, GameService>();
            services.AddMemoryCache();
            return services;
        }
        public static IServiceCollection AddCacheService(this IServiceCollection services,IConfiguration configuration ,CacheTypes cache = CacheTypes.Local)
        {
            if (cache == CacheTypes.Redis) 
            {
                services.AddStackExchangeRedisCache(opt =>
                {
                    opt.Configuration =
                    configuration.GetConnectionString("Redis");
                    opt.InstanceName = "Taboo_";
                });
                services.AddScoped<ICacheService, RedisService>();
            }
            else
            {
                services.AddMemoryCache();
                services.AddScoped<ICacheService, LocalCacheService>();

            }
            return services;
        }
        public static IApplicationBuilder ExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(x =>
            {
                x.Run(async context =>
                {
                    var feature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = feature!.Error;
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    if (exception is IBaseException ibe)
                    {
                        context.Response.StatusCode = ibe.StatusCode;
                        await context.Response.WriteAsJsonAsync(new
                        {
                            StatusCode = ibe.StatusCode,
                            Message = ibe.ErrorMessage
                        });
                    }
                    else
                    {
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsJsonAsync(new
                        {
                            StatusCode = StatusCodes.Status400BadRequest,
                            Message = exception.Message
                        });
                    }

                });

            });
            return app;
        }
    }
}
