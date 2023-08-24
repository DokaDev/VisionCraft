using GalaSoft.MvvmLight;

namespace VisionCraft.ViewModel {
    public class HomePageView : ViewModelBase {
        private bool isProjectOpened = false;

        public bool IsProjectOpened {
            get => isProjectOpened;
            set {
                Set(ref isProjectOpened, value);
                UpdateStatus();
            }
        }

        public bool OpenButtonStatus { get; private set; }

        private void UpdateStatus() {
            if (isProjectOpened) {
                OpenButtonStatus = !isProjectOpened;
            }
        }

        public HomePageView() {
            IsProjectOpened = Static.Config.IsProjectOpened;
        }
    }
}
