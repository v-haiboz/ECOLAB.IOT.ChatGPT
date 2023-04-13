using ECOLAB.IOT.ChatGPT.Models;
using ECOLAB.IOT.ChatGPT.Service;
using Microsoft.AspNetCore.Mvc;

namespace ECOLAB.IOT.ChatGPT.Controllers
{
    public class ChatGPTAPIController : ControllerBase
    {
        private readonly IELinkService _eLinkService;
        public ChatGPTAPIController(IELinkService eLinkService)

        {
            _eLinkService = eLinkService;
        }

        private static readonly string[] Summaries = new[]
        {
           "Nah, 洗碗机的事情问CHENKAI & ESON. IOT的所有的事情问XUDONG. 软件问题ZHANG YING & ZHANG JIAN & yichang 测试问题找peiguo & wang huai 如果真的不行，试试找一下ziwei.",
           "不要去投诉哦，我可以解决所有的难题，强行投诉，不讲武德的话，我就要人肉你.",
           "这个问题让我想想.",
           "其实我无所不能，只是这个问题有点。。。",
           "请注意范围，不要超出范围。",
           "不要引诱我哦，我懂得。。。",
           "检查一下你自己的问题，说不定就发现了问题了。",
           "让我休息休息一下吧，很累的"
        };

        [HttpPost(Name = "Chat")]
        public async Task<WeatherForecast> Chat(ChatMessage chatMessage)
        {
            var summary = Summaries[Random.Shared.Next(Summaries.Length)];
            
            if(chatMessage != null && !string.IsNullOrEmpty(chatMessage.Content) && chatMessage.Content.ToLower().Contains("DMC".ToLower()))
            {
                var result = await _eLinkService.QueryDiagnose(chatMessage.Content);
                if (!string.IsNullOrEmpty(result))
                {
                    summary = result;
                }
            }

            return new WeatherForecast
            {
                Date = DateTime.Now.AddDays(1),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summary
            };
        }
    }
}
