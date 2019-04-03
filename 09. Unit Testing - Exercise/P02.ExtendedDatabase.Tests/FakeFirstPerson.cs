namespace P02.ExtendedDatabase.Tests
{
    public class FakeFirstPerson : IPerson
    {
        public FakeFirstPerson(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long Id { get; set; }
        public string Name { get; set; }
    }
}
