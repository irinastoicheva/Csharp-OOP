using P01.Logger.Loggers.Contracts;
using System.Linq;

namespace P01.Logger.Layouts
{

    public class LogFile : ILogFile
    {
        public int Size {get; private set;}

        public void Write(string message)
        {
            this.Size += message.Where(char.IsLetter).Sum(x => x);
        }
    }
}
