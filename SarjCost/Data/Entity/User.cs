namespace SarjCost.Data.Entity
{
    public class User
    {
        public Guid Id { get; set; }

        public string Email { get; set; }  // Optional if you only want external login

        public string FullName { get; set; }

        public string ProfilePictureUrl { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<ExternalLogin> ExternalLogins { get; set; }
    }

}
