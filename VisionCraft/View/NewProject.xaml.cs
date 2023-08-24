using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight.Command;
using VisionCraft.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace VisionCraft.View {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewProject : Page {
        private NewProjectViewModel viewModel;
        public NewProject() {
            this.InitializeComponent();
            DataContext = viewModel;
        }
    }
}
