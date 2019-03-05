using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_application.Command
{
	class SecondAlgorythm : ICardNumberGenerator
	{
		public string DoAlgorythm()
		{
			int[] checkArray = new int[15];
			Random _random = new Random();
			var cardNum = new int[16];

			var sb = new StringBuilder();

			for (int d = 0; d < 16; d++)
			{
				cardNum[d] = _random.Next(9);
			}
			for (int d = 0; d < 16; d++)
			{
				sb.Append(cardNum[d].ToString(CultureInfo.CurrentCulture));
			}
			return sb.ToString();
		}
	}
}
