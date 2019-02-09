using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RA.SS.Wrapper.DTO;
using RA.SS.Wrapper.Helpers;

namespace RA.SS.Wrapper
{
    /// <summary>
    /// A module designed to retrieve information about airports and to search flights.
    /// Hardcoded to work with RapidAPI settings only.
    /// </summary>
    public static class FlightSearchManager
    {
        public static async Task<string> CreateSearchSessionKey(SearchSessionDTO dto)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(Constants.HeaderApiKeyName, Constants.HeaderApiKeyValue);

                var @params = new Dictionary<string, string>
                {
                    {"adults", dto.Adults.ToString() },
                    {"outboundDate", dto.OutboundDate.ToString("yyyy-MM-dd") },
                    {"originPlace", dto.OriginPlace },
                    {"destinationPlace", dto.DestinationPlace },
                    {"currency", dto.Currency.ToString() },
                    {"locale", dto.Locale },
                    {"country", dto.Country.ToString() }
                };

                var content = new FormUrlEncodedContent(@params);
                var response = await client.PostAsync(Constants.ApiPricingString, content);

                if (response.StatusCode != HttpStatusCode.Created)
                {
                    throw new HttpRequestException($"request error: '{response.ReasonPhrase}' (code: {response.StatusCode})");
                }

                string locationHeaderValue = response.Headers.GetValues("location").First();
                string sessionKey = new Uri(locationHeaderValue).Segments.Last();

                return sessionKey;
            }
        }

        public static async Task<FilterSearchResponseDTO> PollSearchSession(string sessionKey, FilterSearchSessionDTO dto)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(Constants.HeaderApiKeyName, Constants.HeaderApiKeyValue);
                
                string requestParameters = FilterSearchSessionParametersHelper.BuildUrlParametersList(dto);
                string url = $"{Constants.ApiPricing2String}/{sessionKey}?{requestParameters}";

                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"request error: '{response.ReasonPhrase}' (code: {response.StatusCode})");
                }

                string rawResponse = await response.Content.ReadAsStringAsync();

                var responseDto = JsonConvert.DeserializeObject<FilterSearchResponseDTO>(rawResponse);

                return responseDto;
            }
        }

        public static async Task<IEnumerable<PlaceResponse>> GetPlaces(UserPreferencesDTO dto, string query)
        {
            using (var client = new HttpClient())
            {
                string url = $"{Constants.ApiSuggestingString}{dto.UserCountryAcronym}/" +
                    $"{dto.Currency.ToString()}" +
                    $"/{dto.Locale}/?query={query}";

                client.DefaultRequestHeaders.Add(Constants.HeaderApiKeyName, Constants.HeaderApiKeyValue);

                string response = await client.GetStringAsync(url);
                    
                var coreProperty = JObject.Parse(response);
                var data = coreProperty.Property("Places").Value.ToObject<IEnumerable<PlaceResponse>>();

                return data;
            }
        }
    }
}