using Microsoft.AspNetCore.Identity;

namespace GymManagementMVC.Models
{
    public class User : IdentityUser
    {
        public int Year { get; set; } // рік народження або інші властивості
    }
}
