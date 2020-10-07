using Simple.Entities;
using Locadora.Domain;
using Simple.Services;
using Locadora.Services;
using System;

namespace Locadora.Services
{
    public partial interface ITUserService : IEntityService<TUser>, IService
    {
        Byte[] HashPassword(String password);
        void Edit(TUser model);
        //TUser FindByUsername(String username);
    }
}