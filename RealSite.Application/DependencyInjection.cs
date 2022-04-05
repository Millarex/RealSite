﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace RealSite.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
          this IServiceCollection services)
        {
            /*services.AddMediatR(Assembly.GetExecutingAssembly());
            //Use validation
            services
               .AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            //Use Pipeline
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(LoggingBehavior<,>));
            return services;*/
        }
    }
}
