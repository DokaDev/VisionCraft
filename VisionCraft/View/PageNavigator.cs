using System.Diagnostics;
using Windows.UI.Xaml.Controls;

namespace VisionCraft.View {
    public static class PageNavigator {
        public static Frame Frame;
        

        public static void NavigatePage(string tag) {
            // Navigation Page Logic
            switch (tag) {
                case "_home":
                    Frame.Navigate(typeof(HomePage));
                    break;
                case "_labeling":
                    Frame.Navigate(typeof(LabelingPage));
                    break;
                case "_augmentation":
                    Frame.Navigate(typeof(AugmentationPage));
                    break;
                case "_training":
                    Frame.Navigate(typeof(TrainingPage));
                    break;
                case "terminal":
                    Frame.Navigate(typeof(TrainingPage));
                    break;

                default:
                    Debug.WriteLine("It seems not contained Navigation Items.");
                    break;
            }

            // SubPage Logic
            switch (tag) {
                // New Project Page
                case "NewProject":  
                    Frame.Navigate(typeof(NewProject));
                    break;
            }
        }
    }
}
