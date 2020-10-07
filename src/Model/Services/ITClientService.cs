using Simple.Entities;
using Locadora.Domain;
using Simple.Services;
using Locadora.Services;
using System;

namespace Locadora.Services
{
    public partial interface ITClientService : IEntityService<TClient>, IService
    {
        Byte[] HashPassword(String password);
        void Edit(TClient model);
        TClient Authenticate(Login login);
        TClient FindByEmail(String email);
    }
}