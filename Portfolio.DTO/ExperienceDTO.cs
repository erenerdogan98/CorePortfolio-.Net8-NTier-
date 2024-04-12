using System.ComponentModel.DataAnnotations;

namespace Portfolio.DTO
{
	public class ExperienceDTO
	{
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Head { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
    }
}
