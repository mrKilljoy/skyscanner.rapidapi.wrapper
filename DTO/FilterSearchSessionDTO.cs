using System;
using System.ComponentModel.DataAnnotations;
using RA.SS.Wrapper.Enums;

namespace RA.SS.Wrapper.DTO
{
    public class FilterSearchSessionDTO
    {
        public SortType? SortType { get; set; }

        public SortOrder? SortOrder { get; set; }

        [Range(0, 1800)]
        public int? Duration { get; set; }

        public string[] IncludeCarriers { get; set; }

        public string[] ExcludeCarriers { get; set; }

        public string[] OriginAirports { get; set; }

        public string[] DestinationAirports { get; set; }
        
        public string[] Stops { get; set; }

        public DateTimeOffset? OutboundDepartTime { get; set; }

        public DateTimeOffset? OutboundDepartStartTime { get; set; }

        public DateTimeOffset? OutboundDepartEndTime { get; set; }

        public DateTimeOffset? OutboundArriveStartTime { get; set; }

        public DateTimeOffset? OutboundArriveEndTime { get; set; }

        public DateTimeOffset? InboundDepartTime { get; set; }

        public DateTimeOffset? InboundDepartStartTime { get; set; }

        public DateTimeOffset? InboundDepartEndTime { get; set; }

        public DateTimeOffset? InboundArriveStartTime { get; set; }

        public DateTimeOffset? InboundArriveEndTime { get; set; }

        public int PageIndex { get; set; } = 0;

        public int PageSize { get; set; } = 10;
    }
}
