using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Models;

[Table("Product_Order")]
[PrimaryKey(nameof(ProductId), nameof(OrderId))]
public class ProductOrder
{
    [ForeignKey(nameof(Product))]
    public int ProductId { get; set; }
    [ForeignKey(nameof(Order))]
    public int OrderId { get; set; }
    public int Amount { get; set; }

    public Product Product { get; set; } = null!;
    public Order Order { get; set; } = null!;
}