using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace projectSwd391.Models
{
    public partial class devContext : DbContext
    {
        public devContext()
        {
        }

        public devContext(DbContextOptions<devContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<JobPost> JobPost { get; set; }
        public virtual DbSet<JobSkill> JobSkill { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Major> Major { get; set; }
        public virtual DbSet<SavedJob> SavedJob { get; set; }
        public virtual DbSet<School> School { get; set; }
        public virtual DbSet<SchoolBranch> SchoolBranch { get; set; }
        public virtual DbSet<SchoolUser> SchoolUser { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<TeacherSkill> TeacherSkill { get; set; }
        public virtual DbSet<UserAccount> UserAccount { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=teacher-recruiment.database.windows.net;user id=swd391team4;password=abcd1@ABCD;Database=dev;Trusted_Connection=False;Encrypt=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>(entity =>
            {
                entity.HasKey(x => new { x.TeacherId, x.JobPostId })
                    .HasName("PK__Applicat__5884D0A743DD9321");

                entity.Property(e => e.ApplyTime)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.DelFlg).HasDefaultValueSql("((0))");

                entity.Property(e => e.InsDateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdDateTime).HasColumnType("datetime");

                entity.Property(e => e.Ver).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.JobPost)
                    .WithMany(p => p.Application)
                    .HasForeignKey(x => x.JobPostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Applicati__JobPo__0F2D40CE");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Application)
                    .HasForeignKey(x => x.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Applicati__Teach__0E391C95");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.DelFlg).HasDefaultValueSql("((0))");

                entity.Property(e => e.InsDateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdDateTime).HasColumnType("datetime");

                entity.Property(e => e.Ver).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.Property(e => e.DelFlg).HasDefaultValueSql("((0))");

                entity.Property(e => e.InsDateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdDateTime).HasColumnType("datetime");

                entity.Property(e => e.Ver).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.District)
                    .HasForeignKey(x => x.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__District__CityId__1A9EF37A");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.DelFlg).HasDefaultValueSql("((0))");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.EndDate)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.InsDateTime).HasColumnType("datetime");

                entity.Property(e => e.StartDate)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.UpdDateTime).HasColumnType("datetime");

                entity.Property(e => e.Ver).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Job)
                    .HasForeignKey(x => x.MajorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Job__MajorId__73852659");
            });

            modelBuilder.Entity<JobPost>(entity =>
            {
                entity.HasIndex(x => new { x.JobId, x.SchoolBranchId })
                    .HasName("UQ__JobPost__FD4A6746A0942CA4")
                    .IsUnique();

                entity.Property(e => e.DelFlg).HasDefaultValueSql("((0))");

                entity.Property(e => e.InsDateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdDateTime).HasColumnType("datetime");

                entity.Property(e => e.Ver).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobPost)
                    .HasForeignKey(x => x.JobId)
                    .HasConstraintName("FK__JobPost__JobId__793DFFAF");

                entity.HasOne(d => d.SchoolBranch)
                    .WithMany(p => p.JobPost)
                    .HasForeignKey(x => x.SchoolBranchId)
                    .HasConstraintName("FK__JobPost__SchoolB__7A3223E8");
            });

            modelBuilder.Entity<JobSkill>(entity =>
            {
                entity.HasKey(x => new { x.JobId, x.SkillId })
                    .HasName("PK__JobSkill__689C99DACAB172DB");

                entity.Property(e => e.DelFlg).HasDefaultValueSql("((0))");

                entity.Property(e => e.InsDateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdDateTime).HasColumnType("datetime");

                entity.Property(e => e.Ver).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobSkill)
                    .HasForeignKey(x => x.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__JobSkill__JobId__02C769E9");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.JobSkill)
                    .HasForeignKey(x => x.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__JobSkill__SkillI__03BB8E22");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.DelFlg).HasDefaultValueSql("((0))");

                entity.Property(e => e.InsDateTime).HasColumnType("datetime");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.StreetAddress).HasMaxLength(100);

                entity.Property(e => e.UpdDateTime).HasColumnType("datetime");

                entity.Property(e => e.Ver).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Location)
                    .HasForeignKey(x => x.DistrictId)
                    .HasConstraintName("FK__Location__Distri__1E6F845E");
            });

            modelBuilder.Entity<Major>(entity =>
            {
                entity.Property(e => e.DelFlg).HasDefaultValueSql("((0))");

                entity.Property(e => e.InsDateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.UpdDateTime).HasColumnType("datetime");

                entity.Property(e => e.Ver).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<SavedJob>(entity =>
            {
                entity.HasKey(x => new { x.TeacherId, x.JobPostId })
                    .HasName("PK__SavedJob__5884D0A7069C4743");

                entity.Property(e => e.DelFlg).HasDefaultValueSql("((0))");

                entity.Property(e => e.InsDateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdDateTime).HasColumnType("datetime");

                entity.Property(e => e.Ver).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.JobPost)
                    .WithMany(p => p.SavedJob)
                    .HasForeignKey(x => x.JobPostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SavedJob__JobPos__09746778");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.SavedJob)
                    .HasForeignKey(x => x.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SavedJob__Teache__0880433F");
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.Property(e => e.DelFlg).HasDefaultValueSql("((0))");

                entity.Property(e => e.InsDateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdDateTime).HasColumnType("datetime");

                entity.Property(e => e.Ver).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<SchoolBranch>(entity =>
            {
                entity.Property(e => e.DelFlg).HasDefaultValueSql("((0))");

                entity.Property(e => e.InsDateTime).HasColumnType("datetime");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDateTime).HasColumnType("datetime");

                entity.Property(e => e.Ver).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.SchoolBranch)
                    .HasForeignKey(x => x.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SchoolBra__Locat__6AEFE058");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.SchoolBranch)
                    .HasForeignKey(x => x.SchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SchoolBra__Schoo__69FBBC1F");
            });

            modelBuilder.Entity<SchoolUser>(entity =>
            {
                entity.HasKey(x => x.UserId)
                    .HasName("PK__SchoolUs__1788CC4C83AAD869");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.DelFlg).HasDefaultValueSql("((0))");

                entity.Property(e => e.InsDateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdDateTime).HasColumnType("datetime");

                entity.Property(e => e.Ver).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.SchoolUser)
                    .HasForeignKey(x => x.SchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SchoolUse__Schoo__65370702");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.SchoolUser)
                    .HasForeignKey<SchoolUser>(x => x.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SchoolUse__UserI__6442E2C9");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.DelFlg).HasDefaultValueSql("((0))");

                entity.Property(e => e.InsDateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.UpdDateTime).HasColumnType("datetime");

                entity.Property(e => e.Ver).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TeacherSkill>(entity =>
            {
                entity.HasKey(x => new { x.TeacherId, x.SkillId })
                    .HasName("PK__TeacherS__8008507C9821E50D");

                entity.Property(e => e.DelFlg).HasDefaultValueSql("((0))");

                entity.Property(e => e.InsDateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdDateTime).HasColumnType("datetime");

                entity.Property(e => e.Ver).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.TeacherSkill)
                    .HasForeignKey(x => x.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TeacherSk__Skill__14E61A24");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeacherSkill)
                    .HasForeignKey(x => x.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TeacherSk__Teach__13F1F5EB");
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasIndex(x => x.Email)
                    .HasName("UQ__UserAcco__A9D10534554F8A73")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DelFlg).HasDefaultValueSql("((0))");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InsDateTime).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.PasswordHashAlgorithm)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.PasswordSalt).HasColumnType("text");

                entity.Property(e => e.UpdDateTime).HasColumnType("datetime");

                entity.Property(e => e.Ver).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.UserAccount)
                    .HasForeignKey<UserAccount>(x => x.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserAccount__Id__5AB9788F");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserAccount)
                    .HasForeignKey(x => x.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserAccou__RoleI__5BAD9CC8");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Image).HasColumnType("text");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.UserProfile)
                    .HasForeignKey(x => x.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserProfi__Locat__531856C7");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.DelFlg).HasDefaultValueSql("((0))");

                entity.Property(e => e.InsDateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDateTime).HasColumnType("datetime");

                entity.Property(e => e.Ver).HasDefaultValueSql("((0))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
