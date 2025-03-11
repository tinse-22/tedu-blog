using Microsoft.AspNetCore.Identity;
using TeduBlog.Core.Domain.Identity;

namespace TeduBlog.Data
{
    public class DataSeeder
    {
        public async Task SeedAsync(TeduBlogContext context)
        {
            var passwordHasher = new PasswordHasher<AppUser>();

            var rootAminRoleId = Guid.NewGuid();
            if (!context.Roles.Any())
            {
                await context.Roles.AddAsync(new AppRole()
                {
                    Id = rootAminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    DisplayName = "Administrator"
                });
                await context.SaveChangesAsync();
            }

            if (!context.Users.Any())
            {
                var userId = Guid.NewGuid();
                var user = new AppUser()
                {
                    Id = userId,
                    FirstName = "Vu Trung",
                    LastName = "Tin",
                    Email = "trungtin2272002@gmail.com",
                    NormalizedEmail = "TRUNGTIN2272002@GMAIL.COM",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    IsActive = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = default,
                    DateCreated = DateTime.Now
                };
                user.PasswordHash = passwordHasher.HashPassword(user, "12345");
                await context.Users.AddAsync(user);

                await context.UserRoles.AddAsync(new IdentityUserRole<Guid>()
                {
                    RoleId = rootAminRoleId,
                    UserId = userId
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
