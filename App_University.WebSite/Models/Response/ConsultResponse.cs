using System.Text.Json.Serialization;

namespace App_University.WebSite.Models.Response
{
    public class ConsultResponse
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
