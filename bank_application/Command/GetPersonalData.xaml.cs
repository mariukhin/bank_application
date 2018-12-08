using System.Windows.Controls;
using bank_application.ViewModel;

namespace bank_application.Command
{
	/// <summary>
	/// Логика взаимодействия для GetPersonalData.xaml
	/// </summary>
	public partial class GetPersonalData : UserControl
	{
		public GetPersonalData(ClientViewModel cvm)
		{
			InitializeComponent();
			DataContext = cvm;
		}
	}
}
