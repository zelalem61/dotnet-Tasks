using BlogApplication.Entities;
using BlogApplication.Context;


namespace BlogApplication.Services;
public class BlogManager {
    private BlogContext _context;
    private PostManager _postManager {get; set;}
    private CommentManager _commentManager {get; set;}

    public BlogManager(BlogContext context){
        _context = context;
        _postManager = new PostManager(context);
        _commentManager = new CommentManager(context);
    }

    public bool DisplayPosts(){
        List<Post> posts =  _postManager.GetAllPosts();
        foreach (Post post in posts){
            Formater.FormatPost(post);
        }
        return true;

    }

    public bool DisplayPostDetail(int postId){
        Post? post = _postManager.GetPostById(postId);
        if (post == null) {
            Formater.FormatError("Post not found!!!");
            return false;
        };
        List<Comment> coments = _commentManager.GetAllComments(post.Id);
        Formater.FormatPostDetil(post);
        foreach (Comment comment in coments){
            Formater.FormatComment(comment);
        }
        return true;
    }

    public bool CreatePost(string title, string content){
        _postManager.CreatePost(
            new Post{
                Title = title,
                Content = content,
            }
        );
        return true;
    }

    public bool UpdatePost(int id, string title, string content){
        Post? post = _postManager.GetPostById(id);
        if (post == null) {
            Formater.FormatError("Post not found!!!");
            return false;
        }
        _postManager.UpdatePost(
            new Post{
                Id = id,
                Title = title.Length == 0 ? post.Title : title,
                Content = content.Length == 0 ? post.Content : content,
            }
        );
        return true;
    }

    public bool DeletePost(int id){
        Post? post = _postManager.GetPostById(id);
        if (post == null){
            Formater.FormatError("Post not found!!!");
            return false;
        };
        _postManager.DeletePost(id);
        return true;
    }

    public bool CreateComment(int postId, string text){
        Post? post = _postManager.GetPostById(postId);
        if (post == null){
            Formater.FormatError("Post not found!!!");
            return false;
        };

        _commentManager.CreateComment(
            new Comment{
                PostId = postId,
                Text = text,
            }
        );
        return true;
    }

    public bool UpdateComment(int id, int postId, string text){
        Comment? comment = _commentManager.GetCommentById(id);
        if (comment == null) {
            Formater.FormatError("Comment not found!!!");
            return false;
        }; 
        _commentManager.UpdateComment(
            new Comment{
                Id = id,
                PostId = postId,
                Text = text
            }
        );
        return true;
    }

    public bool DeleteComment(int id){
        Comment? comment = _commentManager.GetCommentById(id);
        if (comment == null) {
            Formater.FormatError("Comment not found!!!");
            return false;
        };
        if (comment == null) return false;
        _commentManager.DeleteComment(id);
        return true;
    }

}