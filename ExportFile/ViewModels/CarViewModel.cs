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
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace ExportFile.ViewModels
{
    class CarViewModel : BaseViewModel, IPageViewModel, INotifyPropertyChanged
    {

        private List<Car> _cars;
        private List<Car> _selectedCars { get; set; }

        public List<Car> Cars
        {
            get => _cars;
            set
            {
                _cars = value;
                OnPropertyChanged(nameof(Cars));
            }
        }


        public RelayCommand CSVExportCommand { get; set; }
        public RelayCommand TXTExportCommand { get; set; }

        public CarViewModel()
        {
            Cars = FakeDataService.GetCarsData();
            CSVExportCommand = new RelayCommand(CSVExportCommandExecute);
            TXTExportCommand = new RelayCommand(TXTExportCommandExecute);
        }

        private void CSVExportCommandExecute(object Users)
        {
            var json = JsonConvert.SerializeObject(Users);
            JsonNode node = JsonNode.Parse(json);
            _selectedCars = new List<Car>();
            if (node != null)
            {
                foreach (var item in node.AsArray())
                {
                    var user = item.Deserialize<Car>();
                    _selectedCars.Add(user);
                }
                var dialog = new SaveFileDialog();
                dialog.ShowDialog();
                var path = dialog.FileName;
                ExportService.ExportCSVData(_selectedCars, path);
                Thread.Sleep(2000);
                MessageBox.Show("File Exported...");
            }
            else MessageBox.Show("Please Select row or rows ..");
        }

        private void TXTExportCommandExecute(object Users)
        {
            var json = JsonConvert.SerializeObject(Users);
            JsonNode node = JsonNode.Parse(json);
            _selectedCars = new List<Car>();
            if (node != null)
            {
                foreach (var item in node.AsArray())
                {
                    var user = item.Deserialize<Car>();
                    _selectedCars.Add(user);
                }
                var dialog = new SaveFileDialog();
                dialog.ShowDialog();
                var path = dialog.FileName;
                ExportService.ExportTXTData(_selectedCars, path);
                Thread.Sleep(2000);
                MessageBox.Show("File Exported...");
            }
            else MessageBox.Show("Please Select row or rows ..");
        }
    }
}
