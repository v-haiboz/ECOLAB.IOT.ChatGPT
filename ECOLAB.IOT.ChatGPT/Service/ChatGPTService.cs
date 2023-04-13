namespace ECOLAB.IOT.ChatGPT.Service
{
    using ECOLAB.IOT.ChatGPT.Models.Entities.ChatGPT;
    using ECOLAB.IOT.ChatGPT.Provider;

    public interface IChatGPTService
    {
        public Task<ChatGPTResponse> QueryData(QueryDataRequest queryDataRequest);

        public Task<ChatGPTResponse> QueryDiagnose(QueryDiagnoseRequest queryDiagnoseRequest);
    }

    public class ChatGPTService : IChatGPTService
    {

        private readonly IElinkChatGPTProvider _elinkChatGPTProvider;
        public ChatGPTService(IElinkChatGPTProvider elinkChatGPTProvider)
        {
            _elinkChatGPTProvider = elinkChatGPTProvider;
        }

        public async Task<ChatGPTResponse> QueryData(QueryDataRequest queryDataRequest)
        {
            return await _elinkChatGPTProvider.QueryData(queryDataRequest);
        }

        public async Task<ChatGPTResponse> QueryDiagnose(QueryDiagnoseRequest queryDiagnoseRequest)
        {
            return await _elinkChatGPTProvider.QueryDiagnose(queryDiagnoseRequest);
        }
    }
}
