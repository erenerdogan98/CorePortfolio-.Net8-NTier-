using System.ComponentModel.DataAnnotations;

namespace Portfolio.DTO
{
	public class MessageDTO
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string SurName { get; set; }
		public string Email { get; set; }
		public string Subject { get; set; }
		public string Detail { get; set; }
		public DateTime SendDate { get; set; }
		public bool IsRead { get; set; }
	}
}
