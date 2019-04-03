namespace bank_application.Command.DecoratorPattern
{
	class MasterCard : ComponentCardType
	{
		public MasterCard() : base("MasterCard", 0)
		{}

		public override string GetInfo()
		{
			return "MasterCard";
		}
	}
}
