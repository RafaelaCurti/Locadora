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
        public virtual int[] Preferences { get; set; }
       
    }
}
