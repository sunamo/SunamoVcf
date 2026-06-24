namespace SunamoVcf;

public class SunamoVCard
{
    public bool IsWrappingTelephoneInQuotationMarks { get; set; } = false;

    public string FirstName { get; set; } = string.Empty;

    public string MiddleName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public IEnumerable<SunamoTelephone> Telephones { get; set; } = Enumerable.Empty<SunamoTelephone>();

    public IEnumerable<SunamoEmail> Emails { get; set; } = Enumerable.Empty<SunamoEmail>();

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

    public string EmailsToString()
    {
        var result = string.Empty;
        if (Emails != null) result = string.Join(",", Emails.Select(email => email.EmailAddress));

        return result;
    }

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
