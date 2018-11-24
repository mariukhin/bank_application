using System.Windows;
using bank_application.ViewModel;

namespace bank_application.UI
{
	/// <summary>
	/// Логика взаимодействия для TransferMoney.xaml
	/// </summary>
	public partial class TransferMoney : Window
	{
		public TransferMoney(ClientViewModel uvm)
		{
			InitializeComponent();
			DataContext = uvm;
		}
	}
}
