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
    /// Логика взаимодействия для Credits.xaml
    /// </summary>
    public partial class CreditsPage : Page
    {
        public CreditsPage()
        {
            InitializeComponent();

		}
		private void btnClickAddCredit(object sender, RoutedEventArgs e)
		{
			AddCredit addCredit = new AddCredit();
			addCredit.Show();
		}
		private void btnClickPayOffDebt(object sender, RoutedEventArgs e)
		{
			//перемещение на страницу погашения долга(личного кошелька)
		}

		private void CreditsPage_Loaded(object sender, RoutedEventArgs e)
		{
			
		}
	}
}
