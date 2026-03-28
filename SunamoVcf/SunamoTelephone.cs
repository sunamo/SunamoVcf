namespace SunamoVcf;

/// <summary>
/// Represents a telephone number entry in a virtual contact card.
/// </summary>
public class SunamoTelephone
{
    /// <summary>
    /// Gets or sets the type of the telephone number.
    /// </summary>
    public SunamoTelephoneType Type { get; set; }

    /// <summary>
    /// Gets or sets the telephone number string.
    /// </summary>
    public string Number { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the preference order of this telephone number.
    /// </summary>
    public int Preference { get; set; }
}
