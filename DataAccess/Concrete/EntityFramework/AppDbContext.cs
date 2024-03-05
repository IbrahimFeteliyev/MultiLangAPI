using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=IT-WEB2\SQLEXPRESS;Database=AppDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<WorkSchedule> WorkSchedules { get; set; }
        public DbSet<Appointment> Appointments { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryLanguage> CategoryLanguages { get; set; }



        public DbSet<ShortInfo> ShortInfos { get; set; }
        public DbSet<ShortInfoLanguage> ShortInfoLanguages { get; set; }



        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutLanguage> AboutLanguages { get; set; }



        public DbSet<HospitalBranch> HospitalBranchs { get; set; }
        public DbSet<HospitalBranchLanguage> HospitalBranchLanguages { get; set; }

        public DbSet<HospitalBranchFeature> HospitalBranchFeatures { get; set; }
        public DbSet<HospitalBranchFeatureLanguage> HospitalBranchFeatureLanguages { get; set; }
        public DbSet<HospitalBranchPhoto> HospitalBranchPhotos { get; set; }

    }
}
