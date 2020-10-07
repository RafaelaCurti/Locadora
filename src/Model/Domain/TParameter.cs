using Locadora.Domain;
using System;
using System.ComponentModel;

namespace MaravilhasTerra.Domain
{
    public enum Parameter
    {
        [Description("Login com captcha")]
        LoginWithCaptcha,
        [Description("Confirmação de conta por e-mail")]
        ConfirmationByEmail,
        [Description("CEP de origem")]
        OriginZipcode,
        [Description("Visualizar gráficos no EV")]
        ViewChart,
        [Description("Pagar pedidos com saldo apenas do próprio consultor e seus downlines")]
        PayOrdersWithBalanceOnlyInTheNet,
        [Description("Habilitar transferências")]
        EnableTransfers,
        [Description("Visualizar linha ascendente")]
        ViewUpline,
        [Description("Utilização de licença")]
        UseVoucher,
        [Description("1ª Integração de busca por CEP (api.findcep.com)")]
        FirstIntegrationWithCorreios,
        [Description("2ª Integração de busca por CEP (viacep.com.br)")]
        SecondIntegrationWithCorreios,
        [Description("Bloqueio de acesso ao Painel")]
        BlockAccessAdmin,
        [Description("Bloqueio de acesso ao EV")]
        BlockAccessEV,
        [Description("Bloqueio de acesso a Loja")]
        BlockAccessStore,
        [Description("Bloqueio de acesso ao PDV")]
        BlockAccessPDV,
        [Description("Permitir patrocinar sem realizar a adesão")]
        AllowToIndicateWithoutMembership,
        [Description("Liberação de bônus mediante ao número do PIS")]
        ReleaseBonusNumberPis,
        [Description("Liberação de saque mediante ao número do PIS")]
        ReleaseWithdrawalNumberPis,
        [Description("Acréscimo de dias no tempo de entrega da transportadora")]
        AddingDaysForDeliveryByCarrier,
        [Description("Qualificação mínima para ser Executivo")]
        MinQualificationExecutive,
        [Description("Limite de horas para consultor excluir própria conta")]
        HoursConsultantAutoDelete,
        [Description("Permitir efetuar somente um pedido de adesão por vez")]
        AllowOnlyOneKitOrder,
        [Description("Dias de bloqueio para cadastro do convidado")]
        BlockingDaysForGuestRegistration,
        [Description("Quantidade de dias de limite de crédito")]
        QuantityDaysCreditLimit,
        [Description("Valor de limite de crédito")]
        ValueCreditLimit,
        [Description("Revender somente para própria rede")]
        ResellOnlyToOwnNetwork,
        [Description("Valor mínimo para frete grátis no EV")]
        MinValueToFreeShippingEV
    }
    public partial class TParameter
    {
        public virtual TUser User { get; set; }
        public virtual String Ip { get; set; }
        public virtual String OldValue { get; set; }
    }
}

