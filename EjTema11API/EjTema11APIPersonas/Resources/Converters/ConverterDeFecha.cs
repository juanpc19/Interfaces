using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjTema11APIPersonas.Resources.Converters
{
    public class ConverterDeFecha : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string fechaCambiada="";

            if (value is DateTime fechaRecibida)
            {
               fechaCambiada = fechaRecibida.ToShortDateString();
            }

            return fechaCambiada;               

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime dateValue;

            if (DateTime.TryParse((string) value, out dateValue)) {

            }

            return dateValue;
        }
    }
}
