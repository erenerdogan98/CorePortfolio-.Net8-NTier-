using System.ComponentModel.DataAnnotations;

namespace Portfolio.Entities
{
    public class Contact : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Address { get; set; }
    }
}
