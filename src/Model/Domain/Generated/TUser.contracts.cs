using Simple.Entities;
using Locadora.Domain;
using Simple.Services;
using Locadora.Services;
using System;

namespace Locadora.Domain
{
    public partial class TUser
    {
        public static Byte[] HashPassword(String password)
        {
            return Service.HashPassword(password);
        }

        public virtual void Edit()
        {
            Service.Edit(this);
        }
    }

}
