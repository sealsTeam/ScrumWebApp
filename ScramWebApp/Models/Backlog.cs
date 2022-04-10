using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ScramWebApp.Models
{
    public class Backlog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Имя Бэклога")]
        public string Name { get; set; }
    }
}
