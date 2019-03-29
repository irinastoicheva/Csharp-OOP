namespace P01.Logger
{
    using Core;

    public class Startup
    {
        public static void Main()
        {
            CommandInterpreter commandInterpreter = new CommandInterpreter();
            Engine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
