using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using FifteenGame.EntityFramework;

namespace FifteenGame.Migrator
{
    [DependsOn(typeof(FifteenGameDataModule))]
    public class FifteenGameMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<FifteenGameDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}