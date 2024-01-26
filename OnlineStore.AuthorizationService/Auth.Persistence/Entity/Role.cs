namespace Auth.Persistence.Entity
{
    internal class Role
    {
        public string RoleName { get; set; }
        public List<User> Users { get; set; }
    }
}
