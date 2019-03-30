using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fieldsToInvestigate)
    {
        StringBuilder sb = new StringBuilder();
        var classInfo = Type.GetType(className);

        sb.AppendLine($"Class under investigation: {className}");

        var fields = classInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

        var instance = Activator.CreateInstance(classInfo);

        foreach (var field in fields)
        {
            if (fieldsToInvestigate.ToList().Contains(field.Name))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(instance)}");
            }
        }

        return sb.ToString().TrimEnd();
    }
}
