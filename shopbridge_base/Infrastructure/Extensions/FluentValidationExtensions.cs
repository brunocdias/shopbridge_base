using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System;
using FluentValidation;
using Shopbridge_base.Application.Contract;
using Shopbridge_base.Infrastructure.Utils;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using System.Linq;

namespace Shopbridge_base.Infrastructure.Extensions
{
    public static class FluentValidationExtension
    {
        public static IServiceCollection AddFluentValidation(this IServiceCollection services, Type assemblyContainingValidators)
        {
            services.AddValidatorsFromAssemblyContaining(assemblyContainingValidators);
            services.AddFluentValidationClientsideAdapters();

            return services;
        }

        public static ReturnModel<IEnumerable<ReturnValidation>> GetErrors(this ValidationResult result)
        {
            var errors = result.Errors?.Select(error => new ReturnValidation(error.PropertyName, error.ErrorMessage)).ToList();

            return new ReturnModel<IEnumerable<ReturnValidation>>
            {
                Return = errors,
                Success = !errors.Any()
            };
        }

        public static IServiceCollection AddValidations(this IServiceCollection services)
        {
            services.AddFluentValidation(typeof(PostProductValidator));

            return services;
        }
    }
}
