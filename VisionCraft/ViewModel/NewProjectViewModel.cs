using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Input;
using Windows.Storage.Search;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using VisionCraft.Model;

namespace VisionCraft.ViewModel {
    public class NewProjectViewModel : ViewModelBase {
        private Project _project;

        public Project Project {
            get => _project;
            set => Set(ref _project, value);
        }

        public ICommand CreateProjectCommand { get; }

        public NewProjectViewModel() {
            CreateProjectCommand = new RelayCommand(CreateProject);
            Project = new Project();
        }

        private void CreateProject() {
            // 프로젝트 생성 로직
            // 디렉토리 생성, 파일 생성 등
        }
    }
}
