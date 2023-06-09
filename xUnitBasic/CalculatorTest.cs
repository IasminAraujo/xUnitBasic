using System.Collections;

namespace xUnitBasic;

public class CalculatorTest
{
    private readonly Calculator _sut; //system under test

    public CalculatorTest()
    {
        _sut = new Calculator();
    }

    [Fact]
    //[Fact(Skip = "If I want to skip this test I add the skip attribute")]
    public void AddTwoNumbersShouldEqualTheirEqual()
    {
        _sut.Add(5);
        _sut.Add(8);

        Assert.Equal(13, _sut.Value);
    }

    [Theory]
    [InlineData(13, 5, 8)]
    [InlineData(0, 3, -3)]
    [InlineData(0, 0, 0)]
    public void AddTwoNumbersShouldEqualTheirEqualTheory(decimal expected, decimal firstToAdd, decimal secondToAdd)
    {
        _sut.Add(firstToAdd);
        _sut.Add(secondToAdd);

        Assert.Equal(expected, _sut.Value);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void AddManyNumbersShouldEqualTheirEqualTheory(decimal expected, params decimal[] valuesToAdd)
    {
        foreach (var value in valuesToAdd)
            _sut.Add(value);

        Assert.Equal(expected, _sut.Value);
    }

    [Theory]
    [ClassData(typeof(DivisionTestData))]
    public void DivideManyNumbersTheory(decimal expected, params decimal[] valuesToAdd)
    {
        foreach (var value in valuesToAdd)
            _sut.Divide(value);

        Assert.Equal(expected, _sut.Value);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return new object[] { 15, new decimal[] { 10, 5 } };
        yield return new object[] { 15, new decimal[] { 5, 5, 5 } };
        yield return new object[] { -10, new decimal[] { -20, 10 } };
    }

    public class DivisionTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 30, new decimal[] { 60, 2 } };
            yield return new object[] { 0, new decimal[] { 0,1 } };
            yield return new object[] { 1, new decimal[] { 45, 45 } };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}