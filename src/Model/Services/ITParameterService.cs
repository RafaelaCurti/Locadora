using Simple.Entities;
using Locadora.Domain;
using Simple.Services;
using Locadora.Services;
using System;
using NHibernate.SqlCommand;

namespace Locadora.Services
{
    public partial interface ITParameterService : IEntityService<TParameter>, IService
    {
        TParameter FindByEnum(Parameter parameter);
    }
}