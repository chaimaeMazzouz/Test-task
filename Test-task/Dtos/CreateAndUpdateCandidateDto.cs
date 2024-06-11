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
        [EmailAddress]
        string Email,
        string PreferredCallTimeInterval,
        [Url]
        string LinkedInProfileUrl,
        [Url]
        string GitHubProfileUrl,
        [Required]
        string Comment
    );
}
