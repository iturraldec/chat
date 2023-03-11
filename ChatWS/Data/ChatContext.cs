using Microsoft.EntityFrameworkCore;
using ChatWS.Models;

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

    public virtual DbSet<CState> CStates { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433; Database=chat; User=sa; Password=J1z01234_; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CState>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("cState_PK");

            entity.Property(e => e.Name).UseCollation("Latin1_General_100_CI_AS_SC_UTF8");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("User_PK");

            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Email).UseCollation("Latin1_General_100_CI_AS_SC_UTF8");
            entity.Property(e => e.Name).UseCollation("Latin1_General_100_CI_AS_SC_UTF8");
            entity.Property(e => e.Password).UseCollation("Latin1_General_100_CI_AS_SC_UTF8");
            entity.Property(e => e.StateId).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.State).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("User_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
