using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Reenbit.TestTask.RealTimeChat.Models
{
    public class DataRepository
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ChatDBContext _context;
        
        public DataRepository(ChatDBContext context, SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
            _context = context;
        }
        public Room GetChat(int roomId)
        {
            var result = _context.Rooms.Include(x => x.Messages).ThenInclude(x => x.User).Include(x => x.Participants).ThenInclude(x => x.User).FirstOrDefault(x => x.Id == roomId);
            if (result == null) return new Room();
            return result;
        }
        public string GetUserId() => _signInManager.Context.Session.GetString("UserId");
    }
}
