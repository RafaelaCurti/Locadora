using Simple.Entities;
using Locadora.Domain;
using Simple.Services;
using Locadora.Services;

namespace Locadora.Services
{
    public partial interface ITReservationService : IEntityService<TReservation>, IService
    {
    }
}