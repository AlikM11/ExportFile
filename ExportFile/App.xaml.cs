using ExportFile.Commands;
using ExportFile.Interfaces;
using ExportFile.Models;
using ExportFile.ViewModels;
using ExportFile.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ExportFile
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            AppHost = Host.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<MainView>();
                services.AddSingleton<CarView>();
                services.AddSingleton<CompanyView>();
                services.AddSingleton<FootballerView>();
                services.AddSingleton<ProductView>();
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<CarViewModel>();
                services.AddSingleton<CompanyViewModel>();
                services.AddSingleton<FootballerViewModel>();
                services.AddSingleton<ProductViewModel>();
            }).Build();
        }
        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();
            var startupForm = AppHost.Services.GetRequiredService<MainView>();
            startupForm!.DataContext = new MainViewModel();
            startupForm!.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            base.OnExit(e);
        }


        public static IHost? AppHost { get; private set; }
    }
}
