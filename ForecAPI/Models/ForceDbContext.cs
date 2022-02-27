using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ForecAPI.Models
{
    public class ForceDbContext: IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ForceDbContext(DbContextOptions<ForceDbContext> options) : base(options)
        {
        }
        public DbSet<Quotation>  Quotations { get; set; }
        public DbSet<Base> Bases{ get; set; }
        public DbSet<BaseSection>  BaseSections{ get; set; }
        public DbSet<Force>  Forces{ get; set; }
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

    }
}
