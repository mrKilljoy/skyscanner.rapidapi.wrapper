using System;
using RA.SS.Wrapper.Enums;

namespace RA.SS.Wrapper.DTO
{
    public class SearchSessionDTO
    {
        public string Country { get; set; }

        public Currency Currency { get; set; }

        public string Locale { get; set; }

        public string OriginPlace { get; set; }

        public string DestinationPlace { get; set; }

        public DateTime OutboundDate { get; set; }

        public int Adults { get; set; }
    }
}