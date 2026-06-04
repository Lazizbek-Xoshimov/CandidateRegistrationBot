using CandidateRegistrationBot.Models;

namespace CandidateRegistrationBot.Services.Candidates;

public interface ICandidateService
{
    public bool CreateCandidate(Candidate candidate);
}