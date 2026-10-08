using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Database.Models;

[Table("ChallengeDay")]
public class ChallengeDay
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("challenge_id")]
    public int ChallengeId { get; set; }
    
    [ForeignKey("ChallengeId")]
    public Challenge Challenge { get; set; }
    
    [Column("day_number")]
    public int DayNumber { get; set; }
    
    [Column("title")]
    public string Title { get; set; }
    
    [Column("task")]
    public string Task { get; set; }
    
    [Column("done_criteria")]
    public string DoneCriteria { get; set; }
}