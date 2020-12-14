using FifteenGame.EntityFramework;
using EntityFramework.DynamicFilters;

namespace FifteenGame.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly FifteenGameDbContext _context;

        public InitialHostDbBuilder(FifteenGameDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
