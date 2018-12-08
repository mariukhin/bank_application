using System.Windows;
using bank_application.ViewModel;

namespace bank_application.UI
{
	/// <summary>
	/// Логика взаимодействия для ChangeData.xaml
	/// </summary>
	public partial class ChangeData : Window
	{
		public ChangeData(ClientViewModel uvm)
		{
			InitializeComponent();
			DataContext = uvm;
		}
	}
}
