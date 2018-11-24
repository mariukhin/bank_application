using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
		ClientViewModel nuvm;
		public CreditsPage(ClientViewModel uvm)
        {
            InitializeComponent();
			nuvm = uvm;
			DataContext = uvm;

		}
		private void btnClickAddCredit(object sender, RoutedEventArgs e)
		{
			AddCredit addCredit = new AddCredit(nuvm);
			addCredit.Show();
		}
		private void btnClickPayOffDebt(object sender, RoutedEventArgs e)
		{
			//перемещение на страницу погашения долга(личного кошелька)
		}
	}
}
