# StringForge

StringForge is a compact .NET library with practical string extension methods for everyday text handling.

It focuses on the helpers developers often rewrite from scratch: whitespace normalization, slugs, case conversion, digit extraction, special character cleanup, emoji detection, binary conversion, initials, safe truncation, and simple text searches.

```csharp
using StringForge;

var slug = "Fun\u00e7\u00f5es em C#: Manipulando Strings com Maestria".ToSlug();
// funcoes-em-c-manipulando-strings-com-maestria

var phone = "+55 (11) 98765-4321".OnlyDigits();
// 5511987654321

var name = "  kalel   alves  ".NormalizeWhitespace().ToTitleCase();
// Kalel Alves

var hasEmoji = "Deploy pronto \U0001F680".HasEmoji();
// true

var binary = 'A'.ToBinary();
// 01000001
```

## Why StringForge?

String manipulation in C# is powerful, but many common workflows still become repetitive across projects. StringForge packages those small, useful operations behind expressive extension methods that are easy to discover, easy to chain, and covered by tests.

## Methods

| Method | Example | Result |
| --- | --- | --- |
| `IsBlank()` | `"  ".IsBlank()` | `true` |
| `OrEmpty()` | `text.OrEmpty()` | `""` when null |
| `NormalizeWhitespace()` | `"a   b\nc".NormalizeWhitespace()` | `"a b c"` |
| `RemoveDiacritics()` | `"a\u00e7\u00e3o".RemoveDiacritics()` | `"acao"` |
| `OnlyDigits()` | `"(11) 99999-0000".OnlyDigits()` | `"11999990000"` |
| `HasEmoji()` | `"Deploy \U0001F680".HasEmoji()` | `true` |
| `CountCharacters()` | `"\U0001F680".CountCharacters()` | `1` |
| `HasSpecialCharacters()` | `"abc@123".HasSpecialCharacters()` | `true` |
| `RemoveSpecialCharacters()` | `"Hello, world!".RemoveSpecialCharacters()` | `"Hello world"` |
| `ToBinary()` | `'A'.ToBinary()` | `"01000001"` |
| `ToBinary()` | `"AB".ToBinary()` | `"01000001 01000010"` |
| `Truncate(10)` | `"Manipulating".Truncate(10)` | `"Manipu..."` |
| `Left(4)` | `"Kalel".Left(4)` | `"Kale"` |
| `Right(3)` | `"Kalel".Right(3)` | `"lel"` |
| `EnsureStartsWith("https://")` | `"site.com".EnsureStartsWith("https://")` | `"https://site.com"` |
| `EnsureEndsWith("/")` | `"api/v1".EnsureEndsWith("/")` | `"api/v1/"` |
| `ReplaceMany(...)` | `"Hi, [name]".ReplaceMany(map)` | `"Hi, Kalel"` |
| `ContainsAny(...)` | `"C# and .NET".ContainsAny(["java", ".net"])` | `true` |
| `ContainsAll(...)` | `"C# and .NET".ContainsAll(["c#", ".net"])` | `true` |
| `Between("[", "]")` | `"ID [123]".Between("[", "]")` | `"123"` |
| `ToSlug()` | `"Hello, .NET!".ToSlug()` | `"hello-net"` |
| `ToSnakeCase()` | `"MyClass".ToSnakeCase()` | `"my_class"` |
| `ToKebabCase()` | `"MyClass".ToKebabCase()` | `"my-class"` |
| `ToPascalCase()` | `"my class".ToPascalCase()` | `"MyClass"` |
| `ToCamelCase()` | `"my class".ToCamelCase()` | `"myClass"` |
| `ToTitleCase()` | `"john smith".ToTitleCase()` | `"John Smith"` |
| `Initials()` | `"Kalel Alves".Initials()` | `"KA"` |
| `CountOccurrences("a")` | `"banana".CountOccurrences("a")` | `3` |
| `IsPalindrome()` | `"A base do teto desaba".IsPalindrome()` | `true` |
| `Words()` | `"C# for .NET".Words()` | `["c", "for", "net"]` |

## Philosophy

- Keep the API small and memorable.
- Prefer readable method names over clever abstractions.
- Return safe values for null or empty text whenever that makes sense.
- Make common text transformations chainable.
- Keep behavior documented through focused tests.

## Learning References

- [Funcoes em C#: Manipulando strings com maestria - DIO](https://www.dio.me/articles/funcoes-em-c-manipulando-strings-com-maestria)
- [Manipulando strings com C# - LuisDev](https://www.luisdev.com.br/2021/03/22/manipulando-strings-com-c/)
- [Strings com C#: como usa-las para manipular textos - Alura](https://www.alura.com.br/artigos/strings-com-c-sharp-para-manipular-textos)
- [Manipulacao de Strings em C# e .NET - Balta](https://blog.balta.io/manipulacao-de-strings-em-csharp-e-dotnet-o-guia-completo/)

---

# StringForge em portugues

StringForge e uma biblioteca .NET compacta com metodos de extensao para manipulacao de strings no dia a dia.

A ideia e reunir helpers que desenvolvedores costumam reescrever em varios projetos: normalizacao de espacos, slugs, conversao de case, extracao de digitos, remocao de caracteres especiais, deteccao de emoji, conversao para binario, iniciais, truncamento seguro e buscas simples em texto.

```csharp
using StringForge;

var slug = "Fun\u00e7\u00f5es em C#: Manipulando Strings com Maestria".ToSlug();
// funcoes-em-c-manipulando-strings-com-maestria

var telefone = "+55 (11) 98765-4321".OnlyDigits();
// 5511987654321

var nome = "  kalel   alves  ".NormalizeWhitespace().ToTitleCase();
// Kalel Alves

var temEmoji = "Deploy pronto \U0001F680".HasEmoji();
// true

var binario = 'A'.ToBinary();
// 01000001
```

## Por que StringForge?

Manipular strings em C# e poderoso, mas muitos fluxos comuns continuam repetitivos. StringForge empacota essas pequenas operacoes em metodos expressivos, faceis de descobrir, faceis de encadear e cobertos por testes.

## Metodos

| Metodo | Exemplo | Resultado |
| --- | --- | --- |
| `IsBlank()` | `"  ".IsBlank()` | `true` |
| `OrEmpty()` | `text.OrEmpty()` | `""` quando nulo |
| `NormalizeWhitespace()` | `"a   b\nc".NormalizeWhitespace()` | `"a b c"` |
| `RemoveDiacritics()` | `"a\u00e7\u00e3o".RemoveDiacritics()` | `"acao"` |
| `OnlyDigits()` | `"(11) 99999-0000".OnlyDigits()` | `"11999990000"` |
| `HasEmoji()` | `"Deploy \U0001F680".HasEmoji()` | `true` |
| `CountCharacters()` | `"\U0001F680".CountCharacters()` | `1` |
| `HasSpecialCharacters()` | `"abc@123".HasSpecialCharacters()` | `true` |
| `RemoveSpecialCharacters()` | `"Ola, mundo!".RemoveSpecialCharacters()` | `"Ola mundo"` |
| `ToBinary()` | `'A'.ToBinary()` | `"01000001"` |
| `ToBinary()` | `"AB".ToBinary()` | `"01000001 01000010"` |
| `Truncate(10)` | `"Manipulando".Truncate(10)` | `"Manipu..."` |
| `Left(4)` | `"Kalel".Left(4)` | `"Kale"` |
| `Right(3)` | `"Kalel".Right(3)` | `"lel"` |
| `EnsureStartsWith("https://")` | `"site.com".EnsureStartsWith("https://")` | `"https://site.com"` |
| `EnsureEndsWith("/")` | `"api/v1".EnsureEndsWith("/")` | `"api/v1/"` |
| `ReplaceMany(...)` | `"Ola, [nome]".ReplaceMany(map)` | `"Ola, Kalel"` |
| `ContainsAny(...)` | `"C# e .NET".ContainsAny(["java", ".net"])` | `true` |
| `ContainsAll(...)` | `"C# e .NET".ContainsAll(["c#", ".net"])` | `true` |
| `Between("[", "]")` | `"ID [123]".Between("[", "]")` | `"123"` |
| `ToSlug()` | `"Ola, .NET!".ToSlug()` | `"ola-net"` |
| `ToSnakeCase()` | `"MinhaClasse".ToSnakeCase()` | `"minha_classe"` |
| `ToKebabCase()` | `"MinhaClasse".ToKebabCase()` | `"minha-classe"` |
| `ToPascalCase()` | `"minha classe".ToPascalCase()` | `"MinhaClasse"` |
| `ToCamelCase()` | `"minha classe".ToCamelCase()` | `"minhaClasse"` |
| `ToTitleCase()` | `"joao silva".ToTitleCase()` | `"Joao Silva"` |
| `Initials()` | `"Kalel Alves".Initials()` | `"KA"` |
| `CountOccurrences("a")` | `"banana".CountOccurrences("a")` | `3` |
| `IsPalindrome()` | `"A base do teto desaba".IsPalindrome()` | `true` |
| `Words()` | `"C# para .NET".Words()` | `["c", "para", "net"]` |

## Filosofia

- Manter a API pequena e facil de lembrar.
- Preferir nomes claros em vez de abstracoes inteligentes demais.
- Retornar valores seguros para textos nulos ou vazios quando isso fizer sentido.
- Permitir transformacoes comuns em cadeia.
- Documentar o comportamento com testes focados.

## Referencias de estudo

- [Funcoes em C#: Manipulando strings com maestria - DIO](https://www.dio.me/articles/funcoes-em-c-manipulando-strings-com-maestria)
- [Manipulando strings com C# - LuisDev](https://www.luisdev.com.br/2021/03/22/manipulando-strings-com-c/)
- [Strings com C#: como usa-las para manipular textos - Alura](https://www.alura.com.br/artigos/strings-com-c-sharp-para-manipular-textos)
- [Manipulacao de Strings em C# e .NET - Balta](https://blog.balta.io/manipulacao-de-strings-em-csharp-e-dotnet-o-guia-completo/)

## License

MIT
