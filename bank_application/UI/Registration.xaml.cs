using System.Windows;
using bank_application.ViewModel;

namespace bank_application
{
	/// <summary>
	/// Логика взаимодействия для Registration.xaml
	/// </summary>
	public partial class Registration : Window
	{
		ClientViewModel uvm;

		public Registration()
		{
			InitializeComponent();
			uvm = new ClientViewModel();
			DataContext = uvm;
		}
		
		private void btnClose_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
