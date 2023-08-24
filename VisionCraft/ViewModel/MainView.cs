using System;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using Windows.UI.Popups;

namespace VisionCraft.ViewModel {
    public class MainView : ViewModelBase {
        private string _windowTitle;

        public string WindowTitle {
            get => _windowTitle;
            set => Set(ref _windowTitle, value); // INotifyPropertyChanged Alert
        }

        public ICommand CheckFileSystemStatus;

        private bool _isNavigationItemValidate;

        public bool IsNavigationItemValidate {
            get => _isNavigationItemValidate;
            set => Set(ref _isNavigationItemValidate, value);
        }

        public MainView(string title = "Vision Craft") {
            // DESC: UI Caption Processing
            WindowTitle = title;

            CheckFileSystemStatus = new RelayCommand(ValidatePath);
        }
        private async void ValidatePath() {
            // TODO: Pref..
        }
    }
}
