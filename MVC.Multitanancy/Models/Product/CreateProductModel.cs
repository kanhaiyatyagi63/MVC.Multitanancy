using System.ComponentModel.DataAnnotations;

namespace MVC.Multitanancy.Models.Product;
public class CreateProductModel
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public int Rate { get; set; }
}
