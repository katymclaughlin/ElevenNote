using Microsoft.EntityFrameworkCore;
using ElevenNote.Data.Entities;

namespace ElevenNote.Data;

public class ApplicationDbContext : DbContext
{
    //public ApplicationDbContext(){}
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<UserEntity> Users { get; set; } = null!;   

    public DbSet<NoteEntity> Notes { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NoteEntity>()
            .HasOne(n => n.Owner)
            .WithMany(p => p.Notes)
            .HasForeignKey(n => n.OwnerId);
    }
}