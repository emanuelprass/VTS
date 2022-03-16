using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SceletonAPI.Application.Interfaces;
using SceletonAPI.Domain.Entities;
using SceletonAPI.Domain.Infrastructures;
using StoredProcedureEFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SceletonAPI.Infrastructure.Persistences
{
    public class VTSDbContext : DbContext, IVTSDBContext
    {
        public VTSDbContext(DbContextOptions<VTSDbContext> options) : base(options)
        {

        }

        public DbSet<MasterDataUser> MasterDataUser { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VTSDbContext).Assembly);
        }

        public override EntityEntry Add(object entity)
        {
            if (entity is BaseEntity)
            {
                ((BaseEntity)entity).RowStatus = 0;
            }

            return base.Add(entity);
        }

        public IStoredProcBuilder loadStoredProcedureBuilder(string val)
        {
            return this.LoadStoredProc(val);
        }

        public override int SaveChanges()
        {
            this.HandleSave();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            this.HandleSave();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.HandleSave();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void HandleSave()
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).LastUpdateDate = DateTime.Now;
                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreateDate = DateTime.Now;
                    ((BaseEntity)entityEntry.Entity).RowStatus = 0;
                }
                //if (!(entityEntry.Entity is User) && !(entityEntry.Entity is Recommendation) && !(entityEntry.Entity is SalesmanMeta))
                //{
                //    UpdateSoftDeleteStatuses(entityEntry);
                //}
            }
            //foreach (var entityEntry in ChangeTracker.Entries())
            //{
            //    if (entityEntry.Entity is Salesman)
            //    {
            //        entityEntry.State = EntityState.Unchanged;
            //    }
            //}
        }

        private void UpdateSoftDeleteStatuses(EntityEntry entry)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    ((BaseEntity)entry.Entity).RowStatus = 0;
                    break;
                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    ((BaseEntity)entry.Entity).RowStatus = -1;
                    break;
            }
        }
    }
}
