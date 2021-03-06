﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace RecipesPosts.Converters
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTimeOffset dateTime = (DateTimeOffset)value;
            DateTimeOffset rightNow = DateTimeOffset.Now;
            var difference = rightNow - dateTime;

            if (difference.TotalDays > 1)
                return $"{dateTime:d}";

            else
            {
                if (difference.TotalSeconds < 60)
                    return $"{ difference.TotalSeconds}seconds ago";
                if (difference.TotalMinutes < 60)
                    return $"{difference.TotalMinutes}minutes ago";
                if (difference.TotalHours < 24)
                    return $"{ difference.TotalHours}hours ago";

                return "yesterday";
            }              
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DateTimeOffset.Now;
        }
    }
}
