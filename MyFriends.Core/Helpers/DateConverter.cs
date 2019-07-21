using System;

namespace MyFriends.Core
{
    public static class DateConverter
    {
        public static string ToDateFormat(this string str, string format)
        {
            var items = str.Split('-', 'T', ':');
            DateTime date;
            try
            {
                date = new DateTime(Convert.ToInt32(items[0]), Convert.ToInt32(items[1]),
                    Convert.ToInt32(items[2]), Convert.ToInt32(items[3]), Convert.ToInt32(items[4]),
                    Convert.ToInt32(items[5]));
            }
            catch (Exception)
            {
                throw new Exception("Format error");
            }
            return date.ToString(format);
        }
    }
}
