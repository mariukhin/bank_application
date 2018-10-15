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

//запилить поля PassportNum и Adress
namespace bank_application
{
	/// <summary>
	/// Логика взаимодействия для Registration.xaml
	/// </summary>
	public partial class Registration : Window
	{
		public Registration()
		{
			InitializeComponent();
		}
		private string Login;
		private void btnComp_Click(object sender, RoutedEventArgs e)
		{
			//1)проверка наличия такого же пользователя в бд
			//2)Валидация всех полей
			if (checkBox1.IsChecked == true)
			{
				Login = tbEmail.Text;
			}
			else
			{
				Login = tbPhone.Text;
			}
			Client client = new Client(tbFirstName.Text, tbSurName.Text, tbAge.Text, Login, tbEmail.Text, tbPhone.Text, pbPassword.Password.ToString());
			//client.addToDB(client);
			Close();
		}
		private void btnClose_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
