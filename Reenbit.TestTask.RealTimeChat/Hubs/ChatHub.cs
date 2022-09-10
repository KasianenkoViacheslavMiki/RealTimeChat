using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Reenbit.TestTask.RealTimeChat.Models;

namespace Reenbit.TestTask.RealTimeChat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessageServer(string user,string TextMessage/*, int RoomId, int UserId*/ )
        {
           await Clients.All.SendAsync("ReceiveMessage", user , TextMessage/*,RoomId, UserId*/);
        }
        public async Task LoadMessages(int idRoom)
        {
            await Clients.All.SendAsync("LoadMessages", idRoom);
        }
 
        public Task joinRoom(string RoomID)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, RoomID);
        }

        public Task leaveRoom(string RoomID)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, RoomID);
        }
    }
}
