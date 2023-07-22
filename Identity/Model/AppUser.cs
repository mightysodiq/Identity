using Microsoft.AspNetCore.Identity;

namespace Identity.Model
{
    public class AppUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
         

    }
}
