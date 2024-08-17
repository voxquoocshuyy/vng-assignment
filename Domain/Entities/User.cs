using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities;

public class User : EntityBase<int>
{
    [Key]
    [Column(name: "Id", TypeName = "int")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Column(name: "Email", TypeName = "varchar(100)")]
    public string Email { get; set; } = null!;
    
    [Column(name: "Status", TypeName = "int")]
    public int Status { get; set; }
    
    [Column(name: "LastUpdatePassword", TypeName = "datetime")]
    public DateTime LastUpdatePassword { get; set; }
}