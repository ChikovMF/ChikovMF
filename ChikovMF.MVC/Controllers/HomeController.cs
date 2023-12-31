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
            string content = @$"�� ����: {form.Name} <br/>���������: {form.Message} <br/>��������: {form.Contacts}";

            string[] emails = { "ia-matvey@mail.ru" };

            var message = new Message(emails, "��������� � ����� ChikovMF.", content);

            emailSender.SendEmailAsync(message);

            return RedirectToAction("Index");
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
