using MortalEngines.Core;
using MortalEngines.Core.Contracts;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
            IMachinesManager machinesManager = new MachinesManager();
            IEngine engine = new Engine(machinesManager);
            engine.Run();
        }
    }
}