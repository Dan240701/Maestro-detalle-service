using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class OrderItem
{
    [Key] // Indica que es la clave primaria
    public Guid Id { get; set; }

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

    // Relación con Order (un detalle pertenece a un pedido)
    [ForeignKey("OrderId")] // Define la clave foránea
    public Order? Order { get; set; }
}
