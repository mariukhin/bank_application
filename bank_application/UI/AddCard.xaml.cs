using System.Windows;
using bank_application.ViewModel;

namespace bank_application
{
	/// <summary>
	/// Логика взаимодействия для AddCard.xaml
	/// </summary>
	public partial class AddCard : Window
	{
		public AddCard(ClientViewModel uvm)
		{
			InitializeComponent();
			DataContext = uvm;
		}
	}
}
