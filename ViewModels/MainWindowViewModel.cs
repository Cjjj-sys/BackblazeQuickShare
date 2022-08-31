using BackblazeQuickShare.Model;
using Bytewizer.Backblaze.Client;
using Bytewizer.Backblaze.Models;
using Bytewizer.Backblaze.Progress;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace BackblazeQuickShare.ViewModels
{
    [ObservableObject]
    public partial class MainWindowViewModel
    {
        private DragViewModel dragViewModel;
        private SettingViewModel settingViewModel;
        [ObservableProperty]
        private INotifyPropertyChanged _currentViewModel;
        [ObservableProperty]
        private string _fileName;
        [ObservableProperty]
        private double _progress;
        [ObservableProperty]
        private string _status;
        [ObservableProperty]
        private string _info;

        public MainWindowViewModel(DragViewModel dragViewModel, SettingViewModel settingViewModel)
        {
            this.dragViewModel = dragViewModel;
            this.settingViewModel = settingViewModel;
            _currentViewModel = dragViewModel;
        }

        [RelayCommand]
        public void NavigateTo(string view)
        {
            CurrentViewModel = view switch
            {
                "Drag" => dragViewModel,
                "Setting" => settingViewModel
            };
        }

        [RelayCommand]
        public async void TryUploadFile(string fileName)
        {
/*            try
            {*/
                /*CancellationToken token = new();
                ProgressBar progress = new ProgressBar();
                progress.ProgressChanged += (s, p) =>
                {
                    Progress = p.PercentComplete;
                    Info = $"Total: {p.BytesTransferred}, Time: {p.TransferTime}, {p.PercentComplete}";
                };
                FileName = fileName;
                var config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("config.json"));
                var client = new BackblazeClient();
                await client.ConnectAsync(config.KeyID, config.ApplicationKey);
                var bukkits = await client.Buckets.GetAsync();
                var request = new UploadFileByBucketIdRequest(bukkits.First().BucketId, fileName);
                using FileStream fs = new(fileName, FileMode.Open);
                var uploadResults = await client.UploadAsync(request, fs, progress, token);
                if (uploadResults.IsSuccessStatusCode)
                {
                    Clipboard.SetText(config.Url.EndsWith("/") ? $"{config.Url}{fileName}" : $"{config.Url}/{fileName}");
                    MessageBox.Show("Success");
                }
                fs.Close();*/
/*            }
            catch (Exception ex)
            {
#if DEBUG
                throw;
#endif
                MessageBox.Show($"出了点小错误:\n{ex.Message}", ex.Source);
            }*/
            
        }
    }
}
