using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using VisionCraft.Model;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;

namespace VisionCraft.ViewModel {
    public class NewProjectViewModel : ViewModelBase {
        private Project _project;
        private string _projectName;
        private string _projectPath;

        private string _dirView;

        public Project Project {
            get => _project;
            set => Set(ref _project, value);
        }

        public string ProjectName {
            get => _projectName;
            set => Set(ref _projectName, value);
        }

        public string ProjectPath {
            get => _projectPath;
            set => Set(ref _projectPath, value);
        }

        public ICommand CreateProjectCommand { get; }
        public ICommand GetDirectoryCommand { get; }

        public NewProjectViewModel() {
            CreateProjectCommand = new RelayCommand(CreateProject);
            GetDirectoryCommand = new RelayCommand(GetDirectory);
            //Project = new Project();
        }

        private void CreateProject() {
            // 프로젝트 생성 로직
            // 디렉토리 생성, 파일 생성 등
        }

        private async void GetDirectory() {
            var folderPicker = new FolderPicker();
            folderPicker.FileTypeFilter.Add("*");

            StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if(folder != null) {
                ProjectPath = folder.Path;
                //var a = new MessageDialog($"{folder.Path}");
                //await a.ShowAsync();
            } else {
                var a = new MessageDialog("Canceled!!");
                await a.ShowAsync();
            }
        }
    }
}
