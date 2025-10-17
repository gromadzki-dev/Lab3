using lab3;
using System.Collections.ObjectModel;
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

namespace Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Vessels> Vessels { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Vessels = new ObservableCollection<Vessels>
            {
                new Vessels { Name = "Filizanka", Volume = 200 },
                new Vessels { Name = "Kubek", Volume = 300 },
                new Vessels { Name = "Szklanka", Volume = 250 }
            };
            DataContext = this;
        }

        private void OnChangeValue(object sender, TextChangedEventArgs e)
        {
            // TextBoxVolume
            // TextBoxSubstancePercent
            // TextBoxNumber
            // ComboBoxVessel

            if (string.IsNullOrEmpty(TextBoxVolume.Text))
            {
                ClearContent();
                return;
            }
            if (string.IsNullOrEmpty(TextBoxSubstancePercent.Text))
            {
                ClearContent();
                return;
            }
            if (string.IsNullOrEmpty(TextBoxNumber.Text))
            {
                ClearContent();
                return;
            }

            foreach (Vessels v in Vessels)
            {
                if (v.Volume == double.Parse(TextBoxVolume.Text))
                {
                    ComboBoxVessel.SelectedItem = v;
                }
            }

            CalculationClass calculation = new CalculationClass { Volume = double.Parse(TextBoxVolume.Text), Percentage = double.Parse(TextBoxSubstancePercent.Text), Amount = int.Parse(TextBoxNumber.Text)};

            double CalculatedPercentage = calculation.PureSubstancePercentage();
            double TotalVolume = Math.Round(calculation.TotalVolume(), 5);

            // LabelResultVolumeOutput
            // LabelResultSubstanceOutput

            LabelResultVolumeOutput.Content = TotalVolume;
            LabelResultSubstanceOutput.Content = CalculatedPercentage;
        }

        private void OnChangedVessel(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void ClearContent() 
        {
            LabelResultVolumeOutput.Content = string.Empty;
            LabelResultSubstanceOutput.Content = string.Empty;
        }
    }
}