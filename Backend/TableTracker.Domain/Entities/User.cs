namespace TableTracker.Domain.Entities
{
    public class User : IEntity<long>
    {
        public long Id { get; set; } 

        public string FullName { get; set; }

        public string Avatar { get; set; }

        //public UserRole Role { get; set; }

        public string Email { get; set; }
    }
}
