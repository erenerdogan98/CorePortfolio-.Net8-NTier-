using System.ComponentModel.DataAnnotations;

namespace Portfolio.Entities
{
    public class Testimonial : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
