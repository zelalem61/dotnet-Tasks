using BlogApplication.Context;
using BlogApplication.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApplication.Services;

public class CommentManager {
    private readonly BlogContext _context;
    public CommentManager(BlogContext context) {
        _context = context;
    }

    // Adds a comment to the post if the post doesnt exist it throws an error
    public Comment CreateComment(Comment comment) {
        _ = _context.Posts.Find(comment.PostId);
        _context.Comments.Add(comment);
        _context.SaveChanges();
        return comment;
    }

    //  Update a comment but if the comment doesnt exist throws an error
    public Comment UpdateComment(Comment UpdatedComment) {
        Comment old = GetCommentById(UpdatedComment.Id);
        old.Text = UpdatedComment.Text;
        _context.SaveChanges();
        return old;
    }

    //Removes a comment or throws an exception(using comment Id)
    public void DeleteComment(int id) {
        Comment comment = GetCommentById(id);
        _context.Comments.Remove(comment);
        _context.SaveChanges();
    }

    // Gets all the comment with the specified post if the post doesnt exist throws an exception
    public List<Comment> GetAllComments(int postId) {
        _ = _context.Posts.Find(postId);
        List<Comment> comments = _context.Comments.Where(c => c.PostId == postId).ToList();
        return comments;
    }

    //Usef for getting a single comment with specified id
    public Comment GetCommentById(int id) {
        Comment comment = _context.Comments.Find(id);
        return comment;
    }
}