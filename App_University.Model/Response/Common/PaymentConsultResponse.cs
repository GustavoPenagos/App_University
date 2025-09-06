using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App_University.Model.Response.Common
{
    public class PaymentConsultResponse
    {
        [JsonPropertyName("program")]
        public string? Program { get; set; }
        [JsonPropertyName("term_code")]
        public string? Term_code { get; set; }
        [JsonPropertyName("pagaron")]
        public int Pagaron { get; set; }
        [JsonPropertyName("no_pagaron")]
        public int No_pagaron { get; set; }
    }
}
