using RA.SS.Wrapper.Enums;
using RA.SS.Wrapper.DTO;

namespace RA.SS.Wrapper
{
    internal static class Constants
    {
        public static UserPreferencesDTO DefaultRussianUserInfo => new UserPreferencesDTO
        {
            Currency = Currency.RUB,
            UserCountryAcronym = "RU",
            Locale = "ru"
        };

        public const string ApiPricingString = "https://skyscanner-skyscanner-flight-search-v1.p.rapidapi.com/apiservices/pricing/v1.0";

        public const string ApiPricing2String = "https://skyscanner-skyscanner-flight-search-v1.p.rapidapi.com/apiservices/pricing/uk2/v1.0";

        public const string ApiSuggestingString = "https://skyscanner-skyscanner-flight-search-v1.p.rapidapi.com/apiservices/autosuggest/v1.0/";

        public const string HeaderApiKeyName = "X-RapidAPI-Key";

        public const string HeaderApiKeyValue = "349ca8bc6emsh4668ad52bf8aa79p12d4b3jsnfa31f3222d2b";
    }

    internal static class Locales
    {
        public const string Russian = "ru";
        public const string British = "en-GB";
        public const string American = "en-US";
    }
}