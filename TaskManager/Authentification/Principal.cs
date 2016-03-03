using System;
using System.Security.Principal;


namespace TaskManager.Authentification
{
    public class Principal : IPrincipal
    {
        private readonly Identity _identity;

        public Principal(Identity identity)
        {
            _identity = identity;
        }

        #region IPrincipal Members

        public bool IsInRole(string roleName)
        {
            throw new NotSupportedException();
        }

        public IIdentity Identity
        {
            get { return _identity; }
        }

        #endregion
    }
}