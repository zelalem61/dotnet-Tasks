using BlogApplication.Context;
using BlogApplication.Services;

using Microsoft.EntityFrameworkCore;



var connectionString = "Server=localhost;Port=5432;Database=Blog;Username=postgres;Password=postgress";

// Configure the DbContextOptions
var options = new DbContextOptionsBuilder<BlogContext>()
    .UseNpgsql(connectionString)
    .Options;

var context = new BlogContext(options);
var blogManager = new BlogManager(context);



while(true) {

    Console.WriteLine("0. Save and Exit Program");
    Console.WriteLine("1. Add Post");
    Console.WriteLine("2. See Posts");
    Console.WriteLine("3. Post Detail");
    Console.WriteLine("4. Delete Post");
    Console.WriteLine("6. Update Post");

    int choice = UserInputHandler.GetIntInput("Choose a correct option", 0, 6);

    if(choice == 0){
        Console.WriteLine("\nSaving and Exiting Program");

        Console.WriteLine("Saved and Exited Program\n");
        return;
    }

    else if(choice == 1){
        Console.WriteLine("\nAdding a Post");
        string title = UserInputHandler.GetStringInput("Enter The post title", 1);
        string content = UserInputHandler.GetStringInput("Enter Contenet", 5);
        blogManager.CreatePost(title, content);
    }

    else if(choice == 2){
        blogManager.DisplayPosts();                 
    }

    else if(choice == 3){
        int id = UserInputHandler.GetIntInput("Enter Post Id");
        blogManager.DisplayPostDetail(id);
        Console.WriteLine("0. Exit Detail");
        Console.WriteLine("1. Add Comment");
        Console.WriteLine("2. update comment");
        Console.WriteLine("3. Delete Comment");
        int option = UserInputHandler.GetIntInput("Choose a correct option", 0, 3);
        if (option == 0){
            continue;
        }
        else if (option == 1){
            string text = UserInputHandler.GetStringInput("Enter Comment", 1);
            blogManager.CreateComment(id, text);
        }
        else if (option == 2){
            int commentId = UserInputHandler.GetIntInput("Enter Comment Id");
            string text = UserInputHandler.GetStringInput("Enter Updated Comment", 1);
            blogManager.UpdateComment(commentId, id, text);
        }
        else if (option == 3){
            int commentId = UserInputHandler.GetIntInput("Enter Comment Id");
            blogManager.DeleteComment(commentId);
        }

    }

    else if(choice == 4){
        int id = UserInputHandler.GetIntInput("Enter Post Id");
        blogManager.DeletePost(id);
    }

    else if(choice == 5){
        int id = UserInputHandler.GetIntInput("Enter Post Id");
        string title = UserInputHandler.GetStringInput("Enter The post title", 1);
        string content = UserInputHandler.GetStringInput("Enter Contenet", 5);
        blogManager.UpdatePost(id, title, content);
    }
    else if(choice == 6){
        int id = UserInputHandler.GetIntInput("Enter Post Id");
        string title = UserInputHandler.GetStringInput("Enter New post title or leave it");
        string content = UserInputHandler.GetStringInput("Enter New Content or leave it");
        blogManager.UpdatePost(id, title, content);
    }

    else{
        Console.WriteLine("Choose a correct option");
    }
}





