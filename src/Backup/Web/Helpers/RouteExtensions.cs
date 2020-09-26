using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Locadora.Web.Helpers
{
    public class LowercaseRoute : Route
    {
        public LowercaseRoute(string url, IRouteHandler routeHandler)
            : base(url, routeHandler)
        {
        }

        public LowercaseRoute(string url, RouteValueDictionary defaults, IRouteHandler routeHandler)
            : base(url, defaults, routeHandler)
        {
        }

        public LowercaseRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints,
        IRouteHandler routeHandler)
            : base(url, defaults, constraints, routeHandler)
        {
        }

        public LowercaseRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints,
        RouteValueDictionary dataTokens, IRouteHandler routeHandler)
            : base(url, defaults, constraints, dataTokens, routeHandler)
        {
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            VirtualPathData path = base.GetVirtualPath(requestContext, values);

            if (path != null)
            {
                string virtualPath = path.VirtualPath;

                if (virtualPath.LastIndexOf("?") > 0)
                {
                    string leftPart = virtualPath.Substring(0, virtualPath.LastIndexOf("?")).ToLowerInvariant();
                    string queryPart = virtualPath.Substring(virtualPath.LastIndexOf("?"));
                    path.VirtualPath = leftPart + queryPart;
                }
                else
                {
                    path.VirtualPath = path.VirtualPath.ToLowerInvariant();
                }
            }

            return path;
        }
    }

    public static class RouteCollectionExtensions
    {
        public static Route MapLowercaseRoute(this RouteCollection routes, string name, string url)
        {
            return MapLowercaseRoute(routes, name, url, null, null, null);
        }

        public static Route MapLowercaseRoute(this RouteCollection routes, string name, string url, object defaults)
        {
            return MapLowercaseRoute(routes, name, url, defaults, null, null);
        }

        public static Route MapLowercaseRoute(this RouteCollection routes, string name, string url, string[] namespaces)
        {
            return MapLowercaseRoute(routes, name, url, null, null, namespaces);
        }

        public static Route MapLowercaseRoute(this RouteCollection routes, string name, string url, object defaults,
        string[] namespaces)
        {
            return MapLowercaseRoute(routes, name, url, defaults, null, namespaces);
        }

        public static Route MapLowercaseRoute(this RouteCollection routes, string name, string url, object defaults,
        object constraints, string[] namespaces)
        {
            if (routes == null)
            {
                throw new ArgumentNullException("routes");
            }

            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            var route = new LowercaseRoute(url, new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(defaults),
                Constraints = new RouteValueDictionary(constraints),
                DataTokens = new RouteValueDictionary(namespaces),
            };

            if (namespaces != null && namespaces.Length > 0)
            {
                route.DataTokens["Namespaces"] = namespaces;
            }

            routes.Add(name, route);

            return route;
        }
    }

    public static class AreaRouteCollectionExtensions
    {
        public static Route MapLowercaseRoute(this AreaRegistrationContext context, string name, string url)
        {
            return MapLowercaseRoute(context, name, url, null, null, null);
        }

        public static Route MapLowercaseRoute(this AreaRegistrationContext context, string name, string url,
        object defaults)
        {
            return MapLowercaseRoute(context, name, url, defaults, null, null);
        }

        public static Route MapLowercaseRoute(this AreaRegistrationContext context, string name, string url,
        string[] namespaces)
        {
            return MapLowercaseRoute(context, name, url, null, null, namespaces);
        }

        public static Route MapLowercaseRoute(this AreaRegistrationContext context, string name, string url,
        object defaults, string[] namespaces)
        {
            return MapLowercaseRoute(context, name, url, defaults, null, namespaces);
        }

        public static Route MapLowercaseRoute(this AreaRegistrationContext context, string name, string url,
        object defaults,
        object constraints, string[] namespaces)
        {
            if (namespaces == null && context.Namespaces != null)
            {
                namespaces = context.Namespaces.ToArray();
            }

            Route route = context.Routes.MapLowercaseRoute(name, url, defaults, constraints, namespaces);

            route.DataTokens["area"] = context.AreaName;

            route.DataTokens["UseNamespaceFallback"] = (namespaces == null || namespaces.Length == 0);

            return route;
        }
    }
}
