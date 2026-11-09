using Microsoft.AspNetCore.Identity;

namespace CuraFlow.Infrastructure.Identity;

public class AppUser : IdentityUser
{
    public Guid TenantId { get; set; }
}