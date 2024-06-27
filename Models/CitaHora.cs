using System.ComponentModel.DataAnnotations;

namespace placaappapi.Models
{
    public class CitaHora
    {
        [Key]
        public int value {  get; set; }
        public string? label { get; set; }

    }
}
