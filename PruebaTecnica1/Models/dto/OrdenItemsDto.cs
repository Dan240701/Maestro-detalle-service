using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica1.Models.dto
{
    public class OrdenItemsDto
    {

        [Required] // Indica que es obligatorio
        public Guid OrderId { get; set; } // Clave foránea a Order

        [Required] // Indica que es obligatorio
        [StringLength(100)] // Limita la longitud del nombre del producto
        public string? ProductName { get; set; }

        [Required] // Indica que es obligatorio
        [Range(1, int.MaxValue)] // La cantidad debe ser al menos 1
        public int Quantity { get; set; }

        [Required] // Indica que es obligatorio
        [Column(TypeName = "decimal(18, 2)")] // Define el tipo de dato decimal en la base de datos
        public decimal Price { get; set; }



    }
}
