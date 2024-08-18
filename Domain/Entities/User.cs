using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities;

public class User : EntityBase<int>
{
    [Required]
    [Column(name: "Email", TypeName = "varchar(100)")]
    public string Email { get; set; } = null!;
    [Required]
    [Column(name: "Status", TypeName = "int")]
    public int Status { get; set; }
    [Required]
    [Column(name: "LastUpdatePassword", TypeName = "datetime")]
    public DateTime LastUpdatePassword { get; set; }
}