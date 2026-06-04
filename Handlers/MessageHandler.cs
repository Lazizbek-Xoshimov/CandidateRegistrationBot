using System.Security.Authentication;
using CandidateRegistrationBot.Models;
using CandidateRegistrationBot.Services.Candidates;
using Telegram.Bot;
using Telegram.Bot.Extensions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace CandidateRegistrationBot.Handlers;

public class MessageHandler
{
    private readonly ITelegramBotClient _telegramBotClient;
    ICandidateService candidateService = new CandidateService();
    CandidateStep candidateStep = new CandidateStep();

    public MessageHandler(ITelegramBotClient bot)
    {
        _telegramBotClient = bot;
    }

    public async Task OnMessage(Message message, UpdateType type)
    {
        Candidate candidate = new Candidate();
        candidate.CandidateId = Guid.NewGuid();

        if (candidateStep.currentStep == CurrentStep.WaitingForCourse)
        {
            await _telegramBotClient.SendMessage(message.Chat, "Ma'lumotlaringiz qo'shildi.");
        }

        if (candidateStep.currentStep == CurrentStep.WaitingForPhoneNumber)
        {
            candidate.PhoneNumber = message.Text;

            await _telegramBotClient.SendMessage(message.Chat, "Qaysi kursga qatnashmoqchisiz: ");
            candidateStep.currentStep = CurrentStep.WaitingForCourse;
        }

        if (candidateStep.currentStep == CurrentStep.WaitingForAge)
        {
            candidate.Age = int.Parse(message.Text);

            await _telegramBotClient.SendMessage(message.Chat, "Telefon raqamingizni kiriting: ");
            candidateStep.currentStep = CurrentStep.WaitingForPhoneNumber;
        }

        if (candidateStep.currentStep == CurrentStep.WaitingForName)
        {
            candidate.Name = message.Text;

            await _telegramBotClient.SendMessage(message.Chat, "Yoshingizni kiriting: ");
            candidateStep.currentStep = CurrentStep.WaitingForAge;
        }

        if (message.Text.Equals("/start"))
        {
            Console.WriteLine($"Start clicking is {message.Chat.FirstName}");

            await _telegramBotClient.SendMessage(message.Chat, "Kerakli manbalarni olish uchun iltimos oldin ro'yxatdan o'ting");
            await _telegramBotClient.SendMessage(message.Chat, "Ismingizni kiriting: ");
            candidateStep.currentStep = CurrentStep.WaitingForName;
        }

        Console.WriteLine($"{candidate.Name}\n{candidate.Age}\n{candidate.PhoneNumber}\n{candidate.Course}");
    }
}