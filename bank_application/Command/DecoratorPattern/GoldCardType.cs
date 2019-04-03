namespace bank_application.Command.DecoratorPattern
{
	class GoldCardType : CardDecorator
	{
		public GoldCardType(ComponentCardType comp) 
			: base(comp.Name + " Gold", 700, comp)
		{}
		public override string GetInfo()
		{
			return comp.GetInfo() + " Gold";
		}
	}
}
