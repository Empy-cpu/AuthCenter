using Microsoft.AspNetCore.Identity;

namespace AuthServer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? TenantId { get; set; }
    }
}
