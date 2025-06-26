public class ExitCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Exiting the application. \nGoodbye!");
    }
}