using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.Entities;
using Locadora.Domain;
using System.Security.Cryptography;

namespace Locadora.Services
{
    public partial class TClientService : EntityService<TClient>, ITClientService
    {
        public byte[] HashPassword(string password)
        {
            return SHA384.Create().ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public void Edit(TClient model)
        {
            var client = TClient.Load(model.Id);
            client.Name = model.Name;
            client.Email = model.Email;
            client.Telephone = model.Telephone;
            client.Login = model.Login;
            //client.Category = model.Category;
            client.Update();
        }
        //void SaveCategories(TPreference model);
        //public void SaveCategories(TClient model)
        //{
        //    TPreference.Delete(x => x.Preference.Id == model.Id);
        //    for (int i = 0; i < model.Preference.Length; i++)
        //    {
        //        new TPreference()
        //        {
        //            Preference = model,
        //            = TPreference.Load(model.Categories[i])
        //        }.Save();
        //    }
        //}
    }
}