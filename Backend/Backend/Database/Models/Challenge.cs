using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Database.Models;

[Table("Challenge")]
public class Challenge
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("title")]
    public string Title { get; set; }
    
    [Column("description")]
    public string Description { get; set; }
    
    [Column("difficulty_id")]
    public int DifficultyId { get; set; }
    
    [ForeignKey("DifficultyId")]
    public Difficulty Difficulty { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
    
    [Column("creator_id")]
    public int CreatorId { get; set; }
    
    [ForeignKey("CreatorId")]
    public User Creator { get; set; }
}