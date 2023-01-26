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
    public class CompanyViewModel : BaseViewModel, IPageViewModel, INotifyPropertyChanged
    {

        private List<Company> _companies;
        private List<Company> _selectedCompanies { get; set; }


        public List<Company> Companies
        {
            get => _companies;
            set
            {
                _companies = value;
                OnPropertyChanged(nameof(Companies));
            }
        }

        public RelayCommand CSVExportCommand { get; set; }
        public RelayCommand TXTExportCommand { get; set; }
        public CompanyViewModel()
        {
            Companies = FakeDataService.GetCompaniesData();
            CSVExportCommand = new RelayCommand(CSVExportCommandExecute);
            TXTExportCommand = new RelayCommand(TXTExportCommandExecute);
        }
        private void CSVExportCommandExecute(object Users)
        {
            var json = JsonConvert.SerializeObject(Users);
            JsonNode node = JsonNode.Parse(json);
            _selectedCompanies = new List<Company>();
            if (node != null)
            {
                foreach (var item in node.AsArray())
                {
                    var user = item.Deserialize<Company>();
                    _selectedCompanies.Add(user);
                }
                var dialog = new SaveFileDialog();
                dialog.ShowDialog();
                var path = dialog.FileName;
                ExportService.ExportCSVData(_selectedCompanies, path);
                Thread.Sleep(2000);
                MessageBox.Show("File Exported...");
            }
            else MessageBox.Show("Please Select row or rows ..");
        }

        private void TXTExportCommandExecute(object Users)
        {
            var json = JsonConvert.SerializeObject(Users);
            JsonNode node = JsonNode.Parse(json);
            _selectedCompanies = new List<Company>();
            if (node != null)
            {
                foreach (var item in node.AsArray())
                {
                    var user = item.Deserialize<Company>();
                    _selectedCompanies.Add(user);
                }
                var dialog = new SaveFileDialog();
                dialog.ShowDialog();
                var path = dialog.FileName;
                ExportService.ExportTXTData(_selectedCompanies, path);
                Thread.Sleep(2000);
                MessageBox.Show("File Exported...");
            }
            else MessageBox.Show("Please Select row or rows ..");
        }
    }
}
