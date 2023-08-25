using Windows.UI.Xaml.Controls;
using VisionCraft.ViewModel.Labeling;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace VisionCraft.View {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LabelingPage : Page {
        LabelingView lbView = new LabelingView();
        public LabelingPage() {
            this.InitializeComponent();
            DataContext = lbView;
        }
    }
}
