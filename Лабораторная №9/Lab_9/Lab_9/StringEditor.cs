using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9
{
	class StringEditor
	{
		/* (+) Использование лямбда-функций */ 
		public static string AddSymbol(string str) => str += " <--- ";	/// добавление символа в строку

		public static string ToUpper(string str) => str.ToUpper();      /// замена букв на верхний регистр
		public static string ToLower(string str) => str.ToLower();      /// замена букв на нижний регистр

		public static string RemoveSpase(string str) => str.Replace(" ", string.Empty); /// удаление пробелов

		public static string RemoveS(string str)						///удаление знаков препинания
		{
			str = str.Replace(".", "");
			str = str.Replace(",", string.Empty);
			str = str.Replace(":", string.Empty);
			str = str.Replace(";", string.Empty);
			str = str.Replace("!", string.Empty);
			str = str.Replace("?", string.Empty);
			return str;
		}
	}
}
