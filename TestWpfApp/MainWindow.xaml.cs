using System.Windows;
using TestWpfApp.Data;
using TestWpfApp.ViewModel;

namespace TestWpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            IDataProvider dataProvider = new MoqRepo();
            DataContext = new MainViewModel(dataProvider);
        }
    }
}