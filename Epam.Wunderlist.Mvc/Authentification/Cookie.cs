using System;


namespace TaskManager.Authentification
{
    public class Cookie
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public bool RememberMe { get; set; }
    }
}