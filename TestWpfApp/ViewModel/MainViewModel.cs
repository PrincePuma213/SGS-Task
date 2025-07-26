using System.Collections.ObjectModel;
using System.ComponentModel;
using TestWpfApp.Data;
using TestWpfApp.Models;

namespace TestWpfApp.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IDataProvider _dataProvider;
        public MainViewModel(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            LoadCities();
            LoadBrigades();
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        public ObservableCollection<City> Cities { get; set; } = new();
        public ObservableCollection<Workshop> FilteredWorkshops { get; set; } = new();
        public ObservableCollection<Employee> FilteredEmployees { get; set; } = new();
        public ObservableCollection<Brigade> Brigades { get; set; } = new();

        private City? _selectedCity;
        public City? SelectedCity
        {
            get => _selectedCity;
            set
            {
                if (_selectedCity != value)
                {
                    _selectedCity = value;
                    OnPropertyChanged(nameof(SelectedCity));
                    UpdateWorkshops();
                }
            }
        }

        private Workshop? _selectedWorkshop;
        public Workshop? SelectedWorkshop
        {
            get => _selectedWorkshop;
            set
            {
                if (_selectedWorkshop != value)
                {
                    _selectedWorkshop = value;
                    OnPropertyChanged(nameof(SelectedWorkshop));
                    UpdateEmployees();
                }
            }
        }

        private Employee? _selectedEmployee;
        public Employee? SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                if (_selectedEmployee != value)
                {
                    _selectedEmployee = value;
                    OnPropertyChanged(nameof(SelectedEmployee));
                }
            }
        }

        private Brigade? _selectedBrigade;
        public Brigade? SelectedBrigade
        {
            get => _selectedBrigade;
            set
            {
                if (_selectedBrigade != value)
                {
                    _selectedBrigade = value;
                    OnPropertyChanged(nameof(SelectedBrigade));
                }
            }
        }


        private void LoadCities()
        {
            Cities.Clear();
            SelectedCity = null;

            var cities = _dataProvider.GetCities();
            if (cities.Count() > 0)
            {
                foreach (var c in cities)
                    Cities.Add(c);

                SelectedCity = Cities.First();
            }
        }

        private void UpdateWorkshops()
        {
            FilteredWorkshops.Clear();
            SelectedWorkshop = null;

            if (SelectedCity != null)
            {
                var workshops = _dataProvider.GetWorkshopsByCity(SelectedCity.Id);
                if (workshops.Count() > 0)
                {
                    foreach (var w in workshops)
                        FilteredWorkshops.Add(w);

                    SelectedWorkshop = FilteredWorkshops.First();
                }
            }
        }

        private void UpdateEmployees()
        {
            FilteredEmployees.Clear();
            SelectedEmployee = null;

            if (SelectedWorkshop != null)
            {
                var employees = _dataProvider.GetEmployeesByWorkshop(SelectedWorkshop.Id);
                if (employees.Count() > 0)
                    foreach (var e in employees)
                        FilteredEmployees.Add(e);
                SelectedEmployee = FilteredEmployees.First();
            }
        }

        private void LoadBrigades()
        {
            Brigades.Clear();
            SelectedBrigade = null;

            var brigades = _dataProvider.GetBrigades();
            if (brigades.Count() > 0)
                foreach (var b in brigades)
                    Brigades.Add(b);
        }
    }
}
