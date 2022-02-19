using System.Windows;
using CSharp_Khodakivska_01.ViewModels;

namespace CSharp_Khodakivska_01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new BirthdayViewModel();
        }
    }
}
