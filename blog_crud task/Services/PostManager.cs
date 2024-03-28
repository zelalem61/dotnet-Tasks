using BlogApp.Data;
using BlogApp.Entities;
using BlogApp.Validator;

namespace BlogApp.Services;

public class PostManager{

    private readonly ApiDbContext _context;

    public PostManager(ApiDbContext context){
        _context = context;
    }

    // Create a post
    public Post CreatePost(Post post){
        _context.Posts.Add(post);
        _context.SaveChanges();
        return post;
    }

    //Update a post using the id but throws exception if it doesnt exist
    public Post UpdatePost(Post UpdatedPost){
        Post old = GetPostById(UpdatedPost.Id) ?? throw new CustomException("Post not found");
        old.Title = UpdatedPost.Title;
        old.Content = UpdatedPost.Content;
        _context.SaveChanges();
        return old;
    }

    //Delete a post with id or throw exception
    public void DeletePost(int id){
        Post post = GetPostById(id) ?? throw new CustomException("Post not found");
        _context.Posts.Remove(post);
        _context.SaveChanges();
    }

    // get all the posts
    public List<Post> GetAllPosts(){
        return _context.Posts.ToList();
    }

    // get a post with id
    public Post GetPostById(int id){
        Post post = _context.Posts.Find(id) ?? throw new CustomException("Post not found");
        return post; 
    }
}