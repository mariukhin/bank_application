using System.Windows.Controls;
using bank_application.ViewModel;

namespace bank_application
{
    /// <summary>
    /// Логика взаимодействия для Moneybox.xaml
    /// </summary>
    public partial class Moneybox : Page
    {
        public Moneybox(ClientViewModel cvm)
        {
            InitializeComponent();
			DataContext = cvm;
		}
	}
}
