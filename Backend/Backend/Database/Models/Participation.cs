using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Database.Models;

[Table("Participation")]
public class Participation
{
    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Column("user_id")]
    public int UserId { get; set; }
    
    [ForeignKey("UserId")]
    public virtual User User { get; set; }
    
    [Column("challenge_id")]
    public int ChallengeId { get; set; }
    
    [ForeignKey("ChallengeId")]
    public virtual Challenge Challenge { get; set; }
    
    [Column("started_at")]
    public DateTime StartedAt { get; set; }
    
    [Column("status_id")]
    public int StatusId { get; set; }
    
    [ForeignKey("StatusId")]
    public virtual Status? Status { get; set; }
}