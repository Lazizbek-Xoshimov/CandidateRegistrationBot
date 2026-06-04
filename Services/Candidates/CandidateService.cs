using CandidateRegistrationBot.Models;

namespace CandidateRegistrationBot.Services.Candidates;

public class CandidateService : ICandidateService
{
    private List<Candidate> candidates = new List<Candidate>();

    public bool CreateCandidate(Candidate candidate)
    {
        candidates.Add(candidate);
        return true;
    }
}