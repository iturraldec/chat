using ChatWS.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatWS.Data;

public partial class ChatContext : DbContext
{
    public ChatContext()
    {
    }

    public ChatContext(DbContextOptions<ChatContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CStateModel> CStates { get; set; }

    public virtual DbSet<UserModel> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=chat;User=sa;Password=J1z01234_;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CStateModel>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("cState_PK");

            entity.ToTable("cState");

            entity.HasIndex(e => e.Name, "cState_UN").IsUnique();

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserModel>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("User_PK");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "User_UN").IsUnique();

            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("DateCreated");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StateId).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.State).WithMany(p => p.Users)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("User_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
