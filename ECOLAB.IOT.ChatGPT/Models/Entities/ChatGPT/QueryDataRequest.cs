using System.Text.Json.Serialization;

namespace ECOLAB.IOT.ChatGPT.Models.Entities.ChatGPT
{
    public class QueryDataRequest:ChatGPTRequest
    {
        [JsonPropertyName("text")]
        public string? Text { get; set; }
    }
}
