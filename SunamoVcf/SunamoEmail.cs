namespace SunamoVcf;

/// <summary>
/// Represents an email address entry in a virtual contact card.
/// </summary>
public class SunamoEmail
{
    /// <summary>
    /// Gets or sets the type of the email address.
    /// </summary>
    public SunamoEmailType Type { get; set; }

    /// <summary>
    /// Gets or sets the email address string.
    /// </summary>
    public string EmailAddress { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the preference order of this email address.
    /// </summary>
    public int Preference { get; set; }
}
