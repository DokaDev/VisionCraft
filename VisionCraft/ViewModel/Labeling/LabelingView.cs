using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using VisionCraft.Model;

namespace VisionCraft.ViewModel.Labeling {
    public class LabelingView : ViewModelBase {
        private ObservableCollection<LabelClass> lbClasses = new ObservableCollection<LabelClass>();

        public ObservableCollection<LabelClass> LabelClasses {
            get => lbClasses;
            set => Set(ref lbClasses, value);
        }

        public LabelingView() {
            lbClasses.Add(new LabelClass() {
                Name = "TestName1",
                Description = "TestDescription1"
            });
            lbClasses.Add(new LabelClass() {
                Name = "TestName2",
                Description = "TestDescription2"
            });
        }
    }
}
