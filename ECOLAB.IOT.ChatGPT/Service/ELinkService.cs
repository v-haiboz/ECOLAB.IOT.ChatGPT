namespace ECOLAB.IOT.ChatGPT.Service
{
    using ECOLAB.IOT.ChatGPT.Common;
    using ECOLAB.IOT.ChatGPT.Models.Entities.ChatGPT;
    using ECOLAB.IOT.ChatGPT.Repository;

    public interface IELinkService
    {
        public Task<string> QueryData(string text);
        public Task<string> QueryDiagnose(string text);
    }

    public class ELinkService: IELinkService
    {
        private readonly IELinkRepository _elinkRepository;
        private readonly IChatGPTService _chatGPTService;
        public ELinkService(IELinkRepository eLinkRepository, IChatGPTService chatGPTService)
        {
            _elinkRepository = eLinkRepository;
            _chatGPTService = chatGPTService;
        }

        public async Task<string> QueryDiagnose(string text)
        {
            try
            {
                var result = await _chatGPTService.QueryData(new QueryDataRequest()
                {
                    Text = text
                });

                var data = _elinkRepository.GetListByDynamicSql(result.Text);
                var csv = data.DynamicToCSVString();

                var diagnose = await _chatGPTService.QueryDiagnose(new QueryDiagnoseRequest()
                {
                    Data = csv,
                    Query = text,
                });

                return diagnose.Text;

            }
            catch (Exception ex)
            {

                return null;
            }

        }

        public async Task<string> QueryData(string text)
        {
            try
            {
               var result=await _chatGPTService.QueryData(new QueryDataRequest()
                { 
                  Text = text
                });

                return result.Text;
                //var result = _elinkRepository.GetList();
                //return string.Join("  ", result.Select(x => x.ToString()).ToArray());
            }
            catch (Exception ex)
            {

                return null;
            }

        }
    }
    
}
