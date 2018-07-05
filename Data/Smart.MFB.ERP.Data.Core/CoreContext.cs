using Smart.MFB.ERP.Common.Contracts;
using Smart.MFB.ERP.Common.Core;
using Smart.MFB.ERP.Common.Core.Entities;
using Smart.MFB.ERP.Integration.AuditTrail;
using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Runtime.Serialization;
using System.Text;
using Smart.MFB.ERP.Common.ServiceModel;

namespace Smart.MFB.ERP.Data.Core
{
    public class CoreContext : DbContext
    {
        AuditManager _auditManager;

        public CoreContext()
            : base("name=SmartMFBERPDB")
        {
            System.Data.Entity.Database.SetInitializer<CoreContext>(null);

            _auditManager = new AuditManager();
        }

        public DbSet<ModuleCategory> ModuleCategorySet { get; set; }
        public DbSet<Module> ModuleSet { get; set; }
        public DbSet<Role> RoleSet { get; set; }
        public DbSet<Group> GroupSet { get; set; }
        public DbSet<GroupRole> GroupRoleSet { get; set; }
        public DbSet<Menu> MenuSet { get; set; }
        public DbSet<MenuRole> MenuRoleSet { get; set; }
        public DbSet<User> UserSet { get; set; }
        public DbSet<UserGroup> UserGroupSet { get; set; }
        public DbSet<Country> CountrySet { get; set; }
        public DbSet<State> StateSet { get; set; }
        public DbSet<City> CitySet { get; set; }
        public DbSet<Language> LanguageSet { get; set; }
        public DbSet<Theme> ThemeSet { get; set; }
        public DbSet<Religion> ReligionSet { get; set; }
        public DbSet<Smart.MFB.ERP.Common.Core.Entities.AuditTrail> AuditTrail { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Ignore<PropertyChangedEventHandler>();
            modelBuilder.Ignore<ExtensionDataObject>();
            modelBuilder.Ignore<IIdentifiableEntity>();

            //Core Module
            modelBuilder.Entity<ModuleCategory>().HasKey<long>(e => e.ModuleCategoryId).Ignore(e => e.EntityId);
            modelBuilder.Entity<ModuleCategory>().Property(c => c.RowVersion).IsRowVersion();
            modelBuilder.Entity<ModuleCategory>().ToTable("cor_module_category");

            modelBuilder.Entity<Module>().HasKey<long>(e => e.ModuleId).Ignore(e => e.EntityId);
            modelBuilder.Entity<Module>().Property(c => c.RowVersion).IsRowVersion();
            modelBuilder.Entity<Module>().ToTable("cor_module");

            modelBuilder.Entity<Theme>().HasKey<long>(e => e.ThemeId).Ignore(e => e.EntityId);
            modelBuilder.Entity<Theme>().Property(c => c.RowVersion).IsRowVersion();
            modelBuilder.Entity<Theme>().ToTable("cor_theme");

            modelBuilder.Entity<Role>().HasKey<long>(e => e.RoleId).Ignore(e => e.EntityId);
            modelBuilder.Entity<Role>().Property(c => c.RowVersion).IsRowVersion();
            modelBuilder.Entity<Role>().ToTable("cor_role");

            modelBuilder.Entity<Group>().HasKey<long>(e => e.GroupId).Ignore(e => e.EntityId);
            modelBuilder.Entity<Group>().Property(c => c.RowVersion).IsRowVersion();
            modelBuilder.Entity<Group>().ToTable("cor_group");

            modelBuilder.Entity<GroupRole>().HasKey<long>(e => e.GroupRoleId).Ignore(e => e.EntityId);
            modelBuilder.Entity<GroupRole>().Property(c => c.RowVersion).IsRowVersion();
            modelBuilder.Entity<GroupRole>().ToTable("cor_grouprole");

            modelBuilder.Entity<Menu>().HasKey<long>(e => e.MenuId).Ignore(e => e.EntityId);
            modelBuilder.Entity<Menu>().Property(c => c.RowVersion).IsRowVersion();
            modelBuilder.Entity<Menu>().ToTable("cor_menu");

            modelBuilder.Entity<MenuRole>().HasKey<long>(e => e.MenuRoleId).Ignore(e => e.EntityId);
            modelBuilder.Entity<MenuRole>().Property(c => c.RowVersion).IsRowVersion();
            modelBuilder.Entity<MenuRole>().ToTable("cor_menurole");

            modelBuilder.Entity<User>().HasKey<long>(e => e.UserId).Ignore(e => e.EntityId);
            modelBuilder.Entity<User>().Property(c => c.RowVersion).IsRowVersion();
            modelBuilder.Entity<User>().ToTable("cor_user");

            modelBuilder.Entity<UserGroup>().HasKey<long>(e => e.UserGroupId).Ignore(e => e.EntityId);
            modelBuilder.Entity<UserGroup>().Property(c => c.RowVersion).IsRowVersion();
            modelBuilder.Entity<UserGroup>().ToTable("cor_usergroup");

            modelBuilder.Entity<Country>().HasKey<long>(e => e.CountryId).Ignore(e => e.EntityId);
            modelBuilder.Entity<Country>().Property(c => c.RowVersion).IsRowVersion();
            modelBuilder.Entity<Country>().ToTable("cor_country");

            modelBuilder.Entity<State>().HasKey<long>(e => e.StateId).Ignore(e => e.EntityId);
            modelBuilder.Entity<State>().Property(c => c.RowVersion).IsRowVersion();
            modelBuilder.Entity<State>().ToTable("cor_state");

            modelBuilder.Entity<City>().HasKey<long>(e => e.CityId).Ignore(e => e.EntityId);
            modelBuilder.Entity<City>().Property(c => c.RowVersion).IsRowVersion();
            modelBuilder.Entity<City>().ToTable("cor_city");

            modelBuilder.Entity<Language>().HasKey<long>(e => e.LanguageId).Ignore(e => e.EntityId);
            modelBuilder.Entity<Language>().Property(c => c.RowVersion).IsRowVersion();
            modelBuilder.Entity<Language>().ToTable("cor_language");


            modelBuilder.Entity<Religion>().HasKey<long>(e => e.ReligionId).Ignore(e => e.EntityId);
            modelBuilder.Entity<Religion>().Property(c => c.RowVersion).IsRowVersion();
            modelBuilder.Entity<Religion>().ToTable("cor_religion");


            modelBuilder.Entity<Smart.MFB.ERP.Common.Core.Entities.AuditTrail>().HasKey<long>(e => e.AuditTrailId).Ignore(e => e.EntityId);
            modelBuilder.Entity<Smart.MFB.ERP.Common.Core.Entities.AuditTrail>().Property(c => c.RowVersion).IsRowVersion();
            modelBuilder.Entity<Smart.MFB.ERP.Common.Core.Entities.AuditTrail>().ToTable("cor_audittrail");
        }

        public override int SaveChanges()
        {
            try
            {
                if (ChangeTracker.HasChanges())
                {
                    var entries = this.ChangeTracker.Entries();

                    foreach (DbEntityEntry entry in entries)
                    {
                        if (entry.Entity != null)
                        {
                            if (entry.State == EntityState.Added)
                            {
                                var model = (EntityBase)entry.Entity;
                                model.CreatedBy = "";
                                model.CreatedOn = DateTime.Now;
                                model.UpdatedBy = "";
                                model.UpdatedOn = DateTime.Now;
                            }
                            else if (entry.State == EntityState.Modified)
                            {
                                //entry is modified
                                var model = (EntityBase)entry.Entity;
                                model.UpdatedBy = "";
                                model.UpdatedOn = DateTime.Now;
                            }

                            _auditManager.AddAudit(entry, "");

                        }
                    }
                }

                _auditManager.Save();
                return base.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                var innerEx = e.InnerException;
                while (innerEx.InnerException != null)
                    innerEx = innerEx.InnerException;

                throw new Exception(innerEx.Message);
            }
            catch (DbEntityValidationException e)
            {
                var sb = new StringBuilder();

                foreach (var entry in e.EntityValidationErrors)
                {
                    foreach (var error in entry.ValidationErrors)
                    {
                        sb.AppendLine(string.Format("{0}-{1}-{2}", entry.Entry.Entity, error.PropertyName, error.ErrorMessage));
                    }
                }

                throw new Exception(sb.ToString());
            }
            catch (Exception e)
            {
                var innerEx = e.InnerException;
                while (innerEx.InnerException != null)
                    innerEx = innerEx.InnerException;

                throw new Exception(innerEx.Message);
            }

        }


    }
}
