using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIBookCatalog.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(80)]
    public string? Name { get; set; }
    [Required]
    [StringLength(300)]
    public string? ImageUrl { get; set; }
    [JsonIgnore]
    public ICollection<Book>? Books { get; set; }
}