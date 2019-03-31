 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type classInfo = typeof(HarvestingFields);

            FieldInfo[] fields = classInfo.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            string command = Console.ReadLine();

            while (command != "HARVEST")
            {
                FieldInfo[] sortedFields = SortedFields(command, fields);

                foreach (FieldInfo field in sortedFields)
                {
                    var attribute = field.Attributes.ToString().ToLower();
                    if (attribute == "family")
                    {
                        attribute = "protected";
                    }
                    else if (attribute == "assembly")
                    {
                        attribute = "internal";
                    }

                    Console.WriteLine($"{attribute} {field.FieldType.Name} {field.Name}");
                }

                command = Console.ReadLine();
            }
        }

        public static FieldInfo[] SortedFields(string type, FieldInfo[] fields)
        {
            switch (type)
            {
                case "private":
                   return fields = fields.Where(f => f.IsPrivate).ToArray();
                case "protected":
                   return fields = fields.Where(f => f.IsFamily).ToArray();
                case "public":
                   return fields = fields.Where(f => f.IsPublic).ToArray();
                case "all":
                    return fields;
                default:
                    return null;
            }
        }
    }
}
