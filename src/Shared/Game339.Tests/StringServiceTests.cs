using System;
using Game339.Shared.Services.Implementation;
using NUnit.Framework;

namespace Game339.Tests;

public class StringServiceTests
{
    private StringService _svc;

    [SetUp]
    public void SetUp()
    {
        _svc = new StringService(EmptyGameLog.Instance);
    }

    [TestCase("hello", "hello")]                 // single word stays the same
    [TestCase("", "")]                           // empty stays empty
    [TestCase("a", "a")]                         // single word stays the same
    [TestCase("racecar", "racecar")]             // single word stays the same
    [TestCase("hello world", "world hello")]     // two words swap
    [TestCase("one two three", "three two one")] // multiple words reverse
    public void ReverseWords_ReturnsExpectedString(string input, string expected)
    {
        // Act
        var result = _svc.ReverseWords(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ReverseWords_NullString_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => _svc.ReverseWords(null));
    }
}
