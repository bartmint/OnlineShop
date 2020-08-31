using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Infrastructure
{
    public class UserData : IdentityUser
    {

        public string City { get; set; }
        public string LastName { get; set; }
        public string AdressLine { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }


    }

}
