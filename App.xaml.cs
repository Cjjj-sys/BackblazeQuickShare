using BackblazeQuickShare.ViewModels;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BackblazeQuickShare
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Ioc.Default.ConfigureServices(new ServiceCollection()
                
                .AddSingleton<MainWindow>()
                .AddSingleton<MainWindowViewModel>()
                .AddSingleton<DragViewModel>()
                .AddSingleton<SettingViewModel>()

                .BuildServiceProvider()
                );

            var mainWindow = Ioc.Default.GetRequiredService<MainWindow>();
            mainWindow.DataContext = Ioc.Default.GetRequiredService<MainWindowViewModel>();
            mainWindow.Show();
        }
    }
}
