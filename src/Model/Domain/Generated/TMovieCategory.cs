using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.Reflection;
using Simple.Entities;
using Locadora.Services;

namespace Locadora.Domain
{
    [Serializable]
    public partial class TMovieCategory : Entity<TMovieCategory, ITMovieCategoryService>
    {
        public virtual Int32 Id { get; set; } 


        public virtual TCategory Category { get; set; } 
        public virtual TMovie Movie { get; set; } 


        #region ' Generated Helpers '
        static TMovieCategory()
        {
            Identifiers
                .Add(x => x.Id)
;
        }
        
        partial void Initialize();
        
        public static bool operator ==(TMovieCategory obj1, TMovieCategory obj2)
        {
            return object.Equals(obj1, obj2);
        }

        public static bool operator !=(TMovieCategory obj1, TMovieCategory obj2)
        {
            return !(obj1 == obj2);
        }
        
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        
        public TMovieCategory() 
        {
            Initialize();
        }
        
        public override TMovieCategory Clone()
        {
            var cloned = base.Clone();
            return cloned;
        }

        public TMovieCategory(Int32 Id) : this()
        {  
            this.Id = Id;
        }
     
        #endregion

    }
}