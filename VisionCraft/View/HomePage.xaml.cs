using System;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace VisionCraft.View {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page {
        public HomePage() {
            this.InitializeComponent();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e) {

            //var folderPicker = new FolderPicker();
            //folderPicker.FileTypeFilter.Add("*");

            //StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            //if (folder != null) {
            //    var a = new MessageDialog($"{folder.Path}");
            //    await a.ShowAsync();
            //}
            //else {

            //}
        }
    }
}
