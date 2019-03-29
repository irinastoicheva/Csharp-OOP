namespace P01.Logger.Core.Contracts
{
    public interface ICommandInterpreter
    {
        void AddApender(string[] args);

        void AddReport(string[] args);

        void PrintInfo();
    }
}
