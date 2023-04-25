using Xunit.Abstractions;

namespace xUnitBasic;
/// <summary>
/// The test works with the same context for all classes of the same collection.
/// The output will display the same guid for all methods in both classes.
/// By default xunit runs the tests in parallel.
/// In scenarios that work with the same context, it might be interesting to work with sequential tests.
/// To disable parallelism uncomment the code in CollectionBehaviorOverride.
/// </summary>
[CollectionDefinition("GuidGenerateCollectionTest")]
public class GuidGenerateDefinition : ICollectionFixture<GuidGenerator> { }

[CollectionDefinition("GuidGenerateCollectionTest")]
public class GuidGenerateCollectionTest
{
    private readonly GuidGenerator _guidGenerator;
    private readonly ITestOutputHelper _output;

    public GuidGenerateCollectionTest(GuidGenerator guidGenerator, ITestOutputHelper output)
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
}

[CollectionDefinition("GuidGenerateCollectionTest")]
public class GuidGenerateCollectionTestTwo
{
    private readonly GuidGenerator _guidGenerator;
    private readonly ITestOutputHelper _output;

    public GuidGenerateCollectionTestTwo(GuidGenerator guidGenerator, ITestOutputHelper output)
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
}