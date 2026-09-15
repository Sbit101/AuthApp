using AuthApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;


namespace AuthApp.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {

        private readonly UserManager<ApplicationUser> _userManager;

        public ChatHub(UserManager<ApplicationUser> userManager) 
        {
            _userManager = userManager;

        }


        // public async Task SendAll(string message)
        // {
        //    if(!string.IsNullOrEmpty(message.Trim()))
        //    {
        //        await Clients.All.SendAsync("newMessage", message);
        //        await Clients.Caller.SendAsync("newMessage", message);
        //    }

        //}


        public async Task Send(string nameuser, string message) //string imgstring, 
        {
            //string name = _userManager.GetUserAsync(User).Result.FirstName.ToString();

            //Call the broadcastMessage method to update clients.
            await Clients.All.SendAsync("broadcastMessage",nameuser, message); // imgstring,
        }

    }
}
