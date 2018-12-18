using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceApp
{
	// ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "CountService" в коде, SVC-файле и файле конфигурации.
	// ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы CountService.svc или CountService.svc.cs в обозревателе решений и начните отладку.
	public class CountService : ICountService
	{
		public int CalcCredit(int Duration, int Money, DateTime date)
		{
			DateTime dateTime = DateTime.Today;
			DateTime finalDate = date.AddMonths(Duration);
			TimeSpan time = finalDate - dateTime;
			if (time.Days == 0)
			{
				return Money;
			}
			else
			{
				return 0;
			}
		}

		public double CalcDeposit(int Duration, int Money, DateTime date)
		{
			List<int> dates = new List<int>() { };
			DateTime todayDate = DateTime.Today;
			DateTime finalDate = date.AddMonths(Duration);
			double sum = Money / Duration;
			if (!CheckDate(todayDate, finalDate))
			{
				for (int i = 1; i < SubstractDates(todayDate, finalDate); i++)
				{
					TimeSpan newTime = finalDate - date.AddMonths(i);
					dates.Add(newTime.Days);
				}
				foreach (int i in dates)
				{
					TimeSpan newTime = finalDate - todayDate;
					if (newTime.Days == i)
					{
						return sum;
					}
					return 0;
				}
			}
			return 0;
		}
		public static bool CheckDate(DateTime todayDate, DateTime finalDate)
		{
			if (todayDate == finalDate)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public static int SubstractDates( DateTime todayDate, DateTime finalDate)
		{
			int intReturn = 0;
			bool sameMonth = false;

			if (finalDate.Date < todayDate.Date) 
				intReturn--;

			int dayOfMonth = todayDate.Day;
			int daysinMonth = 0;

			while (finalDate.Date > todayDate.Date)
			{
				todayDate = todayDate.AddMonths(1);

				daysinMonth = DateTime.DaysInMonth(todayDate.Year, todayDate.Month);

				if (todayDate.Day != dayOfMonth)
				{
					if (daysinMonth < dayOfMonth) 
						todayDate.AddDays(daysinMonth - todayDate.Day);
					else
						todayDate.AddDays(dayOfMonth - todayDate.Day);
				}

				if (((finalDate.Year == todayDate.Year) && (finalDate.Month == todayDate.Month)))
				{
					if (todayDate.Day >= dayOfMonth)
						intReturn++;
					sameMonth = true; 
				}
				if ((!sameMonth) && (finalDate.Date > todayDate.Date))
					intReturn++;
			}

			return intReturn;
		}
		public static DateTime AddDateMonth(DateTime todayTime,int month)
		{
			DateTime date = todayTime.AddMonths(month);
			return date;
		}
	}
}
