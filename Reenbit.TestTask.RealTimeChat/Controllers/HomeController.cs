using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reenbit.TestTask.RealTimeChat.Models;
//using Reenbit.TestTask.RealTimeChat.Models;
using System.Diagnostics;

namespace Reenbit.TestTask.RealTimeChat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private ChatDBContext db;
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        private readonly MessageRepository _messageRepository;
        public HomeController(MessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Index()
        {
            var model = _messageRepository.GetMessages(3);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}