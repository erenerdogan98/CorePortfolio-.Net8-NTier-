using System.ComponentModel.DataAnnotations;

namespace Portfolio.Entities
{
    public class Skill : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Level { get; set; }
    }
}
