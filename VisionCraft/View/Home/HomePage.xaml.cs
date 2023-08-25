using System;
using System.Runtime.CompilerServices;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VisionCraft.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace VisionCraft.View {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page {
        private HomePageView view = new HomePageView();
        public HomePage() {
            this.InitializeComponent();
            DataContext = view;
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
            PageNavigator.NavigatePage("NewProject");
            
        }
    }
}
