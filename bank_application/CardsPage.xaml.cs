using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace bank_application
{
    /// <summary>
    /// Логика взаимодействия для Cards.xaml
    /// </summary>
    public partial class CardsPage : Page
    {
        public CardsPage()
        {
            InitializeComponent();
        }

		private void btnClickAddCard(object sender, RoutedEventArgs e)
		{
			AddCard addCard = new AddCard();
			addCard.Show();
		}

		private void btnClickTransfer(object sender, RoutedEventArgs e)
		{
			//окно переводов
		}

		private void btnClickTopUp(object sender, RoutedEventArgs e)
		{
			//окно пополнения мобильного
		}
	}
}
