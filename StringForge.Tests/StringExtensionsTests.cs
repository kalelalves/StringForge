namespace StringForge.Tests;

public class StringExtensionsTests
{
    [Fact]
    public void NormalizeWhitespace_TrimsAndCollapsesWhitespace()
    {
        const string text = "  C#   manipula\r\nstrings\tcom classe  ";

        var result = text.NormalizeWhitespace();

        Assert.Equal("C# manipula strings com classe", result);
    }

    [Fact]
    public void RemoveDiacritics_RemovesAccents()
    {
        Assert.Equal("acao maca coracao", "ação maçã coração".RemoveDiacritics());
    }

    [Theory]
    [InlineData("Funções em C#: Manipulando Strings com Maestria", "funcoes-em-c-manipulando-strings-com-maestria")]
    [InlineData("  .NET + C# para APIs  ", "net-c-para-apis")]
    public void ToSlug_CreatesUrlFriendlyText(string value, string expected)
    {
        Assert.Equal(expected, value.ToSlug());
    }

    [Theory]
    [InlineData("minhaClasseHTTP", "minha_classe_http")]
    [InlineData("minha classe HTTP", "minha_classe_http")]
    public void ToSnakeCase_ConvertsCommonInputs(string value, string expected)
    {
        Assert.Equal(expected, value.ToSnakeCase());
    }

    [Fact]
    public void ReplaceMany_AppliesDictionaryReplacements()
    {
        var replacements = new Dictionary<string, string>
        {
            ["[nome]"] = "Kalel",
            ["[stack]"] = ".NET"
        };

        var result = "Ola, [nome]! Bora codar em [stack]?".ReplaceMany(replacements);

        Assert.Equal("Ola, Kalel! Bora codar em .NET?", result);
    }

    [Fact]
    public void Between_ReturnsTextInsideMarkers()
    {
        var result = "Pedido #123 [aprovado] entregue".Between("[", "]");

        Assert.Equal("aprovado", result);
    }

    [Fact]
    public void Truncate_RespectsSuffix()
    {
        var result = "Manipulando strings com maestria".Truncate(16);

        Assert.Equal("Manipulando s...", result);
    }

    [Fact]
    public void OnlyDigits_ExtractsNumbers()
    {
        Assert.Equal("11987654321", "+55 (11) 98765-4321".OnlyDigits().Right(11));
    }

    [Theory]
    [InlineData("Deploy pronto 🚀", true)]
    [InlineData("Texto comum", false)]
    public void HasEmoji_DetectsEmoji(string value, bool expected)
    {
        Assert.Equal(expected, value.HasEmoji());
    }

    [Theory]
    [InlineData("abc", 3)]
    [InlineData("🚀", 1)]
    [InlineData("á", 1)]
    public void CountCharacters_CountsTextElements(string value, int expected)
    {
        Assert.Equal(expected, value.CountCharacters());
    }

    [Theory]
    [InlineData("abc123", true, false)]
    [InlineData("abc 123", true, false)]
    [InlineData("abc 123", false, true)]
    [InlineData("abc@123", true, true)]
    public void HasSpecialCharacters_DetectsSymbols(string value, bool allowWhiteSpace, bool expected)
    {
        Assert.Equal(expected, value.HasSpecialCharacters(allowWhiteSpace));
    }

    [Theory]
    [InlineData("Ola, mundo! #2026", true, "Ola mundo 2026")]
    [InlineData("Ola, mundo! #2026", false, "Olamundo2026")]
    public void RemoveSpecialCharacters_RemovesSymbols(string value, bool preserveWhiteSpace, string expected)
    {
        Assert.Equal(expected, value.RemoveSpecialCharacters(preserveWhiteSpace));
    }

    [Fact]
    public void ToBinary_ConvertsCharToBinary()
    {
        Assert.Equal("01000001", 'A'.ToBinary());
    }

    [Fact]
    public void ToBinary_ConvertsStringToBinary()
    {
        Assert.Equal("01000001 01000010", "AB".ToBinary());
    }

    [Fact]
    public void Initials_ReturnsUppercaseInitials()
    {
        Assert.Equal("KA", "Kalel Alves".Initials());
    }

    [Fact]
    public void IsPalindrome_IgnoresPunctuationAndCaseByDefault()
    {
        Assert.True("A base do teto desaba".IsPalindrome());
    }

    [Fact]
    public void CountOccurrences_ReturnsNonOverlappingOccurrences()
    {
        Assert.Equal(3, "banana bandana banana".CountOccurrences("ana"));
    }
}
