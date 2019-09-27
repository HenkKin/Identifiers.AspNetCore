using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;

namespace Identifiers.AspNetCore.RouteContraints
{
    public class IdentifierRouteConstraint<TDatabaseClrType> : IRouteConstraint
    {
        private readonly IRouteConstraint _routeConstraint;

        public IdentifierRouteConstraint()
        {
            if (typeof(TDatabaseClrType) == typeof(short))
            {
                _routeConstraint = new IntRouteConstraint();
            }
            else if (typeof(TDatabaseClrType) == typeof(int))
            {
                _routeConstraint = new IntRouteConstraint();
            }
            else if (typeof(TDatabaseClrType) == typeof(long))
            {
                _routeConstraint = new LongRouteConstraint();
            }
            else if (typeof(TDatabaseClrType) == typeof(Guid))
            {
                _routeConstraint = new GuidRouteConstraint();
            }
            else
            {
                _routeConstraint = new IntRouteConstraint();
            }
        }

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return _routeConstraint.Match(httpContext, route, routeKey, values, routeDirection);
        }
    }
}
