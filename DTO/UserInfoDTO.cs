using System;
using unirest.Enums;

namespace unirest.DTO
{
    public class UserInfoDTO
    {
        public string UserCountryAcronym { get; set; }

        public Currency Currency { get; set; }

        public string Locale { get; set; }
    }
}