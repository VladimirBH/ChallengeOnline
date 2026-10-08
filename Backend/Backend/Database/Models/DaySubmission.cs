using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Backend.Database.Models;

[Table("DaySubmission")]
public class DaySubmission
{
    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Column("participation_id")]
    public int ParticipationId { get; set; }
    
    [ForeignKey(nameof(ParticipationId))]
    public virtual Participation Participation { get; set; }
    
    [Column("challenge_day_id")]
    public int ChallengeDayId { get; set; }
    
    [ForeignKey(nameof(ChallengeDayId))]
    public virtual ChallengeDay ChallengeDay { get; set; }
    
    [Column("status_id")]
    public int StatusId { get; set; }
    
    [ForeignKey(nameof(StatusId))]
    public virtual Status? Status { get; set; }
    
    [Column("summary")]
    public string Summary { get; set; }
    
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}