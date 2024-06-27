using Microsoft.EntityFrameworkCore;
using System.Text;

namespace placaappapi.Models
{
    [Keyless]
    public class Placa
    {
        public string? num_placa { get; set; }
        public string? fecha_reserva { get; set; }
        public string? hora_reserva { get; set; }
        public string? estado {  get; set; }


    }
}
