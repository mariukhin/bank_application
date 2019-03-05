using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_application.Command
{
	class FirstAlgorythm : ICardNumberGenerator
	{
		public string DoAlgorythm()
		{
			int[] checkArray = new int[15];
			Random _random = new Random();
			var cardNum = new int[16];

			for (int d = 14; d >= 0; d--)
			{
				cardNum[d] = _random.Next(0, 9);
				checkArray[d] = (cardNum[d] * (((d + 1) % 2) + 1)) % 9;
			}

			cardNum[15] = (checkArray.Sum() * 9) % 10;

			var sb = new StringBuilder();

			for (int d = 0; d < 16; d++)
			{
				sb.Append(cardNum[d].ToString(CultureInfo.CurrentCulture));
			}
			return sb.ToString();
		}
	}
}
