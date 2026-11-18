using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class DataValidation
    {
        public static T ValidateNum<T>(string input, T min, T max, string fieldName) where T : IComparable, IConvertible
        {
            T num;

            try
            {
                // Convert.ChangeType convierte a cualquier tipo numérico
                num = (T)Convert.ChangeType(input, typeof(T), CultureInfo.InvariantCulture);
            }
            catch
            {
                throw new FormatException($"Error in field name {fieldName}");
            }

            if (num.CompareTo(min) < 0)
            {
                throw new ArgumentOutOfRangeException(null, $"{fieldName} cannot be smaller than {min}.");
            }
            if (num.CompareTo(max) > 0)
            {
                throw new OverflowException($"{fieldName} cannot be larger than {max}.");
            }
            return num;
        }
    }
}
