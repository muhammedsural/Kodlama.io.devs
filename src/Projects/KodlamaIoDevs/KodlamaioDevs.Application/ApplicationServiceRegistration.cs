using Core.Application.Pipelines.Validation;
using FluentValidation;
using KodlamaioDevs.Application.Features.Developers.Rules;
using KodlamaioDevs.Application.Features.ProgrammingLanguages.Rules;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using KodlamaioDevs.Application.Features.GitHubProfiles.Rules;
using KodlamaioDevs.Application.Features.Technologies.Rules;

namespace KodlamaioDevs.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<ProgrammingLanguageBusinessRules>();
            services.AddScoped<GithubProfileBusinessRules>();
            services.AddScoped<DeveloperBusinessRules>();
            services.AddScoped<TechnologyBusinessRules>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            return services;
        }
    }
}
