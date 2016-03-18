namespace BLL.Entities
{
    public class UserEntity : IBllEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
    }
}
