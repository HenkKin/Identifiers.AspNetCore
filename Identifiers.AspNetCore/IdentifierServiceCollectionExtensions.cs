using System;
using Identifiers.AspNetCore.JsonConverters;
using Identifiers.AspNetCore.ModelBinders;
using Identifiers.AspNetCore.RouteContraints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Identifiers.AspNetCore
{
    public static class IdentifierServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentifiers<TDatabaseClrType>(this IServiceCollection services) where TDatabaseClrType : IConvertible
        {
            services.Configure<MvcOptions>(options =>
            {
                options.ModelBinderProviders.Insert(0, new IdentifierModelBinderProvider<TDatabaseClrType>());
            });


            services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("identifier", typeof(IdentifierRouteConstraint<TDatabaseClrType>));
            });


            services.Configure<MvcNewtonsoftJsonOptions>(options =>
            {
                options.SerializerSettings.Converters.Add(new IdentifierJsonConverter<TDatabaseClrType>());
            });

            return services;
        }
    }
}
