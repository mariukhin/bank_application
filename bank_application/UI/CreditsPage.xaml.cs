using System.Windows;
using System.Windows.Controls;
using bank_application.ViewModel;

namespace bank_application
{
    /// <summary>
    /// Логика взаимодействия для Credits.xaml
    /// </summary>
    public partial class CreditsPage : Page
    {
		public CreditsPage(ClientViewModel uvm)
        {
            InitializeComponent();
			DataContext = uvm;

		}
		private void btnClickPayOffDebt(object sender, RoutedEventArgs e)
		{
			//перемещение на страницу погашения долга(личного кошелька)
		}
	}
}
