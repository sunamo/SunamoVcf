namespace SunamoVcf;

/// <summary>
/// Represents the sunamo email type.
/// </summary>
public class SunamoEmail
{
    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    public SunamoEmailType Type { get; set; }

    /// <summary>
    /// Gets or sets the email address.
    /// </summary>
    public string EmailAddress { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the preference.
    /// </summary>
    public int Preference { get; set; }
}
