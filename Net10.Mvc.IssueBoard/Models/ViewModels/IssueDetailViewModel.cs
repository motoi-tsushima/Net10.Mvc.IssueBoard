namespace Net10.Mvc.IssueBoard.Models.ViewModels;

public class IssueDetailViewModel
{
    public int Id { get; set; }
    public string AuthorName { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public string? Category { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public IssueStatus Status { get; set; }
    public string? Resolution { get; set; }
    public string? ResolverName { get; set; }
    public DateTime? ResolvedAt { get; set; }
}
