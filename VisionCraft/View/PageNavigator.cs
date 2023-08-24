using Windows.UI.Xaml.Controls;

namespace VisionCraft.View {
    public class PageNavigator {
        public static Frame Frame;
        public void NavigatePage(string tag) {
            switch (tag) {
                case "_home":
                    Frame.Navigate(typeof(HomePage));
                    break;
            }
        }
    }
}
