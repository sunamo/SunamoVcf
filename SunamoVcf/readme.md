# SunamoVcf

A .NET library for working with VCF (vCard) files. Provides serialization and deserialization of virtual contact cards including names, telephone numbers, and email addresses.

## Features

- Parse VCF files into strongly-typed SunamoVCard objects
- Serialize SunamoVCard objects to VCF format
- Convert between SunamoVCard and MixERP VCard formats
- Support for multiple telephone types (home, work, cell, fax, etc.)
- Support for multiple email types (SMTP, X.400, etc.)
- Async serialization support

## Usage

### Parsing a VCF file

```csharp
var contacts = VcfHelper.Parse("contacts.vcf");

foreach (var contact in contacts)
{
    Console.WriteLine($"{contact.FirstName} {contact.LastName}");
    Console.WriteLine($"Phones: {contact.TelephonesToString()}");
    Console.WriteLine($"Emails: {contact.EmailsToString()}");
}
```

### Serializing contacts to VCF

```csharp
var contacts = new List<SunamoVCard>
{
    new SunamoVCard
    {
        FirstName = "John",
        LastName = "Doe",
        Telephones = new List<SunamoTelephone>
        {
            new SunamoTelephone { Number = "+420123456789", Type = SunamoTelephoneType.Cell }
        },
        Emails = new List<SunamoEmail>
        {
            new SunamoEmail { EmailAddress = "john@example.com", Type = SunamoEmailType.Smtp }
        }
    }
};

await VcfHelper.Serialize("output", contacts);
```

## Target Frameworks

`net10.0`, `net9.0`, `net8.0`

## Links

- [NuGet](https://www.nuget.org/profiles/sunamo)
- [GitHub](https://github.com/sunamo/PlatformIndependentNuGetPackages)
- [Developer site](https://sunamo.cz)

For feature requests or bug reports: [Email](mailto:radek.jancik@sunamo.cz) or open an issue on GitHub.
