using System.ComponentModel.DataAnnotations;

namespace Test_task.Dtos
{
    public record class CreateAndUpdateCandidateDto(
        [Required]
        string FirstName,
        [Required]
        string LastName,
        string PhoneNumber,
        [Required]
        string Email,
        string PreferredCallTimeInterval,
        string LinkedInProfileUrl,
        string GitHubProfileUrl,
        [Required]
        string Comment
    );
}
