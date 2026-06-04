using Telegram.Bot.Polling;

namespace CandidateRegistrationBot.Handlers;

public class ErrorHandler
{
    public async Task OnError(Exception exception, HandleErrorSource source)
    {
        Console.WriteLine($"Exception data: {exception.Data}");
        Console.WriteLine($"Error message: {exception.Message}");
        Console.WriteLine($"Error time: {DateTime.Now.TimeOfDay}");
    }
}