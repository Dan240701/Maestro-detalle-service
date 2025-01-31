using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Order
{
    [Key] // Indica que es la clave primaria
    public Guid Id { get; set; }
    [Required] // Indica que es obligatorio
    [StringLength(100)] // Limita la longitud del nombre
    public string? CustomerName { get; set; }
    [Required] // Indica que es obligatorio
    public DateTime OrderDate { get; set; }
    // Relación con OrderItem (un pedido puede tener varios detalles)
    public ICollection<OrderItem> OrderItems { get; set; }
    public Order()
    {
        OrderItems = new List<OrderItem>();
    }
}
