using System.ComponentModel;

namespace Locadora.Domain
{
    public enum Subdomain
    {
        [Description("Loja")]
        Store = 0,
        [Description("Painel")]
        Painel,
        [Description("Escrit�rio")]
        Backoffice,
        [Description("Cadastro")]
        Register,
        [Description("PDV")]
        PDV,
        [Description("API")]
        Api
    }
}

