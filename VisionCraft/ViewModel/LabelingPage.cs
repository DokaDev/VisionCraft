using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using VisionCraft.Model;

namespace VisionCraft.ViewModel {
    public class LabelingPage : ViewModelBase {
        private ObservableCollection<LabelClass> _class = new ObservableCollection<LabelClass>();

        public ObservableCollection<LabelClass> Class {
            get => _class;
            set => Set(ref _class, value);
        }

        public LabelingPage() {
            _class.Add(new LabelClass() {
                LabelName = "ClassName",
                LabelDescription = "ClassDescription"
            });
        }
    }
}
