namespace SunamoVcf;

/// <summary>
/// Provides helper methods for parsing enum values used in VCF processing.
/// </summary>
public class EnumHelperVcf
{
    /// <summary>
    /// Parses an object value to the specified enum type.
    /// </summary>
    /// <typeparam name="T">The enum type to parse to.</typeparam>
    /// <param name="value">The value to parse as an enum.</param>
    /// <returns>The parsed enum value of type T.</returns>
    public static T Parse<T>(object value)
    {
        return (T)Enum.Parse(typeof(T), value.ToString() ?? string.Empty);
    }
}
