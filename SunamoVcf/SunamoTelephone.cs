namespace SunamoVcf;

/// <summary>
/// Represents the sunamo telephone type.
/// </summary>
public class SunamoTelephone
{
    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    public SunamoTelephoneType Type { get; set; }

    /// <summary>
    /// Gets or sets the number.
    /// </summary>
    public string Number { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the preference.
    /// </summary>
    public int Preference { get; set; }
}
