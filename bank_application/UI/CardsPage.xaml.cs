using System.Windows;
using System.Windows.Controls;
using bank_application.ViewModel;

namespace bank_application
{
    /// <summary>
    /// Логика взаимодействия для Cards.xaml
    /// </summary>
    public partial class CardsPage : Page
    {
		public CardsPage(ClientViewModel uvm)
        {
            InitializeComponent();
			DataContext = uvm;
		}
	}
}
