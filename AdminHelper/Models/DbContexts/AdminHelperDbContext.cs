using AdminHelper.models.entities;
using Microsoft.EntityFrameworkCore;

namespace AdminHelper.Models.DbContexts
{
    public partial class AdminHelperDbContext : DbContext
    {
        public AdminHelperDbContext()
        {
        }

        public AdminHelperDbContext(DbContextOptions<AdminHelperDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Fullness> FullnessDbSet { get; set; } = null!;
        public virtual DbSet<Director> Directors { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Spectacle> Spectacles { get; set; } = null!;
        public virtual DbSet<SpectacleGenre> SpectacleGenres { get; set; } = null!;
        public virtual DbSet<SpectacleFullness> SpectacleFullnessDbSet { get; set; } = null!;
        public virtual DbSet<SpectacleDirector> SpectacleDirectors { get; set; } = null!;
        public virtual DbSet<RoleType> RoleTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AdminHelperDb;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Patronymic).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GenreName)
                    .HasMaxLength(70)
                    .HasColumnName("Жанр");
            });

            modelBuilder.Entity<Fullness>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FullnessName)
                    .HasMaxLength(70)
                    .HasColumnName("Наполненность");
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Patronymic).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActorId).HasColumnName("idАктер");

                entity.Property(e => e.SpectacleId).HasColumnName("idСпектакль");

                entity.HasOne(d => d.ActorIdNavigation)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.ActorId)
                    .HasConstraintName("FK__Роль__idАктер__31EC6D26");

                entity.HasOne(d => d.SpectacleIdNavigation)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.SpectacleId)
                    .HasConstraintName("FK__Роль__idСпектакл__30F848ED");

                entity.HasOne(d => d.NameNavigation)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.Name)
                    .HasConstraintName("FK__Роль__Название__300424B4");
            });

            modelBuilder.Entity<Spectacle>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date).HasColumnType("smalldatetime");

                entity.Property(e => e.Name).HasMaxLength(70);
            });

            modelBuilder.Entity<SpectacleGenre>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.GenreId).HasColumnName("idЖанр");

                entity.Property(e => e.SpectacleId).HasColumnName("idСпектакль");

                entity.HasOne(d => d.GenreIdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK__Спектакль__idЖан__34C8D9D1");

                entity.HasOne(d => d.SpectacleIdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.SpectacleId)
                    .HasConstraintName("FK__Спектакль__idСпе__33D4B598");
            });

            modelBuilder.Entity<SpectacleFullness>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.FullnessId).HasColumnName("idНаполненность");

                entity.Property(e => e.SpectacleId).HasColumnName("idСпектакль");

                entity.HasOne(d => d.FullnessIdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.FullnessId)
                    .HasConstraintName("FK__Спектакль__idНап__3A81B327");

                entity.HasOne(d => d.SpectacleIdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.SpectacleId)
                    .HasConstraintName("FK__Спектакль__idСпе__398D8EEE");
            });

            modelBuilder.Entity<SpectacleDirector>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.DirectorId).HasColumnName("idРежиссер");

                entity.Property(e => e.SpectacleId).HasColumnName("idСпектакль");

                entity.HasOne(d => d.DirectorIdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.DirectorId)
                    .HasConstraintName("FK__Спектакль__idРеж__37A5467C");

                entity.HasOne(d => d.SpectacleIdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.SpectacleId)
                    .HasConstraintName("FK__Спектакль__idСпе__36B12243");
            });

            modelBuilder.Entity<RoleType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
