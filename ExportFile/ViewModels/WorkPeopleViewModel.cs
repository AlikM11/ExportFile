using ExportFile.Commands;
using ExportFile.Interfaces;
using ExportFile.Models;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using ExportFile.Services;
using Microsoft.Win32;
using System.Windows;
using System.Threading;

namespace ExportFile.ViewModels
{
    public class WorkPeopleViewModel : BaseViewModel, IPageViewModel, INotifyPropertyChanged
    {

        private List<WorkPeople> _users;
        private List<WorkPeople> _selectedUsers { get; set; }

        public List<WorkPeople> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        public RelayCommand CSVExportCommand { get; set; }
        public RelayCommand TXTExportCommand { get; set; }

        public WorkPeopleViewModel()
        {
            Users = FakeDataService.GetWorkerPeopleData();
            CSVExportCommand = new RelayCommand(CSVExportCommandExecute);
            TXTExportCommand = new RelayCommand(TXTExportCommandExecute);
        }

        private void CSVExportCommandExecute(object Users)
        {
            var json = JsonConvert.SerializeObject(Users);
            JsonNode node = JsonNode.Parse(json);
            _selectedUsers = new List<WorkPeople>();
            if(node != null)
            {
                foreach (var item in node.AsArray())
                {
                    var user = item.Deserialize<WorkPeople>();
                    _selectedUsers.Add(user);
                }
                var dialog = new SaveFileDialog();
                dialog.ShowDialog();
                var path = dialog.FileName;
                ExportService.ExportCSVData(_selectedUsers, path);
                Thread.Sleep(2000);
                MessageBox.Show("File Exported...");
            }
            else MessageBox.Show("Please Select row or rows ..");
        }
        
        private void TXTExportCommandExecute(object Users)
        {
            var json = JsonConvert.SerializeObject(Users);
            JsonNode node = JsonNode.Parse(json);
            _selectedUsers = new List<WorkPeople>();
            if(node != null)
            {
                foreach (var item in node.AsArray())
                {
                    var user = item.Deserialize<WorkPeople>();
                    _selectedUsers.Add(user);
                }
                var dialog = new SaveFileDialog();
                dialog.ShowDialog();
                var path = dialog.FileName;
                ExportService.ExportTXTData(_selectedUsers, path);
                Thread.Sleep(2000);
                MessageBox.Show("File Exported...");
            }
            else MessageBox.Show("Please Select row or rows ..");
        }
    }
}
