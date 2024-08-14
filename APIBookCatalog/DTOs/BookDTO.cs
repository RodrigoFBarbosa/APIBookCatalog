using System.ComponentModel.DataAnnotations;

namespace APIBookCatalog.DTOs;

public class BookDTO
{
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string? Name { get; set; }
    [Required]
    [StringLength(100)]
    public string? Author { get; set; }
    [Required]
    [StringLength(300)]
    public string? Description { get; set; }
    [Required]
    public int PublicationYear { get; set; }
    public string? ImageUrl { get; set; }
    public int CategoryId { get; set; }
}
