﻿using System;

namespace unirest.DTO
{
    public class SegmentResponseDTO
    {
        public int Id { get; set; }

        public int OriginStation { get; set; }

        public int DestinationStation { get; set; }

        public DateTimeOffset DepartureDateTime { get; set; }

        public DateTimeOffset ArrivalDateTime { get; set; }

        public int Carrier { get; set; }

        public int OperatingCarrier { get; set; }

        public int Duration { get; set; }

        public string FlightNumber { get; set; }

        public string JourneyMode { get; set; }

        public string Directionality { get; set; }
    }
}
