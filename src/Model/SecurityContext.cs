using Locadora.Domain;
using Simple;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Principal;
using MaravilhasTerra.Domain;

namespace Locadora
{
    public class SecurityContext
    {
        public static SecurityContext Do
        {
            get { return SimpleContext.Data.Singleton<SecurityContext>(); }
        }

        UserSecurity _user = null;
        bool _isAuthenticated = false;
        Func<IIdentity> _identityGetter = null;
        //HashSet<Permission> _permissions = null;

        //public HashSet<Permission> Permissions
        //{
        //    get
        //    {
        //        if (_permissions == null)
        //            _permissions = new HashSet<Permission>(TUser.ListPermissions(User));
        //        return _permissions;
        //    }
        //}

        //public bool HasPermission(Permission key)
        //{
        //    if (_user == null || Permissions == null || !Permissions.Any())
        //        return false;
        //    return Permissions.Contains(key);
        //}

        public void Demand(bool action)
        {
            if (!action) throw new AuthorizationException();
        }

        public bool IsAuthenticated { get { return _isAuthenticated; } }

        public UserSecurity User { get { return _user; } }

        public SecurityContext Refresh()
        {
            return Init(_identityGetter);
        }

        public SecurityContext Init(Func<IIdentity> identityGetter)
        {
            _identityGetter = identityGetter;
            _isAuthenticated = TryGet(x => x.IsAuthenticated, false);

            var username = TryCast(x => x.Name, string.Empty);
            if (_isAuthenticated && !string.IsNullOrEmpty(username))
            {
                //var model = TUser.FindByUsername(username);
                //if (model != null)
                    //_user = new UserSecurity(model);
            }
            else
                _user = null;
            if (_user == null)
                _isAuthenticated = false;
            return this;
        }

        public SecurityContext Init(Func<IIdentity> identityGetter, Subdomain subdomain)
        {
            _identityGetter = identityGetter;
            _isAuthenticated = TryGet(x => x.IsAuthenticated, false);

            var username = TryCast(x => x.Name, string.Empty);
            if (_isAuthenticated && !string.IsNullOrEmpty(username))
            {
                //if (subdomain == Subdomain.Backoffice || subdomain == Subdomain.Store)
                //{
                //    //var client = TClient.FindByUsername(username);
                //    //var enabledAccess = TParameter.FindByEnum(subdomain == Subdomain.Backoffice ? Parameter.BlockAccessEV : Parameter.BlockAccessStore) == null;
                //    //if (client != null && enabledAccess)
                //        //_user = new UserSecurity(client, subdomain);
                //}
                //else
                //{
                //    //var enabledAccess = TParameter.FindByEnum(subdomain == Subdomain.Painel ? Parameter.BlockAccessAdmin : Parameter.BlockAccessPDV) == null;
                //    //var model = TUser.FindByUsername(username);
                //    //if (model != null && (enabledAccess || username == "admin"))
                //        _user = new UserSecurity(model);
                //}
            }
            else
                _user = null;
            if (_user == null)
                _isAuthenticated = false;
            return this;
        }

        public SecurityContext Init(SimpleContext context)
        {
            if (context != null && context.Username != null)
                Init(() => new GenericIdentity(context.Username));
            else
                Init(() => null);
            return this;
        }

        protected V TryCast<T, V>(Func<IIdentity, T> attr, V def)
            where V : IConvertible
            where T : class, IConvertible
        {
            var obj = TryGet<T>(attr, null);
            if (obj == null) return def;
            try
            {
                return (V)Convert.ChangeType(obj, typeof(V));
            }
            catch (FormatException)
            {
                return def;
            }
        }

        protected T TryGet<T>(Func<IIdentity, T> attr, T def)
        {
            try
            {
                return attr(_identityGetter());
            }
            catch (NullReferenceException)
            {
                return def;
            }
        }
    }
}