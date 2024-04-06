using System.ComponentModel.DataAnnotations;

namespace Portfolio.Entities
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }
        public string Head { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
    }
}
