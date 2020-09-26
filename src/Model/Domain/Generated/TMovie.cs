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
    public partial class TMovie : Entity<TMovie, ITMovieService>
    {
        public virtual Int32 Id { get; set; } 

        public virtual String Code { get; set; } 
        public virtual String Name { get; set; } 
        public virtual Int32? Duration { get; set; } 
        public virtual FormatMovie EnumFormatMovie { get; set; } 
        public virtual TypeMovie EnumTypeMovie { get; set; } 
        public virtual Int32 Stock { get; set; } 
        public virtual DateTime Date { get; set; } 
        public virtual Boolean IsActive { get; set; } 


        public virtual ICollection<TIten> TItens { get; set; } 
        public virtual ICollection<TMovieCategory> TMovieCategories { get; set; } 

        #region ' Generated Helpers '
        static TMovie()
        {
            Identifiers
                .Add(x => x.Id)
;
        }
        
        partial void Initialize();
        
        public static bool operator ==(TMovie obj1, TMovie obj2)
        {
            return object.Equals(obj1, obj2);
        }

        public static bool operator !=(TMovie obj1, TMovie obj2)
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
        
        public TMovie() 
        {
            this.TItens = new HashSet<TIten>();
            this.TMovieCategories = new HashSet<TMovieCategory>();
            Initialize();
        }
        
        public override TMovie Clone()
        {
            var cloned = base.Clone();
            cloned.TItens = null;
            cloned.TMovieCategories = null;
            return cloned;
        }

        public TMovie(Int32 Id) : this()
        {  
            this.Id = Id;
        }
     
        #endregion

    }
}