using SunamoVcf.Enums;

namespace SunamoVcf;

public class VcfHelper
{
    public static List<VCard> SunamoVCardsToVCards(List<SunamoVCard> vc)
    {
        List<VCard> result = new();

        List<Telephone> tele = new();
        List<Email> mails = new();

        foreach (var i in vc)
        {
            tele.Clear();
            mails.Clear();

            if (i.Telephones != null)
                foreach (var i2 in i.Telephones)
                    tele.Add(new Telephone
                    {
                        Number = i2.Number,
                        Preference = i2.Preference,
                        Type = EnumHelperVcf.Parse<TelephoneType>(i2.Type)
                    });

            if (i.Emails != null)
                foreach (var i2 in i.Emails)
                    mails.Add(new Email
                    {
                        EmailAddress = i2.EmailAddress,
                        Type = EnumHelperVcf.Parse<EmailType>(i2.Type),
                        Preference = i2.Preference
                    });

            result.Add(new VCard
            {
                FirstName = i.FirstName,
                MiddleName = i.MiddleName,
                LastName = i.LastName,
                Telephones = tele,
                Emails = mails
            });
        }

        return result;
    }

    public static
#if ASYNC
    async Task
#else
void
#endif
    Serialize(string file, List<SunamoVCard> vc)
    {
        var con = SunamoVCardsToVCards(vc);
        var d = con.Serialize();

        file += AllExtensions.vcf;


#if ASYNC
        await
#endif
        TFSE.WriteAllText(file, d);
    }

    public static List<SunamoVCard> Parse(string path)
    {
        var vcards = Deserializer.Deserialize(path);
        List<SunamoVCard> vc = new();
        foreach (var item in vcards)
        {
            SunamoVCard v = new()
            {
                Emails = Emails(item.Emails),
                Telephones = Telephones(item.Telephones),
                FirstName = item.FirstName,
                MiddleName = item.MiddleName,
                LastName = item.LastName
            };

            vc.Add(v);
        }

        return vc;
    }

    private static IEnumerable<SunamoEmail> Emails(IEnumerable<Email> emails)
    {
        List<SunamoEmail> l = new();
        if (emails != null)
            foreach (var i in emails)
                l.Add(new SunamoEmail
                {
                    EmailAddress = i.EmailAddress,
                    Preference = i.Preference,
                    Type = EnumHelperVcf.Parse<SunamoEmailType>(i.Type)
                });

        return l;
    }

    public static IEnumerable<SunamoTelephone> Telephones(IEnumerable<Telephone> telephones)
    {
        List<SunamoTelephone> l = new();
        if (telephones != null)
            foreach (var i in telephones)
                l.Add(new SunamoTelephone
                {
                    Number = i.Number,
                    Type = EnumHelperVcf.Parse<SunamoTelephoneType>(i.Type),
                    Preference = i.Preference
                });

        return l;
    }
}
