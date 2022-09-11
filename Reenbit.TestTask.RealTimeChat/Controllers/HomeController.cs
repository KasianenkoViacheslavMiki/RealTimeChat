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
            message.DeleteForUser = false;
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

        [HttpPost]
        public async Task<IActionResult> EditMessage(Message message)
        {
            var updateMessage = _chatDBContext.Messages.FirstOrDefault(x => x.Id == message.Id);
            updateMessage.TextMessage=message.TextMessage;
            _chatDBContext.Update(updateMessage);
            await _chatDBContext.SaveChangesAsync();
            await _hubContext.Clients.Groups(updateMessage.RoomId.ToString()).SendAsync("EditMessage",message.Id,message.TextMessage);
            return Ok(message); 
        }
        [HttpPost]
        public async Task<IActionResult> DeleteForUser(Message message)
        {
            var updateMessage = _chatDBContext.Messages.FirstOrDefault(x => x.Id == message.Id);
            updateMessage.DeleteForUser = true;
            _chatDBContext.Update(updateMessage);
            await _chatDBContext.SaveChangesAsync();
            return Ok(message);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteForAll(Message message)
        {
            var deleteMessage = _chatDBContext.Messages.FirstOrDefault(x => x.Id == message.Id);
            await _hubContext.Clients.Groups(deleteMessage.RoomId.ToString()).SendAsync("EditMessage", message.Id, message.TextMessage);
            _chatDBContext.Messages.Remove(deleteMessage);
            await _chatDBContext.SaveChangesAsync();
            return Ok(message);
        }
    }
}