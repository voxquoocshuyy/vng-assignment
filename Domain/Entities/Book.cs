using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities;

public class Book : EntityBase<int>
{
    [Required]
    [Column(name: "Title", TypeName = "varchar(50)")]
    public string Title { get; set; } = null!;
    [Required]
    [Column(name: "Author", TypeName = "varchar(50)")]
    public string Author { get; set; } = null!;
    [Required]
    [Column(name: "PublishedYear", TypeName = "int")]
    public int PublishedYear { get; set; }

}