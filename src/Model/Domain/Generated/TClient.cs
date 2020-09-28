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
    public partial class TClient : Entity<TClient, ITClientService>
    {
        public virtual Int32 Id { get; set; } 

        public virtual String Name { get; set; } 
        public virtual String Email { get; set; } 
        public virtual String Telephone { get; set; } 
        public virtual String Login { get; set; } 
        public virtual Byte[] Password { get; set; } 
        public virtual ProfileClient EnumProfileClient { get; set; } 

        public virtual ICollection<TPreference> TPreferences { get; set; } 
        public virtual ICollection<TReservation> TReservations { get; set; }

        #region ' Generated Helpers '
        static TClient()
        {
            Identifiers
                .Add(x => x.Id)
;
        }
        
        partial void Initialize();
        
        public static bool operator ==(TClient obj1, TClient obj2)
        {
            return object.Equals(obj1, obj2);
        }

        public static bool operator !=(TClient obj1, TClient obj2)
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
        
        public TClient() 
        {
            this.TPreferences = new HashSet<TPreference>();
            this.TReservations = new HashSet<TReservation>();
            Initialize();
        }
        
        public override TClient Clone()
        {
            var cloned = base.Clone();
            cloned.TPreferences = null;
            cloned.TReservations = null;
            return cloned;
        }

        public TClient(Int32 Id) : this()
        {  
            this.Id = Id;
        }
     
        #endregion

    }
}