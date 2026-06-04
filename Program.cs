using CandidateRegistrationBot;
using CandidateRegistrationBot.Handlers;
using Telegram.Bot;

namespace CandidateRegistrationBot;

public class Program
{

    public static async Task Main(string[] args)
    {
        using var cts = new CancellationTokenSource();
        var bot = new TelegramBotClient(BotToken.MyToken, cancellationToken: cts.Token);
        var me = await bot.GetMe();
        
        MessageHandler messageHandler = new MessageHandler(bot);
        UpdateHandler updateHandler = new UpdateHandler(messageHandler);
        ErrorHandler errorHandler = new ErrorHandler();

        bot.OnError += errorHandler.OnError;
        bot.OnMessage += messageHandler.OnMessage;
        bot.OnUpdate += updateHandler.OnUpdate;

        Console.WriteLine($"@{me.Username} is running... Press Enter to terminate");
        Console.ReadLine();

        cts.Cancel(); 
    }
}