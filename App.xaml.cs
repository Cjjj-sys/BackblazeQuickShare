using BackblazeQuickShare.Model;
using BackblazeQuickShare.ViewModels;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

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

        protected override async void OnStartup(StartupEventArgs e)
        {
            if (!File.Exists("config.json"))
            {
                await File.WriteAllTextAsync("config.json", JsonConvert.SerializeObject(new Config { KeyID="", ApplicationKey="", Url="" }));
            }
            //var configurationBuilder = new ConfigurationBuilder();
            //configurationBuilder.AddJsonFile("config.json", false, true);
            //var configurationRoot = configurationBuilder.Build();
            Ioc.Default.ConfigureServices(new ServiceCollection()
                
                .AddSingleton<MainWindow>()
                .AddSingleton<MainWindowViewModel>()
                .AddSingleton<DragViewModel>()
                .AddSingleton<SettingViewModel>()

               // .AddOptions().Configure<Config>(e => configurationRoot.Bind(e))

                .BuildServiceProvider()
                );

            var mainWindow = Ioc.Default.GetRequiredService<MainWindow>();
            mainWindow.DataContext = Ioc.Default.GetRequiredService<MainWindowViewModel>();
            mainWindow.Show();
        }
    }
}
