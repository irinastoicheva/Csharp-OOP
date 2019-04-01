namespace P05.BarrackWarsReturnOfTheDependencies
{
    using Data;
    using Contracts;
    using Core.Factories;
    using Core;

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
