namespace SunamoVcf;

/// <summary>
/// Represents the sunamo v card type.
/// </summary>
public class SunamoVCard
{
    /// <summary>
    /// Gets or sets the is wrapping telephone in quotation marks.
    /// </summary>
    public bool IsWrappingTelephoneInQuotationMarks { get; set; } = false;

    /// <summary>
    /// Gets or sets the first name.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the middle name.
    /// </summary>
    public string MiddleName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the last name.
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the telephones.
    /// </summary>
    public IEnumerable<SunamoTelephone> Telephones { get; set; } = Enumerable.Empty<SunamoTelephone>();

    /// <summary>
    /// Gets or sets the emails.
    /// </summary>
    public IEnumerable<SunamoEmail> Emails { get; set; } = Enumerable.Empty<SunamoEmail>();

    /// <summary>
    /// Telephones to string.
    /// </summary>
    /// <typeparam name="SunamoTelephone">The type SunamoTelephone.</typeparam>
    /// <returns>The telephones to string result.</returns>
    public string TelephonesToString()
    {
        var result = string.Empty;
        if (Telephones != null)
        {
            var numbers = Telephones.Select(telephone => telephone.Number).ToList();
            if (IsWrappingTelephoneInQuotationMarks)
                for (var i = 0; i < numbers.Count; i++)
                    numbers[i] = "\"" + numbers[i] + "\"";

            result = string.Join(",", numbers);
        }

        return result;
    }

    /// <summary>
    /// Emails to string.
    /// </summary>
    /// <typeparam name="SunamoEmail">The type SunamoEmail.</typeparam>
    /// <returns>The emails to string result.</returns>
    public string EmailsToString()
    {
        var result = string.Empty;
        if (Emails != null) result = string.Join(",", Emails.Select(email => email.EmailAddress));

        return result;
    }

    /// <summary>
    /// Initializes a new instance of the to string class.
    /// </summary>
    /// <param name="IsWrappingTelephoneInQuotationMarks">The is wrapping telephone in quotation marks.</param>
    public override string ToString()
    {
        var firstName = EmptyIfNull(FirstName);
        var middleName = EmptyIfNull(MiddleName);
        var lastName = EmptyIfNull(LastName);

        var telephoneText = TelephonesToString();
        var emailText = EmailsToString();

        return $"{firstName} {middleName} {lastName} {telephoneText} {emailText}";
    }

    private string EmptyIfNull(string text) => text ?? string.Empty;
}
