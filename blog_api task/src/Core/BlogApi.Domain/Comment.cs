using BlogApi.Domain.Common;
namespace BlogApi.Domain;



public class Comment : BaseDomainEntity
{
    public int PostId { get; init; }
    public required string Text { get; set; }
    public required string AuthorName { get; set; }
    public virtual Post? Post { get; set; }
}
