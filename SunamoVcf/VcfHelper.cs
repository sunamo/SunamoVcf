namespace SunamoVcf;

/// <summary>
/// Provides methods for converting between SunamoVCard and VCard formats,
/// as well as serializing and parsing VCF files.
/// </summary>
public class VcfHelper
{
    /// <summary>
    /// Converts a list of SunamoVCard objects to a list of VCard objects.
    /// </summary>
    /// <param name="sunamoVCards">The list of SunamoVCard objects to convert.</param>
    /// <returns>A list of VCard objects.</returns>
    public static List<VCard> SunamoVCardsToVCards(List<SunamoVCard> sunamoVCards)
    {
        List<VCard> result = new();

        List<Telephone> telephones = new();
        List<Email> emails = new();

        foreach (var item in sunamoVCards)
        {
            telephones.Clear();
            emails.Clear();

            if (item.Telephones != null)
                foreach (var telephone in item.Telephones)
                    telephones.Add(new Telephone
                    {
                        Number = telephone.Number,
                        Preference = telephone.Preference,
                        Type = EnumHelperVcf.Parse<TelephoneType>(telephone.Type)
                    });

            if (item.Emails != null)
                foreach (var email in item.Emails)
                    emails.Add(new Email
                    {
                        EmailAddress = email.EmailAddress,
                        Type = EnumHelperVcf.Parse<EmailType>(email.Type),
                        Preference = email.Preference
                    });

            result.Add(new VCard
            {
                FirstName = item.FirstName,
                MiddleName = item.MiddleName,
                LastName = item.LastName,
                Telephones = telephones,
                Emails = emails
            });
        }

        return result;
    }

    /// <summary>
    /// Serializes a list of SunamoVCard objects to a VCF file.
    /// </summary>
    /// <param name="filePath">The file path to write the VCF data to. The .vcf extension is appended automatically.</param>
    /// <param name="sunamoVCards">The list of SunamoVCard objects to serialize.</param>
    public static
#if ASYNC
        async Task
#else
void
#endif
        Serialize(string filePath, List<SunamoVCard> sunamoVCards)
    {
        var vCards = SunamoVCardsToVCards(sunamoVCards);
        var serializedData = vCards.Serialize();

        filePath += ".vcf";

#if ASYNC
        await File.WriteAllTextAsync(filePath, serializedData);
#else
        File.WriteAllText(filePath, serializedData);
#endif
    }

    /// <summary>
    /// Parses a VCF file and returns a list of SunamoVCard objects.
    /// </summary>
    /// <param name="filePath">The path to the VCF file to parse.</param>
    /// <returns>A list of SunamoVCard objects parsed from the file.</returns>
    public static List<SunamoVCard> Parse(string filePath)
    {
        var vCards = Deserializer.Deserialize(filePath);
        List<SunamoVCard> sunamoVCards = new();
        foreach (var item in vCards)
        {
            SunamoVCard sunamoVCard = new()
            {
                Emails = ConvertEmails(item.Emails),
                Telephones = ConvertTelephones(item.Telephones),
                FirstName = item.FirstName,
                MiddleName = item.MiddleName,
                LastName = item.LastName
            };

            sunamoVCards.Add(sunamoVCard);
        }

        return sunamoVCards;
    }

    /// <summary>
    /// Converts a collection of Email objects to SunamoEmail objects.
    /// </summary>
    /// <param name="enumerable">The collection of Email objects to convert.</param>
    /// <returns>A collection of SunamoEmail objects.</returns>
    private static IEnumerable<SunamoEmail> ConvertEmails(IEnumerable<Email> enumerable)
    {
        List<SunamoEmail> list = new();
        if (enumerable != null)
            foreach (var item in enumerable)
                list.Add(new SunamoEmail
                {
                    EmailAddress = item.EmailAddress,
                    Preference = item.Preference,
                    Type = EnumHelperVcf.Parse<SunamoEmailType>(item.Type)
                });

        return list;
    }

    /// <summary>
    /// Converts a collection of Telephone objects to SunamoTelephone objects.
    /// </summary>
    /// <param name="enumerable">The collection of Telephone objects to convert.</param>
    /// <returns>A collection of SunamoTelephone objects.</returns>
    public static IEnumerable<SunamoTelephone> ConvertTelephones(IEnumerable<Telephone> enumerable)
    {
        List<SunamoTelephone> list = new();
        if (enumerable != null)
            foreach (var item in enumerable)
                list.Add(new SunamoTelephone
                {
                    Number = item.Number,
                    Type = EnumHelperVcf.Parse<SunamoTelephoneType>(item.Type),
                    Preference = item.Preference
                });

        return list;
    }
}
