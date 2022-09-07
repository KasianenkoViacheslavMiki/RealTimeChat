using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Reenbit.TestTask.RealTimeChat.Hubs;
using Reenbit.TestTask.RealTimeChat.Models;
//using Reenbit.TestTask.RealTimeChat.Models;
using System.Diagnostics;

namespace Reenbit.TestTask.RealTimeChat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ChatDBContext _chatDBContext;
        //private ChatDBContext db;
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        private readonly MessageRepository _messageRepository;
        private readonly IHubContext<ChatHub> _hubContext;

        public HomeController(MessageRepository messageRepository, IHubContext<ChatHub> hubContext, ChatDBContext context)
        {
            _messageRepository = messageRepository;
            _hubContext = hubContext;
            _chatDBContext = context;
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetMessagesChat()
        {
            var model =  _messageRepository.GetMessages(3);
            return Ok(model);
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Message message)
        {
            
            message.DateMessage = DateTime.Now;
            if (!ModelState.IsValid) return View(); 
            _chatDBContext.Add(message);
            await _chatDBContext.SaveChangesAsync();
            return View(message);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}