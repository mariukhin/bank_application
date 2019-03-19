namespace bank_application.Command
{
	class Context
	{
		private ICardNumberGenerator _gen;

		public Context()
		{ }
		public Context(ICardNumberGenerator gen)
		{
			this._gen = gen;
		}

		public void SetGenerator(ICardNumberGenerator gen)
		{
			this._gen = gen;
		}

		public string DoSomeBusinessLogic()
		{
			string result = this._gen.DoAlgorythm();
			return result;
		}
	}
}
