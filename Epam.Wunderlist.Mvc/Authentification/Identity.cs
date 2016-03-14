﻿using System;
using System.Security.Principal;
using BLL.Entities;

namespace TaskManager.Authentification
{
    public class Identity : IIdentity
    {
        public Identity(IPrincipal user)
        {
            var current = user?.Identity as Identity;
            if (current == null)
            {
                Login = "Guest";
                return;
            }

            Id = current.Id;
            Login = current.Login;
            Email = current.Email;
            RememberMe = current.RememberMe;
        }


        public Identity(UserEntity user)
        {
            if (user == null)
            {
                Login = "Guest";
                return;
            }

            Id = user.Id;
            Login = user.Login;
            Email = user.Email;
        }

        public Identity(Cookie user)
        {
            if (user == null)
            {
                Login = "Guest";
                return;
            }

            Id = user.Id;
            Login = user.Login;
            Email = user.Email;
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public bool RememberMe { get; set; }

        #region IIdentity Members

        public string AuthenticationType
        {
            get { return "SuperAuthen"; }
        }

        public bool IsAuthenticated
        {
            get { return !(Id == 0 || string.IsNullOrWhiteSpace(Email)); }
        }

        public string Name { get { return Id.ToString(); } }
      
        #endregion
    }
}