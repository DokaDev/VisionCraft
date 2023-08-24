using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.IO;
using System.Windows.Input;
using VisionCraft.Model;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using VisionCraft.Static;
using VisionCraft.View;

namespace VisionCraft.ViewModel {
    public class NewProjectViewModel : ViewModelBase {
        private Project _project;
        private string _projectName;
        private string _projectPath;

        private string _dirView;

        private StorageFolder projectFolder;

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
            await projectFolder.CreateFolderAsync($"{ProjectName}");

            //Project Directory
            await projectFolder.CreateFolderAsync($"{ProjectName}\\Labels");
            await projectFolder.CreateFolderAsync($"{ProjectName}\\Images");
            await projectFolder.CreateFolderAsync($"{ProjectName}\\Augmentation");
            await projectFolder.CreateFolderAsync($"{ProjectName}\\Train");

            // Project File
            await projectFolder.CreateFileAsync($"{ProjectName}\\{ProjectName}.vcn");

            // 프로젝트 생성 완료 메시지
            var messageDialog = new MessageDialog("Project created successfully!");
            await messageDialog.ShowAsync();

            Static.Config.IsProjectOpened = true;
            PageNavigator.NavigatePage("_home");
        }

        private void UpdateDirView() {
            DirView = $"your project will be created in '{ProjectPath}\\{ProjectName}'";
        }

        private async void GetDirectory() {
            var folderPicker = new FolderPicker();
            folderPicker.FileTypeFilter.Add("*");

            projectFolder = await folderPicker.PickSingleFolderAsync();
            if(projectFolder != null) {
                ProjectPath = projectFolder.Path;
                //var a = new MessageDialog($"{folder.Path}");
                //await a.ShowAsync();

                Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", projectFolder);
            } else {
                var a = new MessageDialog("Canceled!!");
                await a.ShowAsync();
            }
        }
    }
}
