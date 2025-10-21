// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoVcf;

public class EnumHelperVcf
{
    public static T Parse<T>(object i)
    {
        return (T)Enum.Parse(typeof(T), i.ToString());
    }
}