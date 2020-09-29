using System;

namespace Locadora.Domain
{
    public sealed class Alert
    {
        public String Type { get; set; }
        public String Message { get; set; }

        public Alert(string type, string message)
        {
            Type = type;
            Message = message;
        }
    }
}
