using CACC.StringManipulator;
using Xunit;

namespace CACC.StringManipulator.UnitTestAppxUnit;

public class StringManipulatorTests
{
    private readonly StringManipulator _manipulator = new();

    // ---------- ReverseString ----------

    [Fact]
    public void ReverseString_SimpleWord_ReturnsReversed()
        => Assert.Equal("aloh", _manipulator.ReverseString("hola"));

    [Fact]
    public void ReverseString_Phrase_ReturnsReversed()
        => Assert.Equal("odnuM aloH", _manipulator.ReverseString("Hola Mundo"));

    [Fact]
    public void ReverseString_Palindrome_ReturnsSameString()
        => Assert.Equal("anilina", _manipulator.ReverseString("anilina"));

    [Fact]
    public void ReverseString_EmptyString_ReturnsEmptyString()
        => Assert.Equal(string.Empty, _manipulator.ReverseString(string.Empty));

    [Fact]
    public void ReverseString_SingleCharacter_ReturnsSameCharacter()
        => Assert.Equal("a", _manipulator.ReverseString("a"));

    [Fact]
    public void ReverseString_WithSpacesAndNumbers_ReturnsReversed()
        => Assert.Equal("321 cba", _manipulator.ReverseString("abc 123"));

    [Fact]
    public void ReverseString_ReversingTwice_ReturnsOriginal()
    {
        const string original = "Camila Calderón";
        Assert.Equal(original, _manipulator.ReverseString(_manipulator.ReverseString(original)));
    }

    [Fact]
    public void ReverseString_NullInput_ThrowsArgumentNullException()
        => Assert.Throws<ArgumentNullException>(() => _manipulator.ReverseString(null!));

    // ---------- RemoveSpaces ----------

    [Fact]
    public void RemoveSpaces_TextWithSpaces_ReturnsWithoutSpaces()
        => Assert.Equal("HolaMundo", _manipulator.RemoveSpaces("Hola Mundo"));

    [Fact]
    public void RemoveSpaces_LeadingAndTrailingSpaces_ReturnsWithoutSpaces()
        => Assert.Equal("abc", _manipulator.RemoveSpaces("   abc   "));

    [Fact]
    public void RemoveSpaces_MultipleConsecutiveSpaces_ReturnsWithoutSpaces()
        => Assert.Equal("abc", _manipulator.RemoveSpaces("a    b     c"));

    [Fact]
    public void RemoveSpaces_TabsAndNewLines_AreRemoved()
        => Assert.Equal("abc", _manipulator.RemoveSpaces("a\tb\nc"));

    [Fact]
    public void RemoveSpaces_NoSpaces_ReturnsSameString()
        => Assert.Equal("sinespacios", _manipulator.RemoveSpaces("sinespacios"));

    [Fact]
    public void RemoveSpaces_OnlySpaces_ReturnsEmptyString()
        => Assert.Equal(string.Empty, _manipulator.RemoveSpaces("     "));

    [Fact]
    public void RemoveSpaces_EmptyString_ReturnsEmptyString()
        => Assert.Equal(string.Empty, _manipulator.RemoveSpaces(string.Empty));

    [Fact]
    public void RemoveSpaces_NullInput_ThrowsArgumentNullException()
        => Assert.Throws<ArgumentNullException>(() => _manipulator.RemoveSpaces(null!));
}
