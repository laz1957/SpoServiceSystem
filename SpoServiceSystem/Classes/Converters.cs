using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace SpoServiceSystem.Classes
{
    public class RowStateToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                switch ((DataRowState)value)
                {
                    case DataRowState.Detached:
                        return Brushes.Red;
                    case DataRowState.Unchanged:
                        return Brushes.White;
                    case DataRowState.Added:
                        return Brushes.Yellow;
                    case DataRowState.Deleted:
                        return Brushes.Pink;
                    case DataRowState.Modified:
                        return Brushes.LightPink;
                    default:
                        return Brushes.White;
                }
            }
            return Brushes.White;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
          new NotImplementedException();
    }


    public class IntegerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            long d;
            if (value.GetType().ToString()=="System.DBNull") 
                 d=0;
            else 
                d = long.Parse(value.ToString());
          //  if (double.IsNaN(d))
            //    return string.Empty;
            if(d==0) return string.Empty;
            
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class FloatConverter :IValueConverter
    { 
       public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            float d;
            if (value.GetType().ToString()=="System.DBNull")
                d=0;
            else
                d = float.Parse(value.ToString());
            //  if (double.IsNaN(d))
            //    return string.Empty;
            if (d==0) return string.Empty;

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}  

