using Simple.Entities;
using Locadora.Domain;
using Simple.Services;
using Locadora.Services;
using System;
using System.Collections.Generic;
using NHibernate.SqlCommand;

namespace Locadora.Domain
{
    public partial class TParameter
    {
        public static TUser FindByEnum(Parameter parameter)
        {
            return Service.FindByEnum(parameter);
        }
    }
}
