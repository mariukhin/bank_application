using System.Windows;
using System.Windows.Controls;
using bank_application.ViewModel;

namespace bank_application
{
    /// <summary>
    /// Логика взаимодействия для Credits.xaml
    /// </summary>
    public partial class CreditsPage : Page
    {
		public CreditsPage(ClientViewModel uvm)
        {
            InitializeComponent();
			DataContext = uvm;

		}
	}
}
