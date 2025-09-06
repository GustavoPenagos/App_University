namespace App_University.Transversal.Utils.Util
{
    public static class ValidData
    {
        public static bool IsValidDataRequest<T>(this T value)
        {
            foreach(var item in typeof(T).GetProperties())
            {
                var itemValue = item.GetValue(value);
                if (item.PropertyType == typeof(string))
                {
                    if(string.IsNullOrEmpty(itemValue as string))
                        return false;
                    
                }
                else if(item.PropertyType == typeof(int?) || item.PropertyType == typeof(int))
                {
                    if(itemValue as int? <= 0)
                        return false;
                }
                else if(item.PropertyType == typeof(DateTime?) || item.PropertyType == typeof(DateTime))
                {
                    if(!IsValidDate(itemValue as DateTime?))
                        return false;
                }
            }
            return true;
        }

        public static bool IsValidRequest<T>(this T value)
        {               
            if (typeof(T) == typeof(string))
            {
                if (string.IsNullOrEmpty(value as string))
                    return false;

            }
            else if (typeof(T) == typeof(int?))
            {
                if (value as int? <= 0)
                    return false;
            }
            else if (typeof(T) == typeof(DateTime?))
            {
                if (!IsValidDate(value as DateTime?))
                    return false;
            }
            
            return true;
        }

        private static bool IsValidInt(int? value)
        {
            return value.HasValue && value.Value > 0;
        }
        private static bool IsValidDate(DateTime? value)
        {
            return value.HasValue && value.Value != default;
        }
    }
}
