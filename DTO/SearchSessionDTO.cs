using System;
using RA.SS.Wrapper.Enums;

namespace RA.SS.Wrapper.DTO
{
    public class SearchSessionDTO
    {
        #region required parameters
        public CountryCode Country { get; set; }

        public Currency Currency { get; set; }

        public string Locale { get; set; }

        public string OriginPlace { get; set; }

        public string DestinationPlace { get; set; }

        public DateTime OutboundDate { get; set; }

        public int Adults { get; set; }
        #endregion

        #region optional parameters
        public DateTime? InboundDate { get; set; }

        public CabinClass? CabinClass { get; set; }

        public int? Children { get; set; }

        public int? Infants { get; set; }

        public string IncludeCarriers { get; set; }

        public string ExcludeCarriers { get; set; }

        public bool? GroupPricing { get; set; }
        #endregion
    }
}