using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ClientesAPI.DTOs
{
    public class GeneroDTO
    {
        public int Id { get; set; } //IdentificadorID
        [Required]
        [StringLength(40)]
        public string Nombre { get; set; } //IdentificadorNombre
    }
}
