namespace P04.BarrackWars_TheCommandsStrikeBack
{
    using Data;
    using Contracts;
    using P04.BarrackWars_TheCommandsStrikeBack.Core.Factories;
    using P04.BarrackWars_TheCommandsStrikeBack.Core;

    class AppEntryPoint
    {
        static void Main(string[] args)
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            IRunnable engine = new Engine(repository, unitFactory);
            engine.Run();
        }
    }
}
