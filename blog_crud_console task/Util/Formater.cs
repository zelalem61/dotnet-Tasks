

using BlogApplication.Entities;

class Formater
{
    public static void FormatPost(Post post){
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{post.Id}.{post.Title}\t\t{post.CreatedAt}");
        Console.ForegroundColor = ConsoleColor.White;
    }
    public static void FormatPostDetil(Post post){
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{post.Id}.{post.Title}\t\t{post.CreatedAt}");
        Console.WriteLine($"\t{post.Content}");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void FormatComment(Comment comment){
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"\t\t{comment.Id}.{comment.Text}\t\t{comment.CreatedAt}");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void FormatError(string error){
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(error);
        Console.ForegroundColor = ConsoleColor.White;
    }
}