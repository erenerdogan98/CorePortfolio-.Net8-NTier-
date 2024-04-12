using System.ComponentModel.DataAnnotations;

namespace Portfolio.Entities
{
    public class SocialMedia : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
    }
}
