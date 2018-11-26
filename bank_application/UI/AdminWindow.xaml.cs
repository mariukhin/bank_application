using System.Windows;
using bank_application.ViewModel;


namespace bank_application
{
	/// <summary>
	/// Логика взаимодействия для AdminWindow.xaml
	/// </summary>
	public partial class AdminWindow : Window
	{
		public AdminWindow(AdminViewModel avm)
		{
			InitializeComponent();
			DataContext = avm;
		}
		private void btnClose_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
