namespace SunamoVcf;

public class EnumHelperVcf
{
    public static T Parse<T>(object value)
    {
        return (T)Enum.Parse(typeof(T), value.ToString() ?? string.Empty);
    }
}
