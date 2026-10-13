using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Database.Models;

[Table("User")]
public class User
{
    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Column("username")]
    public string Username { get; set; }
    
    [Column("password")]
    public string Password { get; set; }
    
    [Column("email")]
    public string Email { get; set; }
    
    [Column("refresh_token")]
    public string? RefreshToken { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}