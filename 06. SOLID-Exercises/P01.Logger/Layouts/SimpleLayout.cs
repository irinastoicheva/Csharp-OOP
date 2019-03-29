namespace P01.Logger.Layouts
{
    using P01.Logger.Layouts.Contracts;

    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
