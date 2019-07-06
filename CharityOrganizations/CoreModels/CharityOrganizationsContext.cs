using Microsoft.EntityFrameworkCore;

namespace CharityOrganizations.CoreModels
{
    public partial class CharityOrganizationsContext : DbContext
    {
        public CharityOrganizationsContext()
        {
        }

        public CharityOrganizationsContext(DbContextOptions<CharityOrganizationsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Grantee> Grantee { get; set; }
        public virtual DbSet<GranteeService> GranteeService { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Grantee>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.CityId).HasColumnName("cityId");

                entity.Property(e => e.FamilySize).HasColumnName("familySize");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NationalId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Grantee)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grantee_ToTable_City");
            });

            modelBuilder.Entity<GranteeService>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.ServiceComment)
                    .HasColumnName("serviceComment")
                    .HasMaxLength(50);

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.GranteeService)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GranteeService_ToTable_Orgaization");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
