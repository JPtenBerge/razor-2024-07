using DemoShared.Entities;
using Microsoft.AspNetCore.SignalR.Client;

namespace DemoBlazor.Pages;

public partial class PollPage
{
    public Poll? ActivePoll { get; set; }

    public Poll NewPoll { get; set; } = new();

    private HubConnection _connection = default!;

    protected override async Task OnInitializedAsync()
    {
        _connection = new HubConnectionBuilder()
            .WithUrl("https://localhost:7054/pollHub")
            .ConfigureLogging(options => options.SetMinimumLevel(LogLevel.Warning))
            .Build();
        _connection.On("init", (Poll poll) =>
        {
            ActivePoll = poll;
            StateHasChanged();
        });
        _connection.On("vote", () =>
        {

        });
        await _connection.StartAsync();
    }


    public async Task InitPoll()
    {
        await _connection.SendAsync("InitPoll", NewPoll);
    }
}
