namespace P04.Telephony
{
    using System.Collections.Generic;

    public interface ICall
    {
        string Call(List<string> phoneNumbers);
    }
}
