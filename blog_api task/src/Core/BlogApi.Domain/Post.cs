using BlogApi.Domain.Common;
namespace BlogApi.Domain;

public class Post : BaseDomainEntity
{
    public Post() {
        Comments = new HashSet<Comment>();
    }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required string AuthorName { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
}
