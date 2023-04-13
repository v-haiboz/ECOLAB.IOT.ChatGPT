using ECOLAB.IOT.ChatGPT.Models;
using ECOLAB.IOT.ChatGPT.Service;
using Microsoft.AspNetCore.Mvc;

namespace ECOLAB.IOT.ChatGPT.Controllers
{
    public class ChatGPTController : Controller
    {

        private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IELinkService _eLinkService;
        public ChatGPTController(IELinkService eLinkService)

        {
            _eLinkService = eLinkService;
        }
        // GET: ChatGPTController
        public ActionResult Index()
        {
            ViewBag.QuestionerImgIndex = Random.Shared.Next(1,4);
            return View();
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
