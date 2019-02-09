using System;
using RA.SS.Wrapper.Enums;
using RA.SS.Wrapper.DTO;

namespace RA.SS.Wrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTestCases();
        }

        private static void RunTestCases()
        {
            var places = FlightSearchManager.GetPlaces(Constants.DefaultRussianUserInfo, "moscow")
                .GetAwaiter()
                .GetResult();

            var sdto = new SearchSessionDTO
            {
                Country = CountryCode.RU,
                Currency = Currency.RUB,
                Locale = Locales.Russian,
                DestinationPlace = "STOC-sky",
                OriginPlace = "MOSC-sky",
                Adults = 1,
                OutboundDate = DateTime.Now.AddDays(3)
            };

            string key = FlightSearchManager.CreateSearchSessionKey(sdto)
                .GetAwaiter()
                .GetResult();

            var filterDto = new FilterSearchSessionDTO
            {
                OutboundDepartTime = DateTimeOffset.Parse("02.03.2019"),
                InboundDepartTime = DateTimeOffset.Parse("05.03.2019"),
                //Stops = new []{"0"},
                PageSize = 15
            };

            var searchPoll = FlightSearchManager.PollSearchSession(key, filterDto);
        }
    }
}