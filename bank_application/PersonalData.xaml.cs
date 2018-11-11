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
    /// Логика взаимодействия для PersonalData.xaml
    /// </summary>
    public partial class PersonalData : Page
    {
        public PersonalData()
        {
            InitializeComponent();
        }

		private void btnClickGetPersonalData(object sender, RoutedEventArgs e)
		{
			//Client client = new Client();
			//MessageBox.Show(client.ToString());
		}

		private void btnClickChangePhone(object sender, RoutedEventArgs e)
		{
			//функция изменения телефона
		}

		private void btnClickChangePassword(object sender, RoutedEventArgs e)
		{
			//функция изменения пароля
		}

		private void btnClickChangeEmail(object sender, RoutedEventArgs e)
		{
			//функция изменения имейла
		}

		private void btnClickChangeFullName(object sender, RoutedEventArgs e)
		{
			//функция изменения имени и фамилии
		}
	}
}
