using System;

namespace unirest
{
    public static class HttpRequestParameterHelper
    {
        public static string Handle(object param)
        {
            string typeName = param.GetType().Name;

            switch (typeName)
            {
                case "Int32":
                case "Int64":
                case "Double":
                case "numeric":
                    return param.ToString();
                case "DateTime":
                    return ((DateTime)param).ToString("yyy-MM-dd");
                case "DateTimeOffset":
                    return ((DateTimeOffset)param).ToString("yyyy-MM-ddTHH:mm:ss");
                case "String":
                default:
                    return param.ToString();
            }
        }
    }
}
