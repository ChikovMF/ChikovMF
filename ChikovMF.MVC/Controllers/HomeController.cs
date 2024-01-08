using ChikovMF.MVC.FormModels.Home;
using ChikovMF.MVC.Models;
using ChikovMF.WebApi.Services.EmailService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ChikovMF.MVC.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult SendingMessage([FromServices] IEmailSender emailSender, [FromForm] MessageMeFormModel form)
        {
            string content = @$"От кого: {form.Name} <br/>Сообщение: {form.Message} <br/>Контакты: {form.Contacts}";

            string[] emails = { "ia-matvey@mail.ru" };

            var message = new Message(emails, "Сообщение с сайта ChikovMF.", content);

            emailSender.SendEmailAsync(message);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/AccessDenied")]
        public IActionResult AccessDenied(string returnUrl)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true),
            Route("/Error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
