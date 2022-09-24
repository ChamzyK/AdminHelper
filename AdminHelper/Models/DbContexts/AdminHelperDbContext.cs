using Microsoft.EntityFrameworkCore;
using AdminHelper.models.entities;

namespace AdminHelper.models.dbcontexts
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

        public virtual DbSet<Актер> Актерs { get; set; } = null!;
        public virtual DbSet<Жанр> Жанрs { get; set; } = null!;
        public virtual DbSet<Наполненность> Наполненностьs { get; set; } = null!;
        public virtual DbSet<Режиссер> Режиссерs { get; set; } = null!;
        public virtual DbSet<Роль> Рольs { get; set; } = null!;
        public virtual DbSet<Спектакль> Спектакльs { get; set; } = null!;
        public virtual DbSet<СпектакльЖанр> СпектакльЖанрs { get; set; } = null!;
        public virtual DbSet<СпектакльНаполненность> СпектакльНаполненностьs { get; set; } = null!;
        public virtual DbSet<СпектакльРежиссер> СпектакльРежиссерs { get; set; } = null!;
        public virtual DbSet<ТипРоли> ТипРолиs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AdminHelperDb;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Актер>(entity =>
            {
                entity.ToTable("Актер");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Имя).HasMaxLength(50);

                entity.Property(e => e.Отчество).HasMaxLength(50);

                entity.Property(e => e.Фамилия).HasMaxLength(50);
            });

            modelBuilder.Entity<Жанр>(entity =>
            {
                entity.ToTable("Жанр");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Жанр1)
                    .HasMaxLength(70)
                    .HasColumnName("Жанр");
            });

            modelBuilder.Entity<Наполненность>(entity =>
            {
                entity.ToTable("Наполненность");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Наполненность1)
                    .HasMaxLength(70)
                    .HasColumnName("Наполненность");
            });

            modelBuilder.Entity<Режиссер>(entity =>
            {
                entity.ToTable("Режиссер");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Имя).HasMaxLength(50);

                entity.Property(e => e.Отчество).HasMaxLength(50);

                entity.Property(e => e.Фамилия).HasMaxLength(50);
            });

            modelBuilder.Entity<Роль>(entity =>
            {
                entity.ToTable("Роль");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdАктер).HasColumnName("idАктер");

                entity.Property(e => e.IdСпектакль).HasColumnName("idСпектакль");

                entity.HasOne(d => d.IdАктерNavigation)
                    .WithMany(p => p.Рольs)
                    .HasForeignKey(d => d.IdАктер)
                    .HasConstraintName("FK__Роль__idАктер__31EC6D26");

                entity.HasOne(d => d.IdСпектакльNavigation)
                    .WithMany(p => p.Рольs)
                    .HasForeignKey(d => d.IdСпектакль)
                    .HasConstraintName("FK__Роль__idСпектакл__30F848ED");

                entity.HasOne(d => d.НазваниеNavigation)
                    .WithMany(p => p.Рольs)
                    .HasForeignKey(d => d.Название)
                    .HasConstraintName("FK__Роль__Название__300424B4");
            });

            modelBuilder.Entity<Спектакль>(entity =>
            {
                entity.ToTable("Спектакль");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Дата).HasColumnType("smalldatetime");

                entity.Property(e => e.Название).HasMaxLength(70);
            });

            modelBuilder.Entity<СпектакльЖанр>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("СпектакльЖанр");

                entity.Property(e => e.IdЖанр).HasColumnName("idЖанр");

                entity.Property(e => e.IdСпектакль).HasColumnName("idСпектакль");

                entity.HasOne(d => d.IdЖанрNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdЖанр)
                    .HasConstraintName("FK__Спектакль__idЖан__34C8D9D1");

                entity.HasOne(d => d.IdСпектакльNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdСпектакль)
                    .HasConstraintName("FK__Спектакль__idСпе__33D4B598");
            });

            modelBuilder.Entity<СпектакльНаполненность>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("СпектакльНаполненность");

                entity.Property(e => e.IdНаполненность).HasColumnName("idНаполненность");

                entity.Property(e => e.IdСпектакль).HasColumnName("idСпектакль");

                entity.HasOne(d => d.IdНаполненностьNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdНаполненность)
                    .HasConstraintName("FK__Спектакль__idНап__3A81B327");

                entity.HasOne(d => d.IdСпектакльNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdСпектакль)
                    .HasConstraintName("FK__Спектакль__idСпе__398D8EEE");
            });

            modelBuilder.Entity<СпектакльРежиссер>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("СпектакльРежиссер");

                entity.Property(e => e.IdРежиссер).HasColumnName("idРежиссер");

                entity.Property(e => e.IdСпектакль).HasColumnName("idСпектакль");

                entity.HasOne(d => d.IdРежиссерNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdРежиссер)
                    .HasConstraintName("FK__Спектакль__idРеж__37A5467C");

                entity.HasOne(d => d.IdСпектакльNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdСпектакль)
                    .HasConstraintName("FK__Спектакль__idСпе__36B12243");
            });

            modelBuilder.Entity<ТипРоли>(entity =>
            {
                entity.ToTable("ТипРоли");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Название).HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
