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
        public IQueryable<Message> GetMessages(int roomId)
        {
            
            return _context.Messages.Where(x => x.RoomId == roomId).OrderBy(x => x.DateMessage).Include("User");




            //return _context.Messages.Where(x => x.RoomId == roomId).OrderBy(x => x.DateMessage);


            //
            //var users = (from Message in _context.Messages
            //             join User in _context.Users on Message.UserId equals User.Id
            //             join Room in _context.Rooms on Message.RoomId equals Room.Id
            //             select new
            //             {
            //                 Id = Message.Id,
            //                 UserId = Message.UserId,
            //                 RoomId = Message.RoomId,
            //                 TextMessage = Message.TextMessage,
            //                 DateMessage = Message.DateMessage,
            //                 UserName = User.UserName,
            //                 RoomName = Room.RoomName
            //             });
            // return users;
            //return _context.Messages.Join(_context.Users, u => u.UserId, x => x.Id, (u, x) => new
            //{
            //    Id = u.Id,
            //    UserId = u.UserId,
            //    RoomId = u.RoomId,
            //    TextMessage = u.TextMessage,
            //    DateMessage = u.DateMessage,
            //    UserName = x.UserName,
            //}).ToList<Message_LINQ>();
        }
    }
}
