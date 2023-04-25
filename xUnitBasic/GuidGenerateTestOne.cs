using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace xUnitBasic;

/// <summary>
/// The test will generate two instances one for GuidTestOne and another for GuidTestTwo.
/// The output will show the same guid for both test methods.
/// </summary>
public class GuidGenerateTestOne
{
    private readonly GuidGenerator _guidGenerator;
    private readonly ITestOutputHelper _output;

    public GuidGenerateTestOne(ITestOutputHelper output)
    {
        _guidGenerator = new GuidGenerator();
        _output = output;
    }

    [Fact]
    public void GuidTestOne()
    {
        var guid = _guidGenerator.RandomGuid;
        _output.WriteLine($"The guid was : {guid}");
    }
    [Fact]
    public void GuidTestTwo()
    {
        var guid = _guidGenerator.RandomGuid;
        _output.WriteLine($"The guid was : {guid}");
    }
}
