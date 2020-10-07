using System;

namespace Locadora.Domain
{
    public class UserSecurity
    {
        public virtual Int32 Id { get; set; }
        public virtual String Username { get; set; }
        public virtual Subdomain Subdomain { get; set; }
        public virtual Boolean IsActive { get; set; }

        public UserSecurity(TUser user)
        {
            this.Id = user.Id;
            this.Username = user.Login;
            this.IsActive = user.IsActive;
            this.Subdomain = Subdomain.Painel;
        }

        public UserSecurity(TClient client, Subdomain subdomain)
        {
            this.Id = client.Id;
            this.Username = client.Login;
            this.Subdomain = subdomain;
        }

    }
}
