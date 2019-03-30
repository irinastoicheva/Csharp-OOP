using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fieldsToInvestigate)
    {
        StringBuilder sb = new StringBuilder();

        Type classInfo = Type.GetType(className);

        sb.AppendLine($"Class under investigation: {className}");

        FieldInfo[] fields = classInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

        Object instance = Activator.CreateInstance(classInfo);

        foreach (FieldInfo field in fields)
        {
            if (fieldsToInvestigate.ToList().Contains(field.Name))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(instance)}");
            }
        }

        return sb.ToString().TrimEnd();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        StringBuilder sb = new StringBuilder();

        Type classInfo = Type.GetType(className);

        FieldInfo[] fields = classInfo.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public);
        foreach (FieldInfo field in fields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        IEnumerable<MethodInfo> publicMetods = classInfo.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic).Where(x => x.Name.StartsWith("get"));
        foreach (MethodInfo metod in publicMetods)
        {
            sb.AppendLine($"{metod.Name} have to be public!");
        }

        IEnumerable<MethodInfo> privateMetods = classInfo.GetMethods(BindingFlags.Instance | BindingFlags.Public).Where(x => x.Name.StartsWith("set")); ;
        foreach (MethodInfo metod in privateMetods)
        {
            sb.AppendLine($"{metod.Name} have to be private!");
        }

        return sb.ToString().TrimEnd();
    }

    public string RevealPrivateMethods(string className)
    {
        StringBuilder sb = new StringBuilder();

        Type classInfo = Type.GetType(className);

        IEnumerable<MethodInfo> privateMethods = classInfo.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        sb.AppendLine($"All Private Methods of Class: {className}");

        var baseClass = classInfo.BaseType;

        sb.AppendLine($"Base Class: {baseClass.Name}");

        foreach (MethodInfo method in privateMethods)
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().TrimEnd();
    }
}
