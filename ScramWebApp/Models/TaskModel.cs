using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScramWebApp.Models
{
    public class TaskModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Имя")]
        public string Name { get; set; }
        [Required, DisplayName("Бэклог")]
        public int BacklogId { get; set; }
        [ForeignKey("BacklogId")]
        public Backlog Backlog { get; set; }

        [Display(Name ="Статус")]
        public StatusScrumcs StatusScrumcs { get; set; }

    }
}
