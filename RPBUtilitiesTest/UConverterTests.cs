using RPBUtilities;

namespace RPBUtilitiesTest;

internal enum TestEnum
{
    ONE = 1,
    TWO,
    THREE
}

[TestClass]
public class UConverterTests
{
    [TestMethod]
    public void ToInt()
    {
        const TestEnum t = TestEnum.ONE;

        var i = UConverter.ToInt(t);

        Assert.AreEqual(i, 1);
    }

}