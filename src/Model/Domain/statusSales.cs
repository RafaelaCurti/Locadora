using System.ComponentModel;

namespace Locadora.Domain
{
    public enum StatusSale
    {
        [Description("Pendente")]
        APendente = 0,
        [Description("Faturado")]
        Faturado,
        [Description("Cancelado")]
        Cancelado
    }
}
