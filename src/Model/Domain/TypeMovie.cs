using System.ComponentModel;

namespace Locadora.Domain
{
    public enum TypeMovie
    {
        [Description("Filme")]
        Movie = 0,
        [Description("Documentário")]
        Documentary,
        [Description("Série")]
        Serie
    }
}
