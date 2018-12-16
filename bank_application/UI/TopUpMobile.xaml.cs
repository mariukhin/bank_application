using System.Windows;
using bank_application.ViewModel;

namespace bank_application.UI
{
	/// <summary>
	/// Логика взаимодействия для TopUpMobile.xaml
	/// </summary>
	public partial class TopUpMobile : Window
	{
		public TopUpMobile(ClientViewModel uvm)
		{
			InitializeComponent();
			DataContext = uvm;
		}
	}
}
