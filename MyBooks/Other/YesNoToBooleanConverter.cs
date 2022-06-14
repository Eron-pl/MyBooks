using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MyBooks.Other
{
	public class YesNoToBooleanConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is bool)
			{
				if ((bool)value == true)
					return "Tak";
				else
					return "Nie";
			}
			return "Nie";
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			switch (value.ToString().ToLower())
			{
				case "Tak":
					return true;
				case "Nie":
					return false;
			}
			return false;
		}
	}
}
