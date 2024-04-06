using System.ComponentModel.DataAnnotations;

namespace Portfolio.Entities
{
    public class About
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubDescription { get; set; }
        public string Details { get; set; }
    }
}
