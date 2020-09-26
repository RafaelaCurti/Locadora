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
    public partial class TSale : Entity<TSale, ITSaleService>
    {
        public virtual Int32 Id { get; set; } 

        public virtual StatusSale EnumStatusSale { get; set; } 

        public virtual TReservation Reservation { get; set; } 


        #region ' Generated Helpers '
        static TSale()
        {
            Identifiers
                .Add(x => x.Id)
;
        }
        
        partial void Initialize();
        
        public static bool operator ==(TSale obj1, TSale obj2)
        {
            return object.Equals(obj1, obj2);
        }

        public static bool operator !=(TSale obj1, TSale obj2)
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
        
        public TSale() 
        {
            Initialize();
        }
        
        public override TSale Clone()
        {
            var cloned = base.Clone();
            return cloned;
        }

        public TSale(Int32 Id) : this()
        {  
            this.Id = Id;
        }
     
        #endregion

    }
}