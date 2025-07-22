using System.ComponentModel.DataAnnotations;

namespace ShopListBackend.Models;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public List<Product> Products { get; set; } = new List<Product>();
}