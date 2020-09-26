using System.ComponentModel;

namespace Locadora.Domain
{
    public enum ProfileUser
    {
        [Description("Admin")]
        Admin = 0,
        [Description("Atendente")]
        Atendente
    }
}
