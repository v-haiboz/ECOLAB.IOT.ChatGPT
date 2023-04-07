using ECOLAB.IOT.ChatGPT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECOLAB.IOT.ChatGPT.Controllers
{
    public class ChatGPTController : Controller
    {
        private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        // GET: ChatGPTController
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost(Name = "Chat")]
        public IEnumerable<WeatherForecast> Chat(ChatMessage chatMessage)
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        // GET: ChatGPTController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ChatGPTController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChatGPTController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ChatGPTController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ChatGPTController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ChatGPTController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ChatGPTController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
