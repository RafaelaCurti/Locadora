using System.Web;
using Simple.Entities;
using Telerik.Web.Mvc;
using Simple.Web.Mvc.Telerik;
using System.Web.Mvc;
using Locadora.Domain;
using Simple.Validation;

namespace Locadora.Web.Helpers
{
    public static class ControllerExtensions
    {
        public static IPage<T> List<T>(this GridCommand command, int pageSize)
            where T : class, IEntity<T>
        {
            var def = GridParser.Parse<T>(command, pageSize);
            return Entity<T>.Linq(def.Map, def.Reduce);
        }

    }
}
