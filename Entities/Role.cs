namespace RestaurantAPI.Entities
{
    public class Role
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
