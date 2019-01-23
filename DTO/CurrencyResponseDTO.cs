namespace RA.SS.Wrapper.DTO
{
    public class CurrencyResponseDTO
    {
        public string Code { get; set; }

        public string Symbol { get; set; }

        public string ThousandsSeparator { get; set; }

        public string DecimalSeparator { get; set; }

        public bool SymbolOnLeft { get; set; }

        public bool SpaceBetweenAmountAndSymbol { get; set; }

        public int RoundingCoefficient { get; set; }

        public int DecimalDigits { get; set; }
    }
}
