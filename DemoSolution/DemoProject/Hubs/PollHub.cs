using DemoShared.Entities;
using Microsoft.AspNetCore.SignalR;

namespace DemoProject.Hubs;

public class PollHub : Hub
{
    public async Task InitPoll(Poll newPoll)
    {
        await Clients.All.SendAsync("init", newPoll);
    }
}
