using System;
using RA.SS.Wrapper.Enums;
using RA.SS.Wrapper.DTO;

namespace RA.SS.Wrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var sdto = new SearchSessionDTO
            {
                Country = "RU",
                Currency = Currency.RUB,
                Locale = Locales.Russian,
                DestinationPlace = "STOC-sky",
                OriginPlace = "MOSC-sky",
                Adults = 1,
                OutboundDate = DateTime.Now.AddDays(3)
            };
            var x1 = DateTimeOffset.Now.ToString();
            var x2 = DateTimeOffset.Now.ToString("yyyy-MM-ddTHH:mm:ss");

            string key = FlightApiManager.CreateSearchSessionKey(sdto);

            var filterDto = new FilterSearchSessionDTO
            {
                OutboundDepartTime = DateTimeOffset.Parse("02.03.2019"),
                InboundDepartTime = DateTimeOffset.Parse("05.03.2019"),
                //Stops = new []{"0"},
                PageSize = 15
            };

            var searchPoll = FlightApiManager.PollSearchSession(key, filterDto);
        }
    }
}