
public class UserInputHandler {

    public static string GetStringInput(string message, int length = 0){
        string? input = "";
        do{
            Console.WriteLine($"\n{message}");
            Console.Write($"\t>> ");
            input = Console.ReadLine();
        } while (

            input == null ||
            input.Length < length
            );
        return input;
    }
    
    public static int GetIntInput(string message, int mini = 0, int maxi = int.MaxValue){
        int inputInteger;
        do{
            Console.WriteLine($"\n{message}");
            Console.Write($"\t>> ");
        } while (
            !int.TryParse(Console.ReadLine(), out inputInteger) ||
            inputInteger < mini ||
            inputInteger > maxi
        );
        return inputInteger;
    }

    public static float GetFloatInput(string message, int mini = 0, int maxi = int.MaxValue){
        float inputFloat;
        do{
            Console.WriteLine($"\n{message}");
            Console.Write($"\t>> ");
        } while (
            !float.TryParse(Console.ReadLine(), out inputFloat) ||
            inputFloat < mini ||
            inputFloat > maxi
        );
        return inputFloat;
    }
}