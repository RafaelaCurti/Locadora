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
    public partial class TPreference : Entity<TPreference, ITPreferenceService>
    {
        public virtual Int32 Id { get; set; } 


        public virtual TCategory Category { get; set; } 
        public virtual TClient Client { get; set; }
        public virtual String Name { get; set; }
        public virtual String Preference { get; set; }


        #region ' Generated Helpers '
        static TPreference()
        {
            Identifiers
                .Add(x => x.Id);
        }
        
        partial void Initialize();
        
        public static bool operator ==(TPreference obj1, TPreference obj2)
        {
            return object.Equals(obj1, obj2);
        }

        public static bool operator !=(TPreference obj1, TPreference obj2)
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
        
        public TPreference() 
        {
            Initialize();
        }
        
        public override TPreference Clone()
        {
            var cloned = base.Clone();
            return cloned;
        }

        public TPreference(Int32 Id) : this()
        {  
            this.Id = Id;
        }
     
        #endregion

    }
}