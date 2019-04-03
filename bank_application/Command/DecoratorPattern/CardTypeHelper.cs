namespace bank_application.Command.DecoratorPattern
{
	public class CardTypeHelper
	{
		private bool VisaType { get; set; }
		private bool MasterType { get; set; }
		private bool ElectronCat { get; set; }
		private bool ClassicCat { get; set; }
		private bool GoldCat { get; set; }
		private bool PlatinumCat { get; set; }
		private string CardType;

		public CardTypeHelper(bool visatype, bool mastertype, 
			bool electroncat, bool classiccat, bool goldcat, bool platinumcat)
		{
			this.VisaType = visatype;
			this.MasterType = mastertype;
			this.ElectronCat = electroncat;
			this.ClassicCat = classiccat;
			this.GoldCat = goldcat;
			this.PlatinumCat = platinumcat;
		}
		public string GetCardType()
		{
			ChooseType();
			return CardType;
		}
		public void ChooseType()
		{
			if (VisaType)
			{
				ComponentCardType cvtype = new VisaCard();
				ChooseCategory(cvtype);
			}
			else
			{
				ComponentCardType cmtype = new MasterCard();
				ChooseCategory(cmtype);
			}
		}
		private string ChooseCategory(ComponentCardType cctype)
		{
			if (ElectronCat)
			{
				cctype = new ElectronCardType(cctype);
			}
			else if (ClassicCat)
			{
				cctype = new ClassicCardType(cctype);
			}
			else if (GoldCat)
			{
				cctype = new GoldCardType(cctype);
			}
			else
			{
				cctype = new PlatinumCardType(cctype);
			}
			return CardType = cctype.GetInfo();
		}
	}
}
