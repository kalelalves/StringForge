# StringForge

Uma biblioteca .NET pequena, direta e pronta para o dia a dia de quem precisa manipular textos sem reescrever os mesmos helpers em todo projeto.

```csharp
using StringForge;

var slug = "Funções em C#: Manipulando Strings com Maestria".ToSlug();
// funcoes-em-c-manipulando-strings-com-maestria

var phone = "+55 (11) 98765-4321".OnlyDigits();
// 5511987654321

var name = "  kalel   alves  ".NormalizeWhitespace().ToTitleCase();
// Kalel Alves

var hasEmoji = "Deploy pronto 🚀".HasEmoji();
// true

var binary = 'A'.ToBinary();
// 01000001
```

## Por que existe?

Manipular strings em C# costuma envolver as mesmas operacoes basicas: concatenar, substituir, buscar, dividir, formatar, validar prefixos/sufixos e normalizar textos. A proposta do StringForge e empacotar esses casos em metodos expressivos, testados e faceis de descobrir.

## Instalacao

Enquanto o pacote nao estiver publicado no NuGet, use referencia direta ao projeto:

```bash
dotnet add reference ../StringForge/StringForge.csproj
```

Quando publicar:

```bash
dotnet add package StringForge
```

## Metodos

| Metodo | Exemplo | Resultado |
| --- | --- | --- |
| `IsBlank()` | `"  ".IsBlank()` | `true` |
| `OrEmpty()` | `text.OrEmpty()` | `""` quando nulo |
| `NormalizeWhitespace()` | `"a   b\nc".NormalizeWhitespace()` | `"a b c"` |
| `RemoveDiacritics()` | `"ação".RemoveDiacritics()` | `"acao"` |
| `OnlyDigits()` | `"(11) 99999-0000".OnlyDigits()` | `"11999990000"` |
| `HasEmoji()` | `"Deploy pronto 🚀".HasEmoji()` | `true` |
| `CountCharacters()` | `"🚀".CountCharacters()` | `1` |
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

## Referencias de estudo

- [Funcoes em C#: Manipulando strings com maestria - DIO](https://www.dio.me/articles/funcoes-em-c-manipulando-strings-com-maestria)
- [Manipulando strings com C# - LuisDev](https://www.luisdev.com.br/2021/03/22/manipulando-strings-com-c/)
- [Strings com C#: como usa-las para manipular textos - Alura](https://www.alura.com.br/artigos/strings-com-c-sharp-para-manipular-textos)
- [Manipulacao de Strings em C# e .NET - Balta](https://blog.balta.io/manipulacao-de-strings-em-csharp-e-dotnet-o-guia-completo/)

## Desenvolvimento

```bash
dotnet restore
dotnet build
dotnet test
```


## Licenca

MIT
