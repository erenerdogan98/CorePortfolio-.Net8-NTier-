namespace Portfolio.API.Core.Entities
{
	public class Log
	{
        public int Id { get; set; }
		public string? UserName { get; set; }
		public string Description { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		public DateTime UpdatedAt { get; set; } = DateTime.Now;
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;
	}
}
