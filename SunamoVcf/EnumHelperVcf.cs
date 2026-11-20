namespace SunamoVcf;

/// <summary>
/// Represents the enum helper vcf type.
/// </summary>
public class EnumHelperVcf
{
    /// <summary>
    /// Parse t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="value">The value.</param>
    /// <returns>The parse t result.</returns>
    public static T Parse<T>(object value)
    {
        return (T)Enum.Parse(typeof(T), value.ToString() ?? string.Empty);
    }
}
