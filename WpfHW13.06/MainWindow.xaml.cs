using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfHW13._06
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TemperatureViewModel temperatureViewModel;
        public MainWindow()
        {
            InitializeComponent();
            temperatureViewModel = new TemperatureViewModel();
            DataContext = temperatureViewModel;
        }
    }

    public class TemperatureViewModel : INotifyPropertyChanged
    {
        private float _celsius;
        private float _fahrenheit;
        private float _kelvin;

        public TemperatureViewModel()
        {
            ConvertCommand = new RelayCommand<string>(ConvertTemperature);
        }

        public ICommand ConvertCommand { get; }

        private void ConvertTemperature(string scale)
        {
            switch (scale)
            {
                case "Celsius":
                    Fahrenheit = (Celsius * 9.0f / 5.0f) + 32;
                    Kelvin = Celsius + 273.15f;
                    break;
                case "Fahrenheit":
                    Celsius = (Fahrenheit - 32) * 5.0f / 9.0f;
                    Kelvin = (Fahrenheit - 32) * 5.0f / 9.0f + 273.15f;
                    break;
                case "Kelvin":
                    Celsius = Kelvin - 273.15f;
                    Fahrenheit = (Kelvin - 273.15f) * 9.0f / 5.0f + 32;
                    break;
            }
        }

        public float Celsius
        {
            get => _celsius;
            set
            {
                if (_celsius != value)
                {
                    _celsius = value;
                    OnPropertyChanged();
                }
            }
        }
        public float Fahrenheit
        {
            get => _fahrenheit;
            set
            {
                if (_fahrenheit != value)
                {
                    _fahrenheit = value;
                    OnPropertyChanged();
                }
            }
        }
        public float Kelvin
        {
            get => _kelvin;
            set
            {
                if (_kelvin != value)
                {
                    _kelvin = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler? CanExecuteChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}