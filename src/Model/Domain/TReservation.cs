using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace Locadora.Domain
{
    public partial class TReservation
    {
        //VERIFICAR PARA APAGAR

        //public virtual TClient Clientes { get; set; }

        //public virtual TMovie Filmes { get; set; }

        //public virtual DateTime DataRetirada { get; set; }

        //public virtual DateTime DataDevolucao { get; set; }
        public virtual Int32 IdClient { get; set; }
        public virtual List<TMovie> Iten { get; set; }
        public virtual StatusSale Sales { get; set; }
        public virtual int[] itensdareserva { get; set; }

        //    public virtual object[] GetItensdareserva()
        //    {
        //        return itensdareserva;
        //    }

        //    public virtual void SetItensdareserva(object[] value)
        //    {
        //        itensdareserva = value;
        //    }
    }

}
