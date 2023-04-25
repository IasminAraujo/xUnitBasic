using Xunit.Abstractions;

namespace xUnitBasic;

/// <summary>
/// The test works with the same context, the guidGenerate will be instantiated only once.
/// The output will show the same guid for both test methods.
/// </summary>
public class GuidGenerateTestTwo : IClassFixture<GuidGenerator>, IDisposable
{
    private readonly GuidGenerator _guidGenerator;
    private readonly ITestOutputHelper _output;

    public GuidGenerateTestTwo(GuidGenerator guidGenerator, ITestOutputHelper output)
    {
        _guidGenerator = guidGenerator;
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
    public void Dispose()
    {
        //Can be used for database cleaning
        _output.WriteLine($"The class was disposed.");
    }

}
