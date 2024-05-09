namespace SunamoVcf;

public class SunamoVCard
{
    public bool wrapTelInQm = false;
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public IEnumerable<SunamoTelephone> Telephones { get; set; }
    public IEnumerable<SunamoEmail> Emails { get; set; }


    public string TelephonesToString()
    {
        var tel = string.Empty;
        if (Telephones != null)
        {
            var tels = Telephones.Select(t => t.Number).ToList();
            if (wrapTelInQm)
                for (var i = 0; i < tels.Count; i++)
                    tels[i] = "\"" + tels[i] + "\"";

            tel = string.Join(",", tels);
        }

        return tel;
    }

    public string EmailsToString()
    {
        var mail = string.Empty;
        if (Emails != null) mail = string.Join(",", Emails.Select(t => t.EmailAddress));

        return mail;
    }

    public override string ToString()
    {
        var fn = EmptyIfNull(FirstName);
        var mn = EmptyIfNull(MiddleName);
        var ln = EmptyIfNull(LastName);

        var tel = TelephonesToString();
        var mail = EmailsToString();

        return $"{fn} {mn} {ln} {tel} {mail}";
    }


    private object EmptyIfNull(string firstName)
    {
        return firstName == null ? string.Empty : firstName;
    }
}
