using LoginTest.Models.Abstractions;

namespace LoginTest.Models
{
    public class User : Entity
    {

        public string Login { get; set; }

        public string Pass { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public int CountryId { get; set; }

    }
}
