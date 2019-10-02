using System;
using System.Collections.Generic;
using Identifiers.AspNetCore.RouteContraints;
using Microsoft.AspNetCore.Routing;
using Xunit;

namespace Identifiers.AspNetCore.Tests.RouteConstraints
{
    public class IdentifierRouteConstraintTests
    {
        [Theory]
        [InlineData(-1, true)]
        [InlineData(0, true)]
        [InlineData(1, true)]
        [InlineData(short.MaxValue, true)]
        [InlineData(int.MaxValue, true)]
        [InlineData(long.MaxValue, true)]
        [InlineData("1", true)]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("a", false)]
        public void WhenConstructedWithGenericTypeLong_ItShouldUseLongRouteConstraint(object routeValue, bool expectedResult)
        {
            // Arrange
            var routeConstraint = new IdentifierRouteConstraint<long>();

            var routeValues = RouteValueDictionary.FromArray(new[]
            {
                new KeyValuePair<string, object>("id", routeValue),
            });

            // Act
            var result = routeConstraint.Match(null, null, "id", routeValues, RouteDirection.IncomingRequest);

            // Assert
            Assert.Equal(expectedResult, result);
        }


        [Theory]
        [InlineData(-1, true)]
        [InlineData(0, true)]
        [InlineData(1, true)]
        [InlineData(short.MaxValue, true)]
        [InlineData(int.MaxValue, true)]
        [InlineData(long.MaxValue, false)]
        [InlineData("1", true)]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("a", false)]
        public void WhenConstructedWithGenericTypeInt_ItShouldUseIntRouteConstraint(object routeValue, bool expectedResult)
        {
            // Arrange
            var routeConstraint = new IdentifierRouteConstraint<int>();

            var routeValues = RouteValueDictionary.FromArray(new[]
            {
                new KeyValuePair<string, object>("id", routeValue),
            });

            // Act
            var result = routeConstraint.Match(null, null, "id", routeValues, RouteDirection.IncomingRequest);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(-1, true)]
        [InlineData(0, true)]
        [InlineData(1, true)]
        [InlineData(short.MaxValue, true)]
        [InlineData(int.MaxValue, true)]
        [InlineData(long.MaxValue, false)]
        [InlineData("1", true)]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("a", false)]
        public void WhenConstructedWithGenericTypeShort_ItShouldUseShortRouteConstraint(object routeValue, bool expectedResult)
        {
            // Arrange
            var routeConstraint = new IdentifierRouteConstraint<short>();

            var routeValues = RouteValueDictionary.FromArray(new[]
            {
                new KeyValuePair<string, object>("id", routeValue),
            });

            // Act
            var result = routeConstraint.Match(null, null, "id", routeValues, RouteDirection.IncomingRequest);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000000", true)]
        [InlineData("85F872AA-C162-454E-9703-E700777717B4", true)]
        [InlineData(-1, false)]
        [InlineData(0, false)]
        [InlineData(1, false)]
        [InlineData(short.MaxValue, false)]
        [InlineData(int.MaxValue, false)]
        [InlineData(long.MaxValue, false)]
        [InlineData("1", false)]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("a", false)]
        public void WhenConstructedWithGenericTypeGuid_ItShouldUseGuidRouteConstraint(object routeValue, bool expectedResult)
        {
            // Arrange
            var routeConstraint = new IdentifierRouteConstraint<Guid>();

            var routeValues = RouteValueDictionary.FromArray(new[]
            {
                new KeyValuePair<string, object>("id", routeValue),
            });

            // Act
            var result = routeConstraint.Match(null, null, "id", routeValues, RouteDirection.IncomingRequest);

            // Assert
            Assert.Equal(expectedResult, result);
        }


        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000000", true)]
        [InlineData("85F872AA-C162-454E-9703-E700777717B4", true)]
        [InlineData(-1, true)]
        [InlineData(0, true)]
        [InlineData(1, true)]
        [InlineData(short.MaxValue, true)]
        [InlineData(int.MaxValue, true)]
        [InlineData(long.MaxValue, true)]
        [InlineData("1", true)]
        [InlineData(null, true)]
        [InlineData("", true)]
        [InlineData("a", true)]
        public void WhenConstructedWithUnknownGenericTypeString_ItShouldUseNoRouteConstraint(object routeValue, bool expectedResult)
        {
            // Arrange
            var routeConstraint = new IdentifierRouteConstraint<string>();

            var routeValues = RouteValueDictionary.FromArray(new[]
            {
                new KeyValuePair<string, object>("id", routeValue),
            });

            // Act
            var result = routeConstraint.Match(null, null, "id", routeValues, RouteDirection.IncomingRequest);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000000", true)]
        [InlineData("85F872AA-C162-454E-9703-E700777717B4", true)]
        [InlineData(-1, true)]
        [InlineData(0, true)]
        [InlineData(1, true)]
        [InlineData(short.MaxValue, true)]
        [InlineData(int.MaxValue, true)]
        [InlineData(long.MaxValue, true)]
        [InlineData("1", true)]
        [InlineData(null, true)]
        [InlineData("", true)]
        [InlineData("a", true)]
        public void WhenConstructedWithUnknownGenericTypeDateTime_ItShouldUseNoRouteConstraint(object routeValue, bool expectedResult)
        {
            // Arrange
            var routeConstraint = new IdentifierRouteConstraint<DateTime>();

            var routeValues = RouteValueDictionary.FromArray(new[]
            {
                new KeyValuePair<string, object>("id", routeValue),
            });

            // Act
            var result = routeConstraint.Match(null, null, "id", routeValues, RouteDirection.IncomingRequest);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
