using AutoBusTestTask.Interfaces;
using AutoBusTestTask.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AutoBusTestTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUrlRepository repository;
        public HomeController(ILogger<HomeController> logger, IUrlRepository repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var urls = await repository.GetUrlListAsync();
            return View(urls);
        }

        public ActionResult CreateUrlView()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateUrlView(IFormCollection collection)
        {
            try
            {
                var id = Guid.NewGuid();

                var url = new Url
                {
                    Id = id,
                    OriginalUrl = collection["OriginalUrl"],
                    ShortUrl = "https://localhost:7100/" + id.ToString().Substring(0, 5),
                    CreationDate = DateTime.Now.Date,
                    RedirectCount = 0
                };
                await repository.CreateUrlAsync(url);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> RedirectToOriginalUrl(string shortUrl)
        {
            try
            {
                var redirectEntity = await repository.GetUrlAsync(shortUrl);
                redirectEntity.RedirectCount++;
                await repository.UpdateUrlAsync(redirectEntity);
                return Redirect(redirectEntity.OriginalUrl);
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> RedirectToOriginalUrlThrowTable(string shortUrl)
        {
            try
            {
                var redirectEntity = await repository.GetUrlAsyncThrowTable(shortUrl);
                redirectEntity.RedirectCount++;
                await repository.UpdateUrlAsync(redirectEntity);

                return Redirect(redirectEntity.OriginalUrl);
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> EditUrlView(Guid id)
        {
            var redirectEntity = await repository.GetUrlAsync(id);
            return View(redirectEntity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditUrlView(Guid id, IFormCollection collection)
        {
            try
            {
                var entity = await repository.GetUrlAsync(id);
                entity.OriginalUrl = collection["OriginalUrl"];
                entity.ShortUrl = collection["ShortUrl"];
                entity.CreationDate = Convert.ToDateTime(collection["CreationDate"]).Date;
                entity.RedirectCount = Convert.ToInt32(collection["RedirectCount"]);
                await repository.UpdateUrlAsync(entity);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> DeleteUrlView(Guid id)
        {
            var redirectEntity = await repository.GetUrlAsync(id);
            return View(redirectEntity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteUrlView(Guid id, IFormCollection collection)
        {
            try
            {
                var url = await repository.GetUrlAsync(id);
                repository.DeleteUrl(url);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}