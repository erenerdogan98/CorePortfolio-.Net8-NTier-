using System.ComponentModel.DataAnnotations;

namespace Portfolio.Entities
{
    public class ToDoList : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
