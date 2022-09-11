using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
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
            //var room =  chatDBContext.Rooms.Include("Participant").Where(c=> c.Participants. ToList();

            ////var room = chatDBContext.Rooms.Join(chatDBContext.Participants,
            ////                                    c=>c.
            ////                                    )
            ///
            var room = (from rooms in chatDBContext.Rooms
                       join c in chatDBContext.Participants on rooms.Id equals c.RoomId
                       where EF.Functions.Like(c.UserId, HttpContext.Session.GetString("UserId"))
                       select rooms).Include(x=>x.Participants).ThenInclude(x=>x.User);

            return View(room);
        }

    }
}
