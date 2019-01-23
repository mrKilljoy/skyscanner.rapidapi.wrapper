using System;
using RA.SS.Wrapper.Enums;

namespace RA.SS.Wrapper.DTO
{
    public class QueryResponseDTO
    {
        public string Country { get; set; }

        public Currency Currency { get; set; }

        public string Locale { get; set; }

        public int Adults { get; set; }

        public int Children { get; set; }

        public int Infants { get; set; }

        public string OriginPlace { get; set; }

        public string DestinationPlace { get; set; }

        public DateTime OutboundDate { get; set; }

        public string LocationSchema { get; set; }

        public string CabinClass { get; set; }

        public bool GroupPricing { get; set; }
    }
}
