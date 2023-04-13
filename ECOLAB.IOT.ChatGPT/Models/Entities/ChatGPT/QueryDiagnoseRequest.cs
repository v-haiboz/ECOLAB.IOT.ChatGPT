namespace ECOLAB.IOT.ChatGPT.Models.Entities.ChatGPT
{
    public class QueryDiagnoseRequest: ChatGPTRequest
    {
        public string? Data { get; set; }
        public string? Query { get; set; }
    }
}
