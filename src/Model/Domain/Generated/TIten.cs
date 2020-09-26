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
    public partial class TIten : Entity<TIten, ITItenService>
    {
        public virtual Int32 Id { get; set; } 

        public virtual Double Value { get; set; } 
        public virtual Int32 Quantity { get; set; } 

        public virtual TMovie Movie { get; set; } 
        public virtual TReservation Reservation { get; set; } 


        #region ' Generated Helpers '
        static TIten()
        {
            Identifiers
                .Add(x => x.Id)
;
        }
        
        partial void Initialize();
        
        public static bool operator ==(TIten obj1, TIten obj2)
        {
            return object.Equals(obj1, obj2);
        }

        public static bool operator !=(TIten obj1, TIten obj2)
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
        
        public TIten() 
        {
            Initialize();
        }
        
        public override TIten Clone()
        {
            var cloned = base.Clone();
            return cloned;
        }

        public TIten(Int32 Id) : this()
        {  
            this.Id = Id;
        }
     
        #endregion

    }
}