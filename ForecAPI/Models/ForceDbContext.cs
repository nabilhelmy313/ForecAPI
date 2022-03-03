using ForecAPI.Models.General;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ForecAPI.Models
{
    public class ForceDbContext: IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ForceDbContext(DbContextOptions<ForceDbContext> options) : base(options)
        {
        }
        public DbSet<MPR>  MPRs { get; set; }
        public DbSet<Base> Bases{ get; set; }
        public DbSet<BaseSection>  BaseSections{ get; set; }
        public DbSet<Force>  Forces{ get; set; }
        public DbSet<MasterData>  MasterDatas{ get; set; }

        public override async Task<int> SaveChangesAsync( CancellationToken cancellationToken = new CancellationToken())
        {


            foreach (var entry in ChangeTracker.Entries<BaseEntity>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Create_Date = DateTime.Now;
                        entry.Entity.Is_Deleted = false;
                        break;

                    case EntityState.Modified:
                        entry.Entity.Last_Modify_Date = DateTime.Now;
                        break;

                }
            }
            if (ChangeTracker.Entries<ApplicationUser>().Any())
            {
                foreach (var entry in ChangeTracker.Entries<ApplicationUser>().ToList())
                {


                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.Create_Date = DateTime.Now;
                            break;

                        case EntityState.Modified:
                            entry.Entity.Last_Modify_Date = DateTime.Now;
                            break;

                    }
                }
            }
            return await base.SaveChangesAsync( cancellationToken);

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(ur =>
            {
                ur.HasKey(ur => ur.Id);
                ur.HasOne(ur => ur.Force).WithMany(u => u.ApplicationUsers).HasForeignKey(ur => ur.ForceCode).HasPrincipalKey(a=>a.ForceCode);
                ur.HasOne(ur => ur.Base).WithMany(u => u.ApplicationUsers).HasForeignKey(ur => ur.BaseCode).HasPrincipalKey(a => a.Code);
                ur.HasOne(ur => ur.BaseSection).WithMany(u => u.ApplicationUsers).HasForeignKey(ur => ur.BaseSectionCode).HasPrincipalKey(a => a.Code);
            });
            builder.Entity<Force>(ur =>
            {
                ur.HasKey(ur => ur.Id);
                ur.HasMany(ur => ur.Bases).WithOne(u => u.Force).HasForeignKey(ur => ur.Id);
             });
            builder.Entity<Base>(ur =>
            {
                ur.HasKey(ur => ur.Id);
                ur.HasMany(ur => ur.BaseSection).WithOne(u => u.Base).HasForeignKey(ur => ur.Id);
            });
            builder.Entity<MPR>(ur =>
            {
                ur.HasKey(ur => ur.Id);
                ur.HasOne(ur => ur.AddressOfDelivery).WithMany(u => u.MPRs).HasForeignKey(ur => ur.Address_For_Delivery).HasPrincipalKey(a => a.Code);
            });
        }

        }
    }
