using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace CandidateRegistrationBot.Handlers;

public class UpdateHandler
{
    public readonly MessageHandler _messageHandler;

    public UpdateHandler(MessageHandler messageHandler)
    {
        _messageHandler = messageHandler;
    }

    public async Task OnUpdate(Update update)
    {
        switch (update.Type)
        {
            case UpdateType.Message:
                {
                    if (update.Message is not null)
                    {
                        Console.WriteLine("Xabar keldi");
                    }
                    break;
                }
            case UpdateType.CallbackQuery:
                {
                    
                    Console.WriteLine("CallbackQuery received.");
                    break;
                }
            default:
                {
                    Console.WriteLine($"Unsupported update type: {update.Type}");
                    break;
                } 
        }
    }
}