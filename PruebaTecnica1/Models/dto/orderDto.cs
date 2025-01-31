using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica1.Models.dto
{
    public class orderDto
    {
        [Required] // Indica que es obligatorio
        [StringLength(100)] // Limita la longitud del nombre
        public string? CustomerName { get; set; }

        [Required] // Indica que es obligatorio
        public DateTime OrderDate { get; set; }
    }
}
