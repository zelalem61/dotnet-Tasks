namespace BlogApp.Validator;
// Used by the controller to validate user input if body doesnt have this field it will return 404
public record CreatePostDto(
    string Title, 
    string Content
);

public record CreateCommentDto(
    string Text
);

public record UpdatePostDto(
    string Title, 
    string Content
);

public record UpdateCommentDto(
    string Text
);