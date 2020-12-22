using System.Data.Common;
using System.Data.Entity;
using Abp.DynamicEntityProperties;
using Abp.Zero.EntityFramework;
using FifteenGame.Authorization.Roles;
using FifteenGame.Authorization.Users;
using FifteenGame.Game.Entities;
using FifteenGame.MultiTenancy;

namespace FifteenGame.EntityFramework
{
    public class FifteenGameDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public FifteenGameDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in FifteenGameDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of FifteenGameDbContext since ABP automatically handles it.
         */
        public FifteenGameDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public FifteenGameDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public FifteenGameDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        public virtual IDbSet<CurrentGame> CurrentGames { get; set; }

        public virtual IDbSet<CurrentGameCell> CurrentGameCells { get; set; }

        public virtual IDbSet<FinishedGame> FinishedGames { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DynamicProperty>().Property(p => p.PropertyName).HasMaxLength(250);
            modelBuilder.Entity<DynamicEntityProperty>().Property(p => p.EntityFullName).HasMaxLength(250);
        }
    }
}
