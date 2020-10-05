using Simple.Entities;
using Locadora.Domain;
using Simple.Services;
using Locadora.Services;
using System;

namespace Locadora.Domain
{
    public partial class TIten
    {
        public static void SaveIten(TReservation model) 
        {
			Service.SaveIten(model);
		}

    }
}