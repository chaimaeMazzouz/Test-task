using Test_task.Data;
using Test_task.Dtos;

namespace Test_task.Endpoints
{
    public static class CandidateEndpoints
    {
        public static void MapCandidatesEndpoints(this WebApplication app)
        {
            app.MapPost("/api/candidates", async (CreateAndUpdateCandidateDto candidateDto, CandidateBbContext dbContext) =>
            {
                if (string.IsNullOrEmpty(candidateDto.Email))
                {
                    return Results.BadRequest("Email is required.");
                }

                var candidate = new Entities.Candidate
                {
                    FirstName = candidateDto.FirstName,
                    LastName = candidateDto.LastName,
                    PhoneNumber = candidateDto.PhoneNumber,
                    Email = candidateDto.Email,
                    PreferredCallTimeInterval = candidateDto.PreferredCallTimeInterval,
                    LinkedInProfileUrl = candidateDto.LinkedInProfileUrl,
                    GitHubProfileUrl = candidateDto.GitHubProfileUrl,
                    Comment = candidateDto.Comment
                };

                dbContext.Candidates.Add(candidate);
                await dbContext.SaveChangesAsync();

                return Results.Ok(candidate);
            });

            app.MapPut("/api/candidates/{id}", async (int id, UpdateCandidateDto updateCandidateDto, CandidateBbContext dbContext) =>
            {
                var existingCandidate = await dbContext.Candidates.FindAsync(id);
                if (existingCandidate == null)
                {
                    return Results.NotFound();
                }

                existingCandidate.FirstName = updateCandidateDto.FirstName;
                existingCandidate.LastName = updateCandidateDto.LastName;
                existingCandidate.PhoneNumber = updateCandidateDto.PhoneNumber;
                existingCandidate.PreferredCallTimeInterval = updateCandidateDto.PreferredCallTimeInterval;
                existingCandidate.LinkedInProfileUrl = updateCandidateDto.LinkedInProfileUrl;
                existingCandidate.GitHubProfileUrl = updateCandidateDto.GitHubProfileUrl;
                existingCandidate.Comment = updateCandidateDto.Comment;

                await dbContext.SaveChangesAsync();

                return Results.Ok(existingCandidate);
            });
        }
    }
}
