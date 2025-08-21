using Microsoft.AspNetCore.Identity;

namespace Goal_Mate.Models
{
    public class ApplicationUser :IdentityUser
    {
        public virtual List<UserTask> Tasks { get; set; } = new List<UserTask> ();
    }
}
