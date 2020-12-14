using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using FifteenGame.EntityFramework;

namespace FifteenGame
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(FifteenGameCoreModule))]
    public class FifteenGameDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<FifteenGameDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
