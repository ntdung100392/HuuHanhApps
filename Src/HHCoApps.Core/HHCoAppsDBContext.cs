using HHCoApps.Core.Core.Interface;
using HHCoApps.Core.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HHCoApps.Core
{
    public class HHCoAppsDBContext : DbContext
    {
        public HHCoAppsDBContext() : base("name=HHCoApps")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HHCoAppsDBContext, Migrations.Configuration>("HHCoApps"));
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using Fluent API here
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);

            #region User
            modelBuilder.Entity<Users>()
                .HasKey<Guid>(u => u.Id);
            #endregion

            #region Log
            modelBuilder.Entity<Log>()
                .HasKey<int>(l => l.Id);
            #endregion

            #region Customer
            modelBuilder.Entity<Customer>()
                .HasKey<int>(l => l.Id);
            #endregion

            #region Supplier
            modelBuilder.Entity<Supplier>()
                .HasKey<Guid>(l => l.Id);

            modelBuilder.Entity<Supplier>()
                .HasMany<Product>(s => s.Products)
                .WithRequired(p => p.Supplier)
                .HasForeignKey<Guid>(p => p.SupplierId)
                .WillCascadeOnDelete();
            #endregion

            #region Product
            modelBuilder.Entity<Product>()
                .HasKey<Guid>(l => l.Id);

            modelBuilder.Entity<Product>()
                .HasRequired<Supplier>(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey<Guid>(p => p.SupplierId);
            #endregion

            #region Product Category
            modelBuilder.Entity<Category>()
                .HasKey<int>(l => l.Id);

            modelBuilder.Entity<Category>()
                .HasMany<Product>(pc => pc.Products)
                .WithRequired(p => p.Category)
                .HasForeignKey<int>(p => p.CategoryId)
                .WillCascadeOnDelete();
            #endregion
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity
                    && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                if (entry.Entity is IAuditableEntity entity)
                {
                    string identityName = Thread.CurrentPrincipal.Identity.Name;
                    DateTime now = DateTime.Now;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedBy = string.IsNullOrEmpty(identityName) ? "System" : identityName;
                        entity.CreatedDate = now;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }

                    entity.ModifiedBy = string.IsNullOrEmpty(identityName) ? "System" : identityName;
                    entity.ModifiedDate = now;
                }
            }

            return base.SaveChanges();
        }
    }
}
