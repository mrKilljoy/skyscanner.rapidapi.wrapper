using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RA.SS.Wrapper.DTO;

namespace RA.SS.Wrapper
{
    /// <summary>
    /// A module designed to retrieve information about airports and to search flights.
    /// Hardcoded to work with RapidAPI settings only.
    /// </summary>
    public static class FlightSearchManager
    {
        public static string CreateSearchSessionKey(SearchSessionDTO dto)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(Constants.HeaderApiKeyName, Constants.HeaderApiKeyValue);

                var dict = new Dictionary<string, string>
                {
                    {"adults", dto.Adults.ToString()},
                    {"outboundDate", dto.OutboundDate.ToString("yyyy-MM-dd")},
                    {"originPlace", dto.OriginPlace},
                    {"destinationPlace", dto.DestinationPlace},
                    {"currency", dto.Currency.ToString()},
                    {"locale", dto.Locale},
                    {"country", dto.Country}
                };

                var content = new FormUrlEncodedContent(dict);
                var response = client.PostAsync(Constants.ApiPricingString, content)
                    .GetAwaiter()
                    .GetResult();

                if (response.StatusCode != HttpStatusCode.Created)
                {
                    throw new HttpRequestException($"request error: '{response.ReasonPhrase}' (code: {response.StatusCode})");
                }

                string locationHeaderValue = response.Headers.GetValues("location").First();
                string sessionKey = new Uri(locationHeaderValue).Segments.Last();

                return sessionKey;
            }
        }

        public static FilterSearchResponseDTO PollSearchSession(string sessionKey, FilterSearchSessionDTO dto)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(Constants.HeaderApiKeyName, Constants.HeaderApiKeyValue);

                var propertiesList = dto
                    .GetType()
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.GetValue(dto) != null);

                string requestParameters = string.Join('&', 
                    propertiesList.Select(p => $"{p.Name}={HttpRequestParameterHelper.Parse(p.GetValue(dto))}"));

                string url = $"{Constants.ApiPricing2String}/{sessionKey}?{requestParameters}";
                
                var response = client.GetAsync(url)
                    .GetAwaiter()
                    .GetResult();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new HttpRequestException($"request error: '{response.ReasonPhrase}' (code: {response.StatusCode})");
                }

                string rawResponse = response.Content.ReadAsStringAsync()
                    .GetAwaiter()
                    .GetResult();

                var responseDto = JsonConvert.DeserializeObject<FilterSearchResponseDTO>(rawResponse);

                return responseDto;
            }
        }

        public static IEnumerable<Place> GetPlaces(UserInfoDTO dto, string query)
        {
            using (var client = new HttpClient())
            {
                string url = $"{Constants.ApiSuggestingString}{dto.UserCountryAcronym}/" +
                    $"{dto.Currency.ToString()}" +
                    $"/{dto.Locale}/?query={query}";

                client.DefaultRequestHeaders.Add(Constants.HeaderApiKeyName, Constants.HeaderApiKeyValue);

                string response = client.GetStringAsync(url)
                    .GetAwaiter()
                    .GetResult();
                    
                var coreProperty = JObject.Parse(response);
                var data = coreProperty.Property("Places").Value.ToObject<IEnumerable<Place>>();

                return data;
            }
        }
    }
}