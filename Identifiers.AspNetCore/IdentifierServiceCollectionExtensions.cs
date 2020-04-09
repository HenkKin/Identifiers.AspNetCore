using Identifiers.AspNetCore.ModelBinders;
using Identifiers.AspNetCore.RouteContraints;
using Identifiers.Extensions.Newtonsoft.Json.JsonConverters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Identifiers.AspNetCore
{
    public static class IdentifierServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentifiers<TInternalClrType>(this IServiceCollection services)
        {
            services.Configure<MvcOptions>(options =>
            {
                options.ModelBinderProviders.Insert(0, new IdentifierModelBinderProvider<TInternalClrType>());
            });


            services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("identifier", typeof(IdentifierRouteConstraint<TInternalClrType>));
            });


            services.Configure<MvcNewtonsoftJsonOptions>(options =>
            {
                // This fixes IConvertible issues on Identifier 
                // options.SerializerSettings.Converters.Add(new IdentifierJsonConverter<TInternalClrType>());
                options.SerializerSettings.Converters.Add(new NullableIdentifierJsonConverter<TInternalClrType>());
            });

            return services;
        }
    }
}