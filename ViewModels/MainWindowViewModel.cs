using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackblazeQuickShare.ViewModels
{
    [ObservableObject]
    public partial class MainWindowViewModel
    {
        private DragViewModel dragViewModel;
        private SettingViewModel settingViewModel;
        [ObservableProperty]
        private INotifyPropertyChanged _currentViewModel;

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
    }
}
