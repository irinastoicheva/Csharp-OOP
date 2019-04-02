namespace P08.CreateCustomClassAttribute
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var classType = typeof(Weapon);
            var attributes = classType.GetCustomAttributes(false);

            foreach (var attr in attributes)
            {
                var classAttr = attr as InfoAttribute;

                if (classAttr != null)
                {
                    string command;

                    while ((command = Console.ReadLine()) != "END")
                    {
                        switch (command)
                        {
                            case "Author":
                                Console.WriteLine($"Author: {classAttr.Author}");
                                break;
                            case "Revision":
                                Console.WriteLine($"Revision: {classAttr.Revision}");
                                break;
                            case "Description":
                                Console.WriteLine($"Class description: {classAttr.Description}");
                                break;
                            case "Reviewers":
                                Console.WriteLine($"Reviewers: {String.Join(", ", classAttr.Reviewers)}");
                                break;
                        }
                    }
                }
            }
        }
    }
}
