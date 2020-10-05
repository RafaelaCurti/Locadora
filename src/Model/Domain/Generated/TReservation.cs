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
    public partial class TReservation : Entity<TReservation, ITReservationService>
    {
        public virtual Int32 Id { get; set; } 

        public virtual DateTime Withdraw { get; set; } 
        public virtual DateTime Devolution { get; set; } 

        public virtual TClient Client { get; set; } 

        public virtual ICollection<TIten> TItens { get; set; } 
        public virtual ICollection<TSale> TSales { get; set; }
        public object [] Itensdareserva { get; set; }

        #region ' Generated Helpers '
        static TReservation()
        {
            Identifiers
                .Add(x => x.Id)
;
        }
        
        partial void Initialize();
        
        public static bool operator ==(TReservation obj1, TReservation obj2)
        {
            return object.Equals(obj1, obj2);
        }

        public static bool operator !=(TReservation obj1, TReservation obj2)
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
        
        public TReservation() 
        {
            this.TItens = new HashSet<TIten>();
            this.TSales = new HashSet<TSale>();
            Initialize();
        }
        
        public override TReservation Clone()
        {
            var cloned = base.Clone();
            cloned.TItens = null;
            cloned.TSales = null;
            return cloned;
        }

        public TReservation(Int32 Id) : this()
        {  
            this.Id = Id;
        }
     
        #endregion

    }
}