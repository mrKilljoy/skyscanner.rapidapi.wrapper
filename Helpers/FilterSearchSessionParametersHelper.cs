using System;
using System.Linq;
using System.Reflection;
using RA.SS.Wrapper.DTO;

namespace RA.SS.Wrapper.Helpers
{
    public class FilterSearchSessionParametersHelper
    {
        public static string BuildUrlParametersList(FilterSearchSessionDTO dto)
        {
            var propertiesList = dto
                    .GetType()
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.GetValue(dto) != null);

            var propertyFormattingFunc = 
                new Func<PropertyInfo, string>((pi) => $"{pi.Name}={HttpRequestParameterHelper.Parse(pi.GetValue(dto))}");

            return string.Join('&', propertiesList.Select(propertyFormattingFunc));
        }
    }
}
