namespace AutoMapperDemo.Models.Entities
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
