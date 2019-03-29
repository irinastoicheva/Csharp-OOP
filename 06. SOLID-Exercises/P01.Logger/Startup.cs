namespace P01.Logger
{
    using P01.Logger.Core;

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
