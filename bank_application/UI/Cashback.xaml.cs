using System.Windows.Controls;
using bank_application.ViewModel;

namespace bank_application
{
    /// <summary>
    /// Логика взаимодействия для Cashback.xaml
    /// </summary>
    public partial class Cashback : Page
    {
		public Cashback(ClientViewModel cvm)
        {
            InitializeComponent();
			DataContext = cvm;
		}
	}
}
