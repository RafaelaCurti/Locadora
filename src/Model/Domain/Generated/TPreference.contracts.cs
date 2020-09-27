using Simple.Entities;
using Locadora.Domain;
using Simple.Services;
using Locadora.Services;
using System;

namespace Locadora.Domain
{
    public partial class TPreference
    {
        public static void SavePreferences(TClient model) 
        {
			Service.SavePreferences(model);
		}

    }
}