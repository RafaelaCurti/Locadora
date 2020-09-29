using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Locadora
{
    [global::System.Serializable]
    public class AuthorizationException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public AuthorizationException() { }
        public AuthorizationException(string permission) : base(permission) { }
        public AuthorizationException(string permission, Exception inner) : base(permission, inner) { }

        protected AuthorizationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
