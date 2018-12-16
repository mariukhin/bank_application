using System.Windows;
using bank_application.ViewModel;

namespace bank_application.UI
{
	/// <summary>
	/// Логика взаимодействия для TransferMoneyBox.xaml
	/// </summary>
	public partial class TransferMoneyBox : Window
	{
		public TransferMoneyBox(ClientViewModel uvm)
		{
			InitializeComponent();
			DataContext = uvm;
		}
	}
}
