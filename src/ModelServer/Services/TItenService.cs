using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.Entities;
using Locadora.Domain;

namespace Locadora.Services
{
    public partial class TItenService : EntityService<TIten>, ITItenService
    {
        public void SaveIten(TReservation model)
        {
            TIten.Delete(x => x.Movie.Id == model.Id);
            if (model.Iten != null)
            {
                for (int i = 0; i < model.Itensdareserva.Length; i++)
                {
                    new TIten()
                    {
                        Reservation = model,
                        Movie = TMovie.Load(model.Itensdareserva[i])
                    }.Save();
                }
            }
        }
    }
}