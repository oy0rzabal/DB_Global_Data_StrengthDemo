using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace ClientesAPI.Entidades
{
    public class SalaDeCine
    {
        public int Id{ get; set; }
        [Required]
        [StringLength(120)]
        public string Nombre { get; set; }
        public Point Ubicacion { get; set; }
        public List<PeliculaSalasDeCine> PeliculaSalasDeCines { get; set; }
    }
}
