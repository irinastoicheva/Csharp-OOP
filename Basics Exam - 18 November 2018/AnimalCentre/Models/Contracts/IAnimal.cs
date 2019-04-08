namespace AnimalCentre.Models.Contracts
{
    public interface IAnimal
    {
        string Name { get; }
        int Energy { get; }
        int Happiness { get; }
        int ProcedureTime { get; }
        bool IsVaccinated { get; }
        bool IsChipped { get; }
        bool IsAdopt { get; }
        string Owner { get; }
    }
}
