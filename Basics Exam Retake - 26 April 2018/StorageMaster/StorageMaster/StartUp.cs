namespace StorageMaster
{
    using Core;
    using System;
    public class StartUp
    {
        public static void Main()
        {
            StorageMaster sm = new StorageMaster();
            Engine engine = new Engine(sm);
            engine.Run();
        }
    }
}
