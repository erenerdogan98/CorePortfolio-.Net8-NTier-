using System.ComponentModel.DataAnnotations;

namespace Portfolio.Entities
{
    public class Feature : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
