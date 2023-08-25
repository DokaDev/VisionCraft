using VisionCraft.ViewModel;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace VisionCraft.View {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewProject : Page {
        private NewProjectViewModel viewModel = new NewProjectViewModel();
        public NewProject() {
            this.InitializeComponent();
            DataContext = viewModel;
        }
    }
}