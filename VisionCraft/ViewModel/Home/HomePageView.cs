using System.Diagnostics;
using GalaSoft.MvvmLight;

namespace VisionCraft.ViewModel {
    public class HomePageView : ViewModelBase {
        private string _windowTitle;

        public string WindowTitle {
            get => _windowTitle;
            set => Set(ref _windowTitle, value); // INotifyPropertyChanged Alert
        }

        private bool isProjectOpened;

        public bool IsProjectOpened {
            get => isProjectOpened;
            set {
                Set(ref isProjectOpened, value);
                UpdateStatus();
            }
        }

        private bool _navigationItemStatus;

        public bool NavigationItemStatus {
            get => _navigationItemStatus;
            set => Set(ref _navigationItemStatus, value);
        }

        
        public bool OpenProjectButtonStatus { get; set; }

        private void UpdateStatus() {
            Debug.WriteLine("CheckPoint 1");
            OpenProjectButtonStatus = !isProjectOpened;
            Debug.WriteLine("CheckPoint 2 " + OpenProjectButtonStatus.ToString());
            NavigationItemStatus = isProjectOpened;
            Debug.WriteLine("CheckPoint 3 " + NavigationItemStatus.ToString());
        }

        public HomePageView(string title = "Vision Craft") {
            WindowTitle = title;
            IsProjectOpened = Static.Config.IsProjectOpened;
        }
    }
}
