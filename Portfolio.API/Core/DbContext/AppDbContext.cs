using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.API.Core.Entities;

namespace Portfolio.API.Core.DbContext
{
	public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<AppUser>(options)
	{
		public DbSet<Log> Logs { get; set; }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			// Config anything we want
			//1
			builder.Entity<AppUser>(e =>
			{
				e.ToTable("Users");
			});
			//2
			builder.Entity<IdentityUserClaim<string>>(e =>
			{
				e.ToTable("UserClaims");
			});
			//3
			builder.Entity<IdentityUserLogin<string>>(e =>
			{
				e.ToTable("UserLogins");
			});
			//4
			builder.Entity<IdentityUserToken<string>>(e =>
			{
				e.ToTable("UserTokens");
			});
			//5
			builder.Entity<IdentityRole>(e =>
			{
				e.ToTable("Roles");
			});
			//6
			builder.Entity<IdentityRoleClaim<string>>(e =>
			{
				e.ToTable("RoleClaims");
			});
			//7
			builder.Entity<IdentityUserRole<string>>(e =>
			{
				e.ToTable("UserRoles");
			});
		}
	}
}
