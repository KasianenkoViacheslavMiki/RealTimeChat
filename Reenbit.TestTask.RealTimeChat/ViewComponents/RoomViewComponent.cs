using Microsoft.AspNetCore.Mvc;
using Reenbit.TestTask.RealTimeChat.Models;

namespace Reenbit.TestTask.RealTimeChat.ViewComponents
{
    public class RoomViewComponent: ViewComponent
    {
        private readonly ChatDBContext chatDBContext;
        public RoomViewComponent(ChatDBContext _chatDBContext)
        {
            chatDBContext = _chatDBContext;
        }
        public IViewComponentResult Invoke() 
        {
            var room = chatDBContext.Rooms.ToList();
            return View(room);
        }

    }
}
