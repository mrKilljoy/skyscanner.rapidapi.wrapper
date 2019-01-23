namespace RA.SS.Wrapper.DTO
{
    public class FilterSearchResponseDTO
    {
        public string SessionKey { get; set; }

        public string Status { get; set; }

        public QueryResponseDTO Query { get; set; }

        public object[] Itineraries { get; set; }

        public object[] Legs { get; set; }

        public SegmentResponseDTO[] Segments { get; set; }

        public CarrierResponseDTO[] Carriers { get; set; }

        public AgentResponseDTO[] Agents { get; set; }

        public PlaceResponseDTO[] Places { get; set; }

        public CurrencyResponseDTO[] Currencies { get; set; }
    }
}
