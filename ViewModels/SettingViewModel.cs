using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackblazeQuickShare.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Windows;
using Newtonsoft.Json;

namespace BackblazeQuickShare.ViewModels
{
    [ObservableObject]
    public partial class SettingViewModel
    {
        //private IOptionsMonitor<Config> config;
        [ObservableProperty]
        private string _keyID;
        [ObservableProperty]
        private string _applicationKey;
        [ObservableProperty]
        private string _url;

        public SettingViewModel()
        {
            // this.config = config;
            //config.OnChange((configChanged, str) =>
            // {
            //     MessageBox.Show(configChanged.ApplicationKey);
            //     MessageBox.Show(str);
            // });
            var config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("config.json"));
            (KeyID, ApplicationKey, Url) = (config.KeyID, config.ApplicationKey, config.Url);
        }

        [RelayCommand]
        private async void Save()
        {
            //MessageBox.Show($"{config.CurrentValue.KeyID},{config.CurrentValue.ApplicationKey},{config.CurrentValue.Url}");
            var newConfig = new Config
            {
                KeyID = this.KeyID,
                ApplicationKey = this.ApplicationKey,
                Url = this.Url,
            };
            var json = JsonConvert.SerializeObject(newConfig);

            await File.WriteAllTextAsync("config.json", json);
            MessageBox.Show("Success");
            //MessageBox.Show($"{config.CurrentValue.KeyID},{config.CurrentValue.ApplicationKey},{config.CurrentValue.Url}");
        }

    }
}
