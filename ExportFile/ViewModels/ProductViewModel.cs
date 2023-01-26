using ExportFile.Commands;
using ExportFile.Interfaces;
using ExportFile.Models;
using ExportFile.Services;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Windows;

namespace ExportFile.ViewModels
{
    public class ProductViewModel : BaseViewModel, IPageViewModel, INotifyPropertyChanged
    {


        private List<Product> _products;
        private List<Product> _selectedProducts { get; set; }


        public List<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        public RelayCommand CSVExportCommand { get; set; }
        public RelayCommand TXTExportCommand { get; set; }

        public ProductViewModel()
        {
            Products = FakeDataService.GetProductsData();
            CSVExportCommand = new RelayCommand(CSVExportCommandExecute);
            TXTExportCommand = new RelayCommand(TXTExportCommandExecute);
        }

        private void CSVExportCommandExecute(object Users)
        {
            var json = JsonConvert.SerializeObject(Users);
            JsonNode node = JsonNode.Parse(json);
            _selectedProducts = new List<Product>();
            if (node != null)
            {
                foreach (var item in node.AsArray())
                {
                    var user = item.Deserialize<Product>();
                    _selectedProducts.Add(user);
                }
                var dialog = new SaveFileDialog();
                dialog.ShowDialog();
                var path = dialog.FileName;
                ExportService.ExportCSVData(_selectedProducts, path);
                Thread.Sleep(2000);
                MessageBox.Show("File Exported...");

            }
            else MessageBox.Show("Please Select row or rows ..");
        }
        private void TXTExportCommandExecute(object Users)
        {
            var json = JsonConvert.SerializeObject(Users);
            JsonNode node = JsonNode.Parse(json);
            _selectedProducts = new List<Product>();
            if (node != null)
            {
                foreach (var item in node.AsArray())
                {
                    var user = item.Deserialize<Product>();
                    _selectedProducts.Add(user);
                }
                var dialog = new SaveFileDialog();
                dialog.ShowDialog();
                var path = dialog.FileName;
                ExportService.ExportTXTData(_selectedProducts, path);
                Thread.Sleep(2000);
                MessageBox.Show("File Exported...");
            }
            else MessageBox.Show("Please Select row or rows ..");

        }
    }
}
