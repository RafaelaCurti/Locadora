using Simple.Entities;
using Locadora.Domain;
using Simple.Services;
using Locadora.Services;
using System;

namespace Locadora.Domain
{
    public partial class TMovieCategory
    {
        public static void SaveCategories(TMovie model) 
        {
			Service.SaveCategories(model);
		}

    }
}