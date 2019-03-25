namespace P04.Telephony
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Smartphone : ICall, IWeb
    {
        public string Call(List<string> phoneNumbers)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in phoneNumbers)
            {
                try
                {
                    for (int i = 0; i < item.Length; i++)
                    {
                        if (!char.IsDigit(item[i]))
                        {
                            throw new ArgumentException("Invalid number!");
                        }
                    }
                    sb.AppendLine($"Calling... {item}");
                }
                catch (ArgumentException ae)
                {
                    sb.AppendLine(ae.Message);                  
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string Web(List<string> uRLs)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in uRLs)
            {
                try
                {
                    for (int i = 0; i < item.Length; i++)
                    {
                        if (Char.IsDigit(item[i]))
                        {
                            throw new ArgumentException("Invalid URL!");
                        }
                    }
                    sb.AppendLine($"Browsing: {item}!");
                }
                catch (ArgumentException ae)
                {
                    sb.AppendLine(ae.Message);
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
