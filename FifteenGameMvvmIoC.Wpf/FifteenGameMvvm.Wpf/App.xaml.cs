using AutoMapper;
using FifteenGame.Common.Infrastructure;
using FifteenGameIoc.Wpf.Views;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FifteenGameMvvm.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ConfigureContainer();
            ComposeObjects();
            CreateMapper();
            Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            NinjectKernel.Instance = new StandardKernel(new FifteenGameModule());
        }

        private void ComposeObjects()
        {
            Current.MainWindow = NinjectKernel.Instance.Get<MainWindow>();
        }

        private void CreateMapper()
        {
            var config = new MapperConfiguration(MapperConfig);
            GameMapper.Instance = new Mapper(config);
        }

        private void MapperConfig(IMapperConfigurationExpression cfg)
        {
            FifteenGameDbFirstRepository.Infrastructure.MapperConfig.Config(cfg);
            FifteenGameIoc.Wpf.Infrastructure.MapperConfig.Config(cfg);
            FifteenGame.Business.Infrastructure.MapperConfig.Config(cfg);
        }
    }
}
