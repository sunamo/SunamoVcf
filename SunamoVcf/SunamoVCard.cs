namespace SunamoVcf;

/// <summary>
/// Represents a virtual contact card with name, telephone, and email information.
/// </summary>
public class SunamoVCard
{
    /// <summary>
    /// Gets or sets whether telephone numbers should be wrapped in quotation marks when converted to string.
    /// </summary>
    public bool IsWrappingTelephoneInQuotationMarks { get; set; } = false;

    /// <summary>
    /// Gets or sets the first name of the contact.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the middle name of the contact.
    /// </summary>
    public string MiddleName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the last name of the contact.
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the collection of telephone numbers for the contact.
    /// </summary>
    public IEnumerable<SunamoTelephone> Telephones { get; set; } = Enumerable.Empty<SunamoTelephone>();

    /// <summary>
    /// Gets or sets the collection of email addresses for the contact.
    /// </summary>
    public IEnumerable<SunamoEmail> Emails { get; set; } = Enumerable.Empty<SunamoEmail>();

    /// <summary>
    /// Converts all telephone numbers to a comma-separated string.
    /// </summary>
    /// <returns>A comma-separated string of telephone numbers.</returns>
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
    /// Converts all email addresses to a comma-separated string.
    /// </summary>
    /// <returns>A comma-separated string of email addresses.</returns>
    public string EmailsToString()
    {
        var result = string.Empty;
        if (Emails != null) result = string.Join(",", Emails.Select(email => email.EmailAddress));

        return result;
    }

    /// <summary>
    /// Returns a string representation of the contact including name, telephones, and emails.
    /// </summary>
    /// <returns>A formatted string with all contact information.</returns>
    public override string ToString()
    {
        var firstName = EmptyIfNull(FirstName);
        var middleName = EmptyIfNull(MiddleName);
        var lastName = EmptyIfNull(LastName);

        var telephoneText = TelephonesToString();
        var emailText = EmailsToString();

        return $"{firstName} {middleName} {lastName} {telephoneText} {emailText}";
    }

    private string EmptyIfNull(string text)
    {
        return text ?? string.Empty;
    }
}
