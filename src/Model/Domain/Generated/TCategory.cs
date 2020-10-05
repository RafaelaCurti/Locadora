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
    public partial class TCategory : Entity<TCategory, ITCategoryService>
    {
        public virtual Int32 Id { get; set; } 

        public virtual String Name { get; set; } 


        public virtual ICollection<TMovieCategory> TMovieCategories { get; set; } 
        public virtual ICollection<TPreference> TPreferences { get; set; } 

        #region ' Generated Helpers '
        static TCategory()
        {
            Identifiers
                .Add(x => x.Id)
;
        }
        
        partial void Initialize();
        
        public static bool operator ==(TCategory obj1, TCategory obj2)
        {
            return object.Equals(obj1, obj2);
        }

        public static bool operator !=(TCategory obj1, TCategory obj2)
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
        
        public TCategory() 
        {
            this.TMovieCategories = new HashSet<TMovieCategory>();
            this.TPreferences = new HashSet<TPreference>();
            Initialize();
        }
        
        public override TCategory Clone()
        {
            var cloned = base.Clone();
            cloned.TMovieCategories = null;
            cloned.TPreferences = null;
            return cloned;
        }

        public TCategory(Int32 Id) : this()
        {  
            this.Id = Id;
        }
     
        #endregion

    }
}