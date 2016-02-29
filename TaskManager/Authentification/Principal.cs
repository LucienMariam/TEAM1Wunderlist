using System;
using System.Security.Principal;


namespace TaskManager.Authentification
{
    public class Principal : IPrincipal
    {
        private readonly Identity identity;

        public Principal(Identity identity)
        {
            this.identity = identity;
        }

        #region IPrincipal Members

        public bool IsInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public IIdentity Identity
        {
            get { return identity; }
        }

        #endregion
    }
}