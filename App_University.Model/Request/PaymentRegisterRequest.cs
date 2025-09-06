using System.Text.Json.Serialization;


namespace App_University.Model.Request
{
    public  class PaymentRegisterRequest
    {
        [JsonPropertyName("Pidn")]
        public int Pidm { get; set; }
        [JsonPropertyName("Term_code")]
        public string? Term_code { get; set; }
        [JsonPropertyName("Program")]
        public string? Program { get; set; }
        [JsonPropertyName("Admr_code")]
        public string? Admr_code { get; set; }
        [JsonPropertyName("Recieve_date")]
        public string? Recieve_date { get; set; }
        [JsonPropertyName("Comment")]
        public string? Comment { get; set; }
    }
}
