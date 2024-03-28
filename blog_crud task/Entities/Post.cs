using System.ComponentModel.DataAnnotations;

namespace  BlogApp.Entities;
public class Post {

    public Post() {
        Comments = new HashSet<Comment>();
    }
    [Key]    
    public int Id { get; init; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public DateTime CreatedAt { get; init; }
    public virtual ICollection<Comment> Comments { get; set; }
}