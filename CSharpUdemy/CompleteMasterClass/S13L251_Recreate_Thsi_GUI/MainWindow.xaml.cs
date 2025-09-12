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

namespace S13L251_Recreate_Thsi_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // < Button Grid.Column = "4" Content = "B" Grid.Row = "3" />
            Button button = new Button();
            button.Content = "B";
            Grid.SetColumn(button, 4);
            Grid.SetRow(button, 3);
            Grid? mainGrid = FindName("myGrid") as Grid;
            mainGrid?.Children.Add(button);
        }
    }
}