using System.Windows;

namespace CalculatorChallenge.Views
{
    /// <summary>
    /// Interaction logic for CalculatorView.xaml
    /// </summary>
    public partial class CalculatorView : Window
    {
        public CalculatorView()
        {
            InitializeComponent();

            DataContext = new ViewModels.CalculatorViewModel();
        }
    }
}
