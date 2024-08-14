using APIBookCatalog.Models;
using System.ComponentModel.DataAnnotations;

namespace APIBookCatalog.DTOs;

public class CategoryDTO
{
    public int Id { get; set; }
    [Required]
    [StringLength(80)]
    public string? Name { get; set; }
    [Required]
    [StringLength(300)]
    public string? ImageUrl { get; set; }
}
