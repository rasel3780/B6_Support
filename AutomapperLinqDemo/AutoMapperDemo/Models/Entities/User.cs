namespace AutoMapperDemo.Models.Entities
{
    public class User
    {
        // one - to - one Realationship
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public decimal Salary { get; set; }
        public UserProfile Profile { get; set; }

    }
}
