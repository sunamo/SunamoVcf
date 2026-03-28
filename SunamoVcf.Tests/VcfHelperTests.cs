namespace SunamoVcf.Tests;

/// <summary>
/// Tests for VcfHelper serialization and parsing functionality.
/// </summary>
public class VcfHelperTests
{
    /// <summary>
    /// Tests that SunamoVCardsToVCards correctly converts SunamoVCard objects to VCard objects.
    /// </summary>
    [Fact]
    public void SunamoVCardsToVCardsTest()
    {
        List<SunamoVCard> sunamoVCards = new()
        {
            new SunamoVCard
            {
                FirstName = "John",
                MiddleName = "M",
                LastName = "Doe",
                Telephones = new List<SunamoTelephone>
                {
                    new SunamoTelephone
                    {
                        Number = "+420123456789",
                        Type = SunamoTelephoneType.Cell,
                        Preference = 1
                    }
                },
                Emails = new List<SunamoEmail>
                {
                    new SunamoEmail
                    {
                        EmailAddress = "john.doe@example.com",
                        Type = SunamoEmailType.Smtp,
                        Preference = 1
                    }
                }
            }
        };

        var result = VcfHelper.SunamoVCardsToVCards(sunamoVCards);

        Assert.Single(result);
        Assert.Equal("John", result[0].FirstName);
        Assert.Equal("M", result[0].MiddleName);
        Assert.Equal("Doe", result[0].LastName);
    }

    /// <summary>
    /// Tests that ConvertTelephones correctly converts Telephone objects to SunamoTelephone objects.
    /// </summary>
    [Fact]
    public void ConvertTelephonesTest()
    {
        var telephones = new List<MixERP.Net.VCards.Models.Telephone>
        {
            new MixERP.Net.VCards.Models.Telephone
            {
                Number = "+420111222333",
                Type = MixERP.Net.VCards.Types.TelephoneType.Cell,
                Preference = 1
            }
        };

        var result = VcfHelper.ConvertTelephones(telephones).ToList();

        Assert.Single(result);
        Assert.Equal("+420111222333", result[0].Number);
        Assert.Equal(SunamoTelephoneType.Cell, result[0].Type);
        Assert.Equal(1, result[0].Preference);
    }

    /// <summary>
    /// Tests that SunamoVCard.ToString returns a formatted string with all contact information.
    /// </summary>
    [Fact]
    public void SunamoVCardToStringTest()
    {
        var sunamoVCard = new SunamoVCard
        {
            FirstName = "Jane",
            LastName = "Smith",
            Telephones = new List<SunamoTelephone>
            {
                new SunamoTelephone { Number = "+420999888777", Type = SunamoTelephoneType.Home, Preference = 1 }
            },
            Emails = new List<SunamoEmail>
            {
                new SunamoEmail { EmailAddress = "jane@example.com", Type = SunamoEmailType.Smtp, Preference = 1 }
            }
        };

        var result = sunamoVCard.ToString();

        Assert.Contains("Jane", result);
        Assert.Contains("Smith", result);
        Assert.Contains("+420999888777", result);
        Assert.Contains("jane@example.com", result);
    }

    /// <summary>
    /// Tests that EnumHelperVcf.Parse correctly parses enum values.
    /// </summary>
    [Fact]
    public void EnumHelperVcfParseTest()
    {
        var result = EnumHelperVcf.Parse<SunamoEmailType>(SunamoEmailType.Smtp);

        Assert.Equal(SunamoEmailType.Smtp, result);
    }
}
