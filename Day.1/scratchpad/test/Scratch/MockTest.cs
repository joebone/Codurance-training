using scratchpad;

namespace Tests.Scratch;
public class MockTest {
    public MockTest() {

    }

    [Theory, InlineData(true), InlineData(false)]
    void CanMock(bool fakeit) {
        //var dd = Substitute.For<RomanNumeralConverter>();
        var dd = Substitute.ForPartsOf<RomanNumeralConverter>();
        if (fakeit) {
            dd.Convert(22).Returns("FAKE");
            Assert.Equal("FAKE", dd.Convert(22));
        } else {
            Assert.Equal("XXII", dd.Convert(22));
        }
        Assert.Equal("XX", dd.Convert(20));
    }
}
