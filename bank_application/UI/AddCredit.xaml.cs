using System.Windows;
using bank_application.ViewModel;


namespace bank_application
{
	/// <summary>
	/// Логика взаимодействия для AddCredit.xaml
	/// </summary>
	public partial class AddCredit : Window
	{
		public AddCredit(ClientViewModel uvm)
		{
			InitializeComponent();
			DataContext = uvm;
		}
		
	}
}
