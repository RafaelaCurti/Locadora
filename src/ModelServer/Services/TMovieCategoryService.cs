using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.Entities;
using Locadora.Domain;

namespace Locadora.Services
{
    public partial class TMovieCategoryService : EntityService<TMovieCategory>, ITMovieCategoryService
    {
        public void SaveCategories(TMovie model)
        {
            TMovieCategory.Delete(x => x.Movie.Id == model.Id);
            for (int i = 0; i < model.Categories.Length; i++)
            {
                new TMovieCategory()
                {
                    Movie = model,
                    Category = TCategory.Load(model.Categories[i])
                }.Save();
            }
        }
    }
}