using System;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Input;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Search;
using Windows.UI.Popups;
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
        public ICommand GetDirectoryCommand { get; }

        public NewProjectViewModel() {
            CreateProjectCommand = new RelayCommand(CreateProject);
            GetDirectoryCommand = new RelayCommand(GetDirectory);
            Project = new Project();
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
                var a = new MessageDialog($"{folder.Path}");
                await a.ShowAsync();
            } else {

            }
        }
    }
}
