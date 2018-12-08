using System.Windows;
using System.Windows.Controls;
using bank_application.ViewModel;
using bank_application.Command;

namespace bank_application
{
    /// <summary>
    /// Логика взаимодействия для PersonalData.xaml
    /// </summary>
    public partial class PersonalData : Page
    {
		ClientViewModel nuvm;
        public PersonalData(ClientViewModel uvm)
        {
            InitializeComponent();
			nuvm = uvm;
			DataContext = uvm;
		}

		private void btnClickGetPersonalData(object sender, RoutedEventArgs e)
		{
			GetPersonalData getPersonalData = new GetPersonalData(nuvm);
			stPersonal.Children.Clear();
			stPersonal.Children.Add(getPersonalData);
		}
	}
}
