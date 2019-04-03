namespace bank_application.Command.DecoratorPattern
{
	class VisaCard : ComponentCardType
	{
		public VisaCard() : base("Visa", 0)
		{ }
		public override string GetInfo()
		{
			return "Visa";
		}
	}
}
