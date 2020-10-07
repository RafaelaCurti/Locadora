using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.Entities;
using Locadora.Domain;
using System.Security.Cryptography;
using NHibernate.SqlCommand;
using NHibernate.Criterion;

namespace Locadora.Services
{
    public partial class TParameterService : EntityService<TParameter>, ITParameterService
    {
        public TParameter FindByEnum(Parameter parameter)
        {
            return Session.CreateCriteria<TParameter>()
            .Add(Restrictions.Eq("EnumParameter", parameter))
            .Add(Restrictions.Eq("IsActive", true))
            .SetMaxResults(1)
            .UniqueResult<TParameter>();
        }
    }
}