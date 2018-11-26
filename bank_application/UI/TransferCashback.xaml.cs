using System.Windows;
using bank_application.ViewModel;

namespace bank_application.UI
{
	/// <summary>
	/// Логика взаимодействия для TransferCashback.xaml
	/// </summary>
	public partial class TransferCashback : Window
	{
		public TransferCashback(ClientViewModel uvm)
		{
			InitializeComponent();
			DataContext = uvm;
		}
	}
}
