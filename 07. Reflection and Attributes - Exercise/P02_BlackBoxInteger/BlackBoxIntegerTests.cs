namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;
    using System.Linq;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type classInfo = typeof(BlackBoxInteger);

            BlackBoxInteger instance = (BlackBoxInteger)Activator.CreateInstance(classInfo, true);

            MethodInfo[] methods = classInfo.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] commandLine = input.Split("_");
                string command = commandLine[0];
                int value = int.Parse(commandLine[1]);

                MethodInfo method = methods.Where(x => x.Name == command).First();

                method.Invoke(instance, new object [] { value});

                var innerValue = classInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(x => x.Name == "innerValue").First();

                Console.WriteLine(innerValue.GetValue(instance));

                input = Console.ReadLine();
            }
        }
    }
}
