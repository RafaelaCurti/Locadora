using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.Entities;
using Locadora.Domain;

namespace Locadora.Services
{
    public partial class TPreferenceService : EntityService<TPreference>, ITPreferenceService
    {
        public void SavePreferences(TClient model)
        {
            TPreference.Delete(x => x.Id == model.Id);

            for (int i = 0; i < model.Preference.Length; i++)
            {
                new TPreference()
                {
                    Client = model,
                    Category = TCategory.Load(model.Preference[i])
                }.Save();
            }
        }
    }
}