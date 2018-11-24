using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using bank_application.ViewModel;
using bank_application.UI;

namespace bank_application
{
    /// <summary>
    /// Логика взаимодействия для Cards.xaml
    /// </summary>
    public partial class CardsPage : Page
    {
		ClientViewModel nuvm;
		public CardsPage(ClientViewModel uvm)
        {
            InitializeComponent();
			nuvm = uvm;
			DataContext = uvm;
		}

		private void btnClickAddCard(object sender, RoutedEventArgs e)
		{
			AddCard addCard = new AddCard(nuvm);
			addCard.Show();
		}

		private void btnClickTransfer(object sender, RoutedEventArgs e)
		{
			TransferMoney transferMoney = new TransferMoney(nuvm);
			transferMoney.Show();
		}

		private void btnClickTopUp(object sender, RoutedEventArgs e)
		{
			//окно пополнения мобильного
		}
	}
}
