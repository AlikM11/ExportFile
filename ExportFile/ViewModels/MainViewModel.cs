using ExportFile.Commands;
using ExportFile.Interfaces;
using System.Windows.Input;

namespace ExportFile.ViewModels
{

    public class MainViewModel : BaseViewModel
    {

        private IPageViewModel? _pageViewModelCommand;
        public ICommand CarsViewModelCommand { get; set; }
        public ICommand ProductViewModelCommand { get; set; }
        public ICommand CompaniesViewModelCommand { get; set; }
        public ICommand FootballerViewModelCommand { get; set; }
        public ICommand WorkPeopleViewModelCommand { get; set; }

        public IPageViewModel? CurrentPageViewModel
        {
            get => _pageViewModelCommand;
            set
            {
                _pageViewModelCommand = value;
                OnPropertyChanged(nameof(CurrentPageViewModel));
            }
        }

        public MainViewModel()
        {
            CurrentPageViewModel = new WorkPeopleViewModel();
            CarsViewModelCommand = new RelayCommand((s) => { CurrentPageViewModel = new CarViewModel(); });
            ProductViewModelCommand = new RelayCommand((s) => { CurrentPageViewModel = new ProductViewModel(); });
            CompaniesViewModelCommand = new RelayCommand((s) => { CurrentPageViewModel = new CompanyViewModel(); });
            WorkPeopleViewModelCommand = new RelayCommand((s) =>{ CurrentPageViewModel = new WorkPeopleViewModel(); });
            FootballerViewModelCommand = new RelayCommand((s) => { CurrentPageViewModel = new FootballerViewModel(); });
        }

    }
}
