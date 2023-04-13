namespace ECOLAB.IOT.ChatGPT.Provider
{
    using ECOLAB.IOT.ChatGPT.Models.Entities.ChatGPT;
    using Flurl.Http;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public interface IElinkChatGPTProvider
    {
        public Task<ChatGPTResponse> QueryData(QueryDataRequest queryDataRequest);

        public Task<ChatGPTResponse> QueryDiagnose(QueryDiagnoseRequest queryDiagnoseRequest);
    }

    public class ElinkChatGPTProvider : IElinkChatGPTProvider
    {
        private static readonly string host = "http://172.176.248.126:8000/";
        private static readonly JsonSerializerSettings serializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
        public async Task<ChatGPTResponse> QueryData(QueryDataRequest queryDataRequest)
        {
            var url = $"{host}query_data";

            var result = await url.WithTimeout(60).PostJsonAsync(new
            {
                code = queryDataRequest.Code,
                text = queryDataRequest.Text
            }).ReceiveJson<ChatGPTResponse>();
            return result;
        }

        public async Task<ChatGPTResponse> QueryDiagnose(QueryDiagnoseRequest queryDiagnoseRequest)
        {
            var url = $"{host}query_diagnose";
            var result = await url.WithTimeout(60).PostJsonAsync(new
            {
                code = queryDiagnoseRequest.Code,
                query = queryDiagnoseRequest.Query,
                data = queryDiagnoseRequest.Data,
            }).ReceiveJson<ChatGPTResponse>();
            return result;
        }
    }
}
