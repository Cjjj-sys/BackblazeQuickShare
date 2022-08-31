using BackblazeQuickShare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BackblazeQuickShare
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel mainWindowViewModel;

        public MainWindow(MainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();
            this.mainWindowViewModel = mainWindowViewModel;
        }

        private void DragDropBorder_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Link;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
        }
        private void DragDropBorder_Drop(object sender, DragEventArgs e)
        {
            var fileName = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            if (mainWindowViewModel.TryUploadFileCommand.CanExecute(fileName))
            {
                mainWindowViewModel.TryUploadFileCommand.Execute(fileName);
            }
        }   
    }
}
