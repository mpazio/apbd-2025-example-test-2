using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleTest2.Models;

[Table("Status")]
public class Status
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; } = null!;
    
    public ICollection<Order> Orders { get; set; } = null!;
}