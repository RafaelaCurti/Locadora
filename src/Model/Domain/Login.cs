using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Domain
{
    public class Login
    {
        public virtual String Username { get; set; }
        public virtual String Password { get; set; }
        public virtual Boolean NeedsToBeActive { get; set; }
        public virtual Boolean NeedsToBeConfirmed { get; set; }
        public virtual Boolean NotConfirmed { get; set; }
        
        //public virtual Subdomain SudDomain { get; set; }  //Verificar se precisa com Matheus

        public virtual String ReturnUrl { get; set; }
        public virtual Boolean Remember { get; set; }
        public virtual Int32 ClientId { get; set; }
        public virtual Boolean RequiresCaptcha { get; set; }
        public virtual Boolean IsCaptchaValid { get; set; }

        public Login()
        {
        }

        public Login(string username, string password, bool active)
        {
            this.Username = username;
            this.Password = password;
            this.NeedsToBeActive = active;
        }
    }
}
