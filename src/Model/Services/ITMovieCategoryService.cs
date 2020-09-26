using Simple.Entities;
using Locadora.Domain;
using Simple.Services;
using Locadora.Services;
using System;

namespace Locadora.Services
{
    public partial interface ITMovieCategoryService : IEntityService<TMovieCategory>, IService
    {
        void SaveCategories(TMovie model);
    }
}