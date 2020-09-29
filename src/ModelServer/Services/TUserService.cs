using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.Entities;
using Locadora.Domain;
using System.Security.Cryptography;

namespace Locadora.Services
{
    public partial class TUserService : EntityService<TUser>, ITUserService
    {
        public byte[] HashPassword(string password)
        {
            return SHA384.Create().ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public void Edit(TUser model)
        {
            var client = TUser.Load(model.Id);
            client.Name = model.Name;
            client.EnumProfileUser = model.EnumProfileUser;
            client.Update();
        }
    }
}