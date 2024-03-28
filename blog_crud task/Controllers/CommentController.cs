using BlogApp.Data;
using BlogApp.Entities;
using BlogApp.Services;
using BlogApp.Validator;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controller;


[Route("Posts/{postId}/[controller]")]
[ApiController]
public class CommentsController : ControllerBase{
    private readonly ApiDbContext _context ;
    private readonly CommentManager _commentManager;
    public CommentsController(ApiDbContext context){
        _context = context;
        _commentManager = new CommentManager(_context);
    }


    [HttpGet]
    public IActionResult GetComments(int postId){
        try{
            return Ok(_commentManager.GetAllComments(postId));
        }
        catch (CustomException e){
            return StatusCode(404, e.Message);
        }
        catch (Exception){
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost]
    public IActionResult AddComment(int postId, [FromBody]CreateCommentDto comment){
        try{
            Comment addedComment = _commentManager.CreateComment(
                new Comment(){
                    PostId = postId,
                    Text = comment.Text,
                }
            );
            return CreatedAtAction(nameof(GetComments), new { postId, id = addedComment.Id }, addedComment);
        }
        catch (CustomException e){
            return StatusCode(404, e.Message);
        }
        catch (Exception){
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut("{commentId}")]
    public IActionResult UpdateComment(int postId, int commentId, [FromBody] UpdateCommentDto updatedComment){
        try{
            Comment comment = _commentManager.UpdateComment(
            new Comment(){
                Id = commentId,
                PostId = postId,
                Text = updatedComment.Text,
            });
            return Ok(comment);
        }
        catch(CustomException e){
            return StatusCode(404, e.Message);
        }
        catch(Exception){
            return StatusCode(500, "Internal server error");
        }
    }

    // Post method with domain/Posts/postId/Comments/commentId  -------> return No Contenet
    [HttpDelete("{commentId}")]
    public IActionResult DeleteComment(int commentId){
        try{
            _commentManager.DeleteComment(commentId);
            return NoContent();
        }
        catch(CustomException e){
            return StatusCode(404, e.Message);
        }
        catch(Exception){
            return StatusCode(500, "Internal server error");
        }
    }

}