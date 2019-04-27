using System.Windows;
using System.Windows.Navigation;
using bank_application.Command.VisitorPattern;
using bank_application.ViewModel;

namespace bank_application
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
		ClientViewModel nuvm;
        public MainWindow(ClientViewModel uvm)
        {
            InitializeComponent();
			nuvm = uvm;
			DataContext = uvm;
		}

		private void btnClickCredits(object sender, RoutedEventArgs e)
		{
			Main.Content = new CreditsPage(nuvm);
		}
		private void btnClickDeposits(object sender, RoutedEventArgs e)
		{
			Main.Content = new DepositsPage(nuvm);
		}
		private void btnClickMyCards(object sender, RoutedEventArgs e)
		{
			Main.Content = new CardsPage(nuvm);
		}
		private void btnClickCashback(object sender, RoutedEventArgs e)
		{
			Main.Content = new Cashback(nuvm);
		}
		private void btnClickMoneybox(object sender, RoutedEventArgs e)
		{
			Main.Content = new Moneybox(nuvm);
		}
		private void btnClickPersonalData(object sender, RoutedEventArgs e)
		{
			Main.Content = new PersonalData(nuvm);
			var structure = new BankStructure();
			structure.Add(new Client(1, nuvm.ClientName , nuvm.SurName, "dfdfdf", "VV", 2349959,"dfddd", nuvm.Email, nuvm.Phonenumber, "ffF", nuvm.Password, 0, 0)); 
			structure.Accept(new InfoVisitor());
		}
		private void btnCloseClick(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
