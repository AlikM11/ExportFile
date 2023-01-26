using ExportFile.Commands;
using ExportFile.Interfaces;
using ExportFile.Models;
using ExportFile.Services;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Windows;

namespace ExportFile.ViewModels
{
    public class FootballerViewModel : BaseViewModel, IPageViewModel, INotifyPropertyChanged
    {

        private List<Footballer> _footballers;
        private List<Footballer> _selectedFootballers { get; set; }

        public List<Footballer> Footballers
        {
            get => _footballers;
            set
            {
                _footballers = value;
                OnPropertyChanged(nameof(Footballers));
            }
        }



        public RelayCommand CSVExportCommand { get; set; }
        public RelayCommand TXTExportCommand { get; set; }
        public FootballerViewModel()
        {
            Footballers = FakeDataService.GetFootballersData();
            CSVExportCommand = new RelayCommand(CSVExportCommandExecute);
            TXTExportCommand = new RelayCommand(TXTExportCommandExecute);
        }
        private void CSVExportCommandExecute(object Users)
        {
            var json = JsonConvert.SerializeObject(Users);
            JsonNode node = JsonNode.Parse(json);
            _selectedFootballers = new List<Footballer>();
            if (node != null)
            {
                foreach (var item in node.AsArray())
                {
                    var user = item.Deserialize<Footballer>();
                    _selectedFootballers.Add(user);
                }
                var dialog = new SaveFileDialog();
                dialog.ShowDialog();
                var path = dialog.FileName;
                ExportService.ExportCSVData(_selectedFootballers, path);
                Thread.Sleep(2000);
                MessageBox.Show("File Exported...");
            }
            else MessageBox.Show("Please Select row or rows ..");
        }

        private void TXTExportCommandExecute(object Users)
        {
            var json = JsonConvert.SerializeObject(Users);
            JsonNode node = JsonNode.Parse(json);
            _selectedFootballers = new List<Footballer>();
            if (node != null)
            {
                foreach (var item in node.AsArray())
                {
                    var user = item.Deserialize<Footballer>();
                    _selectedFootballers.Add(user);
                }
                var dialog = new SaveFileDialog();
                dialog.ShowDialog();
                var path = dialog.FileName;
                ExportService.ExportTXTData(_selectedFootballers, path);
                Thread.Sleep(2000);
                MessageBox.Show("File Exported...");
            }
            else MessageBox.Show("Please Select row or rows ..");
        }
    }
}
