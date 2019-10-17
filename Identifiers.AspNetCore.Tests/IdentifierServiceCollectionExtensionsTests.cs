using Identifiers.AspNetCore.ModelBinders;
using Identifiers.AspNetCore.RouteContraints;
using Identifiers.Extensions.Newtonsoft.Json.JsonConverters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit;

namespace Identifiers.AspNetCore.Tests
{
    public class IdentifierServiceCollectionExtensionsTests
    {
        [Fact]
        public void WhenCalled_ItShouldRegisterIdentifierModelBinderProvider()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddIdentifiers<int>();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Act
            var mvcOptions = serviceProvider.GetRequiredService<IOptions<MvcOptions>>().Value;

            // Assert
            Assert.NotNull(mvcOptions);
            Assert.Equal(typeof(IdentifierModelBinderProvider<int>), mvcOptions.ModelBinderProviders[0].GetType());
        }

        [Fact]
        public void WhenCalled_ItShouldRegisterIdentifierRouteConstraint()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddIdentifiers<int>();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Act
            var routeOptions = serviceProvider.GetRequiredService<IOptions<RouteOptions>>().Value;

            // Assert
            Assert.NotNull(routeOptions);
            Assert.True(routeOptions.ConstraintMap.ContainsKey("identifier"));
            Assert.Equal(typeof(IdentifierRouteConstraint<int>), routeOptions.ConstraintMap["identifier"]);
        }
        

        [Fact]
        public void WhenCalled_ItShouldRegisterIdentifierJsonConverterAndNullableIdentifierJsonConverter()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddIdentifiers<int>();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Act
            var mvcNewtonsoftJsonOptions = serviceProvider.GetRequiredService<IOptions<MvcNewtonsoftJsonOptions>>().Value;

            // Assert
            Assert.NotNull(mvcNewtonsoftJsonOptions);
            Assert.Contains(mvcNewtonsoftJsonOptions.SerializerSettings.Converters, c =>c.GetType() == typeof(IdentifierJsonConverter<int>));
            Assert.Contains(mvcNewtonsoftJsonOptions.SerializerSettings.Converters, c =>c.GetType() == typeof(NullableIdentifierJsonConverter<int>));
        }
    }
}
