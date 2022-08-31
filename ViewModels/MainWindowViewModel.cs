using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
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
        public void TryUploadFile(string fileName)
        {
            FileName = fileName;
            MessageBox.Show(fileName);
        }
    }
}
