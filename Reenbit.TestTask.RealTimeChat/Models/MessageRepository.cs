using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Reenbit.TestTask.RealTimeChat.Models
{
    public class MessageRepository
    {
        private readonly ChatDBContext _context;
        public MessageRepository(ChatDBContext context)
        {
            _context = context;
        }
        public Room GetChat(int roomId)
        {
            roomId = 3;
            var resul = _context.Rooms.Include(x => x.Messages).ThenInclude(x => x.User).Include(x=>x.Participants).FirstOrDefault(x => x.Id == roomId);
            return resul;
        }
    }
}
