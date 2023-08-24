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
            set {
                Set(ref _project, value);
                UpdateDirView();
            }
        }

        public string ProjectName {
            get => _projectName;
            set {
                Set(ref _projectName, value);
                UpdateDirView();
            }
        }

        public string ProjectPath {
            get => _projectPath;
            set {
                Set(ref _projectPath, value);
                UpdateDirView();
            }
        }

        public ICommand CreateProjectCommand { get; }
        public ICommand GetDirectoryCommand { get; }

        public NewProjectViewModel() {
            CreateProjectCommand = new RelayCommand(CreateProject);
            GetDirectoryCommand = new RelayCommand(GetDirectory);
            UpdateDirView();
            //Project = new Project();
        }
        public string DirView {
            get => _dirView;
            private set => Set(ref _dirView, value);
        }

        private async void CreateProject() {
            // DESC: Validate Field
            if (String.IsNullOrEmpty(ProjectName)) {
                var a = new MessageDialog("Project Name filed is empty!");
                await a.ShowAsync();
                return;
            }

            if (String.IsNullOrEmpty(ProjectPath)) {
                var b = new MessageDialog("Invalid Project Path");
                await b.ShowAsync();
                return;
            }

            var c = new MessageDialog("Create Project!!");
            await c.ShowAsync();



            // 프로젝트 생성 로직
            // 디렉토리 생성, 파일 생성 등
        }

        private void UpdateDirView() {
            DirView = $"your project will be created in '{ProjectPath}\\{ProjectName}'";
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
