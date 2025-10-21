// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

namespace SunamoVcf.Tests;

public class VcfHelperTests
{
    [Fact]
    public void VcfHelperParseTest()
    {
        var list = VcfHelper.Parse(@"D:\_Test\sunamo\SunamoVcf\contacts.vcf");

        int i = 0;
    }
}
