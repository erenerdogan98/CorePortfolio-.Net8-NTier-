using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.API.Core.Entities
{
	public class AppUser : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

		[NotMapped]
		public IList<string> Roles { get; set; }
	}
}
