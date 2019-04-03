namespace bank_application.Command.DecoratorPattern
{
	class ClassicCardType : CardDecorator
	{
		public ClassicCardType(ComponentCardType comp) 
			: base(comp.Name + " Classic", 200, comp)
		{}

		public override string GetInfo()
		{
			return comp.GetInfo() + " Classic";
		}
	}
}
