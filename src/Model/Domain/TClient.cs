using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Locadora.Domain
{
    public partial class TClient
    {
        public virtual String PasswordString { get; set; }
        public virtual ICollection<TMovieCategory> TMovieCategories { get; set; }
        public virtual List<TCategory> Category { get; set; }
        public virtual int[] Preference { get; set; }
        public static TClient Authenticate(Login login)
        {
            return Service.Authenticate(login);
        }
        public static string GetErrorLogin(Login model)
        {
            throw new NotImplementedException();
        }
        public virtual Boolean IsActive { get; set; }
        //public static TClient FindByUsername(String username)
        //{
        //    return Service.FindByUsername(username);
        //}
    }
}
