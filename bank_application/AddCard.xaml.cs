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
using System.Windows.Shapes;

namespace bank_application
{
	/// <summary>
	/// Логика взаимодействия для AddCard.xaml
	/// </summary>
	public partial class AddCard : Window
	{
		public AddCard()
		{
			InitializeComponent();
		}

		private void btnClickAddCard(object sender, RoutedEventArgs e)
		{
			//0)проверка чекбокса
			//1)проверка платежеспособности клиента
			//Card card = new Card()
			Close();
		}
	}
}
