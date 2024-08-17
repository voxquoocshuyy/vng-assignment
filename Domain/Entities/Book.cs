using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities;

public class Book : EntityBase<int>
{
    [Key]
    [Column(name: "Id", TypeName = "int")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column(name: "Title", TypeName = "varchar(50)")]
    public string Title { get; set; } = null!;

    [Column(name: "Author", TypeName = "varchar(50)")]
    public string Author { get; set; } = null!;

    [Column(name: "PublishedYear", TypeName = "int")]
    public int PublishedYear { get; set; }

}