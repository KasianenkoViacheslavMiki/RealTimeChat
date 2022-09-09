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
        private readonly MessageRepository _messageRepository;
        private readonly IHubContext<ChatHub> _hubContext;

        public HomeController(ILogger<HomeController> logger,MessageRepository messageRepository, IHubContext<ChatHub> hubContext, ChatDBContext context)
        {
            
            _logger = logger;
            _messageRepository = messageRepository;
            _hubContext = hubContext;
            _chatDBContext = context;
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetMessagesRoomChat(int IdRoom)
        {
            var model =  _messageRepository.GetMessages(IdRoom);
            return Ok(model);
        }
        [HttpGet]
        public IActionResult Chat(int id)
        {
            HttpContext.Session.SetString("UserName", "Miki");
            HttpContext.Session.SetString("UserId", "1");

            return View(_messageRepository.GetMessages(id));
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(Message message)
        {
            message.DateMessage = DateTime.Now;
            if (!ModelState.IsValid) return View();
            _chatDBContext.Add(message);
            await _chatDBContext.SaveChangesAsync();
            return Ok(message);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}