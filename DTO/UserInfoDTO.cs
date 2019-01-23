using System;
using RA.SS.Wrapper.Enums;

namespace RA.SS.Wrapper.DTO
{
    public class UserInfoDTO
    {
        public string UserCountryAcronym { get; set; }

        public Currency Currency { get; set; }

        public string Locale { get; set; }
    }
}