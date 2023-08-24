using GalaSoft.MvvmLight;

namespace VisionCraft.ViewModel {
    public class MainView : ViewModelBase {
        private string _windowTitle;

        public string WindowTitle {
            get => _windowTitle;
            set => Set(ref _windowTitle, value); // INotifyPropertyChanged Alert
        }

        private bool _isNavigationItemValidate;

        public bool IsNavigationItemValidate {
            get => _isNavigationItemValidate;
            set => Set(ref _isNavigationItemValidate, value);
        }

        public MainView(string title = "Vision Craft") {
            // DESC: UI Caption Processing
            WindowTitle = title;
        }
    }
}
