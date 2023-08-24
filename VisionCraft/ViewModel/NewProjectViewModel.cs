using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.IO;
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

            // 프로젝트 디렉토리 경로
            string projectDir = $"{ProjectPath}\\{ProjectName}";

            // 프로젝트 디렉토리 생성

            StorageFolder folder; // 이걸 활용해야 할 것 같아.
            Directory.CreateDirectory(projectDir);

            // 하위 디렉토리들 생성
            Directory.CreateDirectory(Path.Combine(projectDir, "Labels"));
            Directory.CreateDirectory(Path.Combine(projectDir, "Images"));
            Directory.CreateDirectory(Path.Combine(projectDir, "Augmentation"));
            Directory.CreateDirectory(Path.Combine(projectDir, "Train"));

            // 프로젝트 생성 완료 메시지
            var messageDialog = new MessageDialog("Project created successfully!");
            await messageDialog.ShowAsync();
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
