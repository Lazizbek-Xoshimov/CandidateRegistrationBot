namespace CandidateRegistrationBot.Models;

public class CandidateStep
{
    public Guid CandidateId { get; set; }
    public CurrentStep currentStep { get; set; }
}

public enum CurrentStep
{
    WaitingForName,
    WaitingForAge,
    WaitingForPhoneNumber,
    WaitingForCourse
}