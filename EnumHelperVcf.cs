namespace SunamoVcf;

public class EnumHelperVcf
{
    public static T Parse<T>(object i)
    {
        return (T)Enum.Parse(typeof(T), i.ToString());
    }
}
