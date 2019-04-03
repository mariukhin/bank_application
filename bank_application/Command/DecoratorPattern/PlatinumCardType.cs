namespace bank_application.Command.DecoratorPattern
{
	class PlatinumCardType : CardDecorator
	{
		public PlatinumCardType(ComponentCardType comp) 
			: base(comp.Name + " Platinum", 2000, comp)
		{}
		public override string GetInfo()
		{
			return comp.GetInfo() + " Platinum";
		}
	}
}
