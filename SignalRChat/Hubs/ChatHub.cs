using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SignalRChat.Models;

namespace SignalRChat
{
    public class ChatHub : Hub
    {
        public void Send(String name, String message)
        {
            Clients.All.broadcastMessage(name, message);

            using (DatabaseEntities db = new DatabaseEntities())
            {
                Chat chat = new Chat()
                {
                    Name = name,
                    Message = message
                };

                db.Chats.Add(chat);
                db.SaveChanges();
            }
        }
    }
}