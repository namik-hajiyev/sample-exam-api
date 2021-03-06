namespace SampleExam.Infrastructure.Security
{
    public interface ICurrentUser
    {
        int UserId { get; set; }
        string Email { get; set; }
    }
    public interface ICurrentUserAccessor
    {
        int GetCurrentUserId();
        string GetCurrentUserEmail();
        ICurrentUser GetCurrentUser();
    }
}