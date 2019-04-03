namespace bank_application.Command.DecoratorPattern
{
	abstract class CardDecorator : ComponentCardType
	{
		protected ComponentCardType comp;
		public CardDecorator(string name, int minamount, ComponentCardType comp) : base(name, minamount)
		{
			this.comp = comp;
		}
	}
}
