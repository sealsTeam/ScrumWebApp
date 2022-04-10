using System.ComponentModel.DataAnnotations;

namespace ScramWebApp.Models
{
    public enum StatusScrumcs
    {
        [Display(Name="Сделать")]
        Need,
        [Display(Name = "В процессе")]
        InProcess,
        [Display(Name = "В проверки")]
        Check,
        [Display(Name = "Сделано")]
        Complete
    }
}
