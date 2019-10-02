using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;

namespace Identifiers.AspNetCore.RouteContraints
{
    internal class IdentifierRouteConstraint<TInternalClrType> : IRouteConstraint
    {
        private readonly IRouteConstraint _routeConstraint;

        public IdentifierRouteConstraint()
        {
            if (typeof(TInternalClrType) == typeof(short))
            {
                _routeConstraint = new IntRouteConstraint();
            }
            else if (typeof(TInternalClrType) == typeof(int))
            {
                _routeConstraint = new IntRouteConstraint();
            }
            else if (typeof(TInternalClrType) == typeof(long))
            {
                _routeConstraint = new LongRouteConstraint();
            }
            else if (typeof(TInternalClrType) == typeof(Guid))
            {
                _routeConstraint = new GuidRouteConstraint();
            }
            else
            {
                _routeConstraint = null;
            }
        }

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (_routeConstraint != null)
            {
                return _routeConstraint.Match(httpContext, route, routeKey, values, routeDirection);
            }

            return true;
        }
    }
}