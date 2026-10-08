using Backend.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database;

public class ChallengeContext : DbContext
{
    public ChallengeContext()
    {
    }
 
    public ChallengeContext(DbContextOptions<ChallengeContext> options)
        : base(options)
    {
    }
 
    public virtual DbSet<Challenge> Challenges { get; set; }
    public virtual DbSet<ChallengeDay> ChallengeDays { get; set; }
    public virtual DbSet<DaySubmission> DaySubmissions { get; set; }
    public virtual DbSet<Difficulty> Difficulties { get; set; }
    public virtual DbSet<Participation> Participations { get; set; }
    public virtual DbSet<Status> Statuses { get; set; }
    public virtual DbSet<User> Users { get; set; }
 
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}