namespace P01.Logger.Layouts
{
    using Layouts.Contracts;

    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
