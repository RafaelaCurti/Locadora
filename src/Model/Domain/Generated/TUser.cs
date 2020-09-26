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
    public partial class TUser : Entity<TUser, ITUserService>
    {
        public virtual Int32 Id { get; set; } 

        public virtual String Name { get; set; } 
        public virtual Byte[] Password { get; set; } 
        public virtual ProfileUser EnumProfileUser { get; set; } 



        #region ' Generated Helpers '
        static TUser()
        {
            Identifiers
                .Add(x => x.Id)
;
        }
        
        partial void Initialize();
        
        public static bool operator ==(TUser obj1, TUser obj2)
        {
            return object.Equals(obj1, obj2);
        }

        public static bool operator !=(TUser obj1, TUser obj2)
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
        
        public TUser() 
        {
            Initialize();
        }
        
        public override TUser Clone()
        {
            var cloned = base.Clone();
            return cloned;
        }

        public TUser(Int32 Id) : this()
        {  
            this.Id = Id;
        }
     
        #endregion

    }
}