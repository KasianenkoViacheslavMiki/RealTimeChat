using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Reenbit.TestTask.RealTimeChat.Hubs;
using Reenbit.TestTask.RealTimeChat.Models;
//using Reenbit.TestTask.RealTimeChat.Models;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Reenbit.TestTask.RealTimeChat.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;
        private readonly ChatDBContext _chatDBContext;
        private readonly DataRepository _dataRepository;
        private readonly IHubContext<ChatHub> _hubContext;
        
        public HomeController(
            ILogger<HomeController> logger,
            DataRepository messageRepository,
            IHubContext<ChatHub> hubContext,
            ChatDBContext context
            )
        {
            
            _logger = logger;
            _dataRepository = messageRepository;
            _hubContext = hubContext;
            _chatDBContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetMessagesRoomChat(int IdRoom)
        {
            return Ok(_dataRepository.GetChat(IdRoom));
        }
        [HttpGet("{Id}")]
        public IActionResult Chat(int id)
        {
            return View(_dataRepository.GetChat(id));
        }
        [HttpGet]
        //public async Task<IActionResult> JoinRoom(int id)
        //{
        //    await 
        //}
        [HttpPost]
        public async Task<IActionResult> SendMessage(Message message)
        {
            message.Id = Guid.NewGuid().ToString();
            message.DateMessage = DateTime.Now;
            message.UserId = _dataRepository.GetUserId();
            var userName = _dataRepository.GetUserName();
            await _hubContext.Clients.Groups(message.RoomId.ToString()).SendAsync("ReceiveMessage", message.Id, message.UserId, userName, message.TextMessage, message.DateMessage); //function (MessageId, MessagesUserID, UserName, MessageText, MessageDate)
            if (!ModelState.IsValid) return Ok();
            var result = _chatDBContext.Add(message);
            await _chatDBContext.SaveChangesAsync();
            return Ok(message);
        }
        [HttpPost]
        public async Task<IActionResult> GetUserId()
        {
            return Ok(_dataRepository.GetUserId());
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}