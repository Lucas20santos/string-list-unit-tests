# 🧮 Projeto de Validação de Listas e Strings em C# (.NET 8)

- > 📘 **Autor:** Lucas Santos
- > 🧩 **Objetivo:** Criar métodos de validação e manipulação (listas e strings) com testes automatizados utilizando **xUnit**

---

## 📑 Sumário

- [🧮 Projeto de Validação de Listas e Strings em C# (.NET 8)](#-projeto-de-validação-de-listas-e-strings-em-c-net-8)
  - [📑 Sumário](#-sumário)
  - [🗂 Estrutura do Projeto](#-estrutura-do-projeto)
  - [⚙️ Tecnologias Utilizadas](#️-tecnologias-utilizadas)
  - [📦 Descrição Geral](#-descrição-geral)
  - [🧱 Classes e Métodos](#-classes-e-métodos)
    - [✅ Classe `ValidacaoLista`](#-classe-validacaolista)
    - [✳️ Classe `ValidacaoString`](#️-classe-validacaostring)
      - [1. `bool EstaNulaOuVazia(string texto)`](#1-bool-estanulaouvaziastring-texto)
      - [2. `string RemoverEspacosExtras(string texto)`](#2-string-removerespacosextrasstring-texto)
      - [3. `string CapitalizarPrimeiraLetra(string texto)`](#3-string-capitalizarprimeiraletrastring-texto)
      - [4. `bool ValidarFormatoEmail(string email)` (opcional)](#4-bool-validarformatoemailstring-email-opcional)
  - [🧪 Testes Automatizados](#-testes-automatizados)
    - [🎯 Estrutura dos Testes](#-estrutura-dos-testes)
    - [📊 Exemplos de Casos de Teste (resumidos)](#-exemplos-de-casos-de-teste-resumidos)
      - [`ValidacaoString.EstaNulaOuVazia`](#validacaostringestanulaouvazia)
      - [`ValidacaoString.RemoverEspacosExtras`](#validacaostringremoverespacosextras)
      - [`ValidacaoString.CapitalizarPrimeiraLetra`](#validacaostringcapitalizarprimeiraletra)
      - [`ValidacaoString.ValidarFormatoEmail`](#validacaostringvalidarformatoemail)
  - [🧰 Como Executar o Projeto](#-como-executar-o-projeto)
  - [🌲 Estrutura de Pastas (atualizada)](#-estrutura-de-pastas-atualizada)
  - [🚀 Conclusão](#-conclusão)
    - [🧾 Badges sugeridos (copiar pro topo do README)](#-badges-sugeridos-copiar-pro-topo-do-readme)

---

## 🗂 Estrutura do Projeto

O repositório contém **dois projetos principais**:

```md
DesafioProjeto/                 # Projeto console / biblioteca principal
 ├─ Program.cs
 ├─ ValidacaoLista.cs
 ├─ ValidacaoString.cs         # nova classe de validações de string
 └─ DesafioProjeto.csproj

DesafioProjetoTests/           # Projeto de testes
 ├─ ValidacaoListaTests.cs
 ├─ ValidacaoStringTests.cs    # testes das validações de string
 └─ DesafioProjetoTests.csproj
```

---

## ⚙️ Tecnologias Utilizadas

| Tecnologia                                 | Descrição                                   |
| ------------------------------------------ | ------------------------------------------- |
| 🟦 **C# (.NET 8)**                         | Linguagem de programação principal          |
| 🧩 **xUnit**                               | Framework de testes unitários               |
| 🧠 **LINQ**                                | Manipulação de coleções (listas)            |
| 🧰 **.NET CLI**                            | `dotnet build`, `dotnet run`, `dotnet test` |
| 🧪 **Assert.Throws / Theory / MemberData** | Estratégias de teste usadas                 |

---

## 📦 Descrição Geral

Este projeto concentra utilitários simples e robustos para manipulação de listas numéricas e validação/manipulação de strings. A ênfase é em **programação defensiva**, **leitura clara** e **testabilidade**.

---

## 🧱 Classes e Métodos

### ✅ Classe `ValidacaoLista`

Localizada em `ValidacaoLista.cs`. Métodos principais já documentados:

- **`List<int> MultiplicarNumerosLista(List<int> lista, int numero)`**
  Multiplica todos os elementos da lista por `numero`.

  - Validações: lança `ArgumentNullException` se `lista` for `null`.
  - Retorna nova `List<int>` (lista vazia → retorna lista vazia).

- **`int RetornarMaiorNumeroLista(List<int> lista)`**
  Retorna o maior número da lista.

  - Validações: lança `ArgumentException` se `lista` for `null` ou vazia.

---

### ✳️ Classe `ValidacaoString`

Arquivo sugerido: `ValidacaoString.cs`. Objetivo: agrupar validações/normalizações de texto comuns para aplicações.

#### 1. `bool EstaNulaOuVazia(string texto)`

- **Descrição:** Retorna `true` se `texto` for `null`, vazio (`""`) ou apenas espaços.
- **Exceção:** nenhuma — retorna booleano.

#### 2. `string RemoverEspacosExtras(string texto)`

- **Descrição:** Normaliza espaços: remove espaços no início/fim e reduz múltiplos espaços entre palavras para um único espaço.
- **Validação:** Se `texto` for `null` lança `ArgumentNullException`.

**Exemplo:** `"  Olá   mundo  "` → `"Olá mundo"`

#### 3. `string CapitalizarPrimeiraLetra(string texto)`

- **Descrição:** Coloca a primeira letra da string em maiúscula e mantém o restante (ou opcionalmente capitaliza cada palavra — documentar o comportamento).
- **Validação:** lança `ArgumentNullException` se `texto` for `null`; retorna `""` ou lança `ArgumentException` se `texto` for vazio — escolha e documente.

**Exemplo:** `"lucas"` → `"Lucas"`

#### 4. `bool ValidarFormatoEmail(string email)` (opcional)

- **Descrição:** Verifica se `email` segue um padrão simples (usando regex básica). Não substitui validação completa (não confundir com verificação de existência de domínio).
- **Validação:** se `email` for `null` retorna `false` ou lança `ArgumentNullException` — documente a escolha.

**Exemplo:** `"teste@dominio.com"` → `true` ; `"nao-e-mail"` → `false`

> ⚠️ Documente claramente exceções vs retornos booleanos. Para bibliotecas utilitárias, preferível retornar booleans para funções de validação e lançar exceções apenas quando o comportamento for de transformação (ex.: `RemoverEspacosExtras` quando recebe `null`).

---

## 🧪 Testes Automatizados

### 🎯 Estrutura dos Testes

- `ValidacaoListaTests.cs` — contém `[Fact]` e `[Theory]` para:

  - `MultiplicarNumerosLista` (dados positivos, zeros, negativos, lista vazia, lista nula).
  - `RetornarMaiorNumeroLista` (listas diversas + testes de exceção para `null` e `[]`).

- `ValidacaoStringTests.cs` — testes para cada método de `ValidacaoString`:

  - `EstaNulaOuVazia`: `null`, `""`, `"   "`, `"texto"`.
  - `RemoverEspacosExtras`: string com múltiplos espaços, string já normalizada, `null` (exceção).
  - `CapitalizarPrimeiraLetra`: `"lucas" → "Lucas"`, `""` (decida comportamento), `null` (exceção).
  - `ValidarFormatoEmail`: conjunto de strings válidas e inválidas.

### 📊 Exemplos de Casos de Teste (resumidos)

#### `ValidacaoString.EstaNulaOuVazia`

- `null` → `true`
- `""` → `true`
- `"   "` → `true`
- `"texto"` → `false`

#### `ValidacaoString.RemoverEspacosExtras`

- `"  Olá   mundo  "` → `"Olá mundo"`
- `"texto"` → `"texto"`
- `null` → `ArgumentNullException`

#### `ValidacaoString.CapitalizarPrimeiraLetra`

- `"lucas"` → `"Lucas"`
- `"LUCAS"` → `"LUCAS"` (documentar se transforma ou não)
- `null` → `ArgumentNullException`
- `""` → `ArgumentException` ou `""` (decidir e documentar)

#### `ValidacaoString.ValidarFormatoEmail`

- `"teste@dominio.com"` → `true`
- `"usuario+tag@sub.exemplo.co"` → `true`
- `"nao-e-mail"` → `false`
- `null` → `false` (ou `ArgumentNullException` — documente a escolha)

---

## 🧰 Como Executar o Projeto

1. Clone:

```bash
git clone https://github.com/seuusuario/DesafioProjeto.git
cd DesafioProjeto
```

1. Rodar o projeto (exemplo):

```bash
dotnet run --project DesafioProjeto
```

1. Rodar os testes:

```bash
dotnet test
```

1. Sugestão: abra o repositório no VS Code a partir do `.sln` (se existir) pra o OmniSharp carregar corretamente:

```bash
code DesafioProjeto.sln
```

---

## 🌲 Estrutura de Pastas (atualizada)

```bash
DesafioProjeto/
 ├─ Program.cs
 ├─ ValidacaoLista.cs
 ├─ ValidacaoString.cs
 ├─ DesafioProjeto.csproj
 └─ README.md

DesafioProjetoTests/
 ├─ ValidacaoListaTests.cs
 ├─ ValidacaoStringTests.cs
 └─ DesafioProjetoTests.csproj
```

---

## 🚀 Conclusão

Com a adição das validações de string, seu projeto cobre um conjunto maior e muito útil de utilitários que costumam ser usados em muitos sistemas (limpeza de entrada, validação de e-mail, normalização de nomes, etc.).
Documente claramente no README as decisões sobre:

- lançar exceção vs retornar booleano,
- comportamento com strings vazias,
- regras de capitalização.

---

### 🧾 Badges sugeridos (copiar pro topo do README)

```markdown
![.NET](https://img.shields.io/badge/.NET-8.0-blue)
![xUnit](https://img.shields.io/badge/Tests-xUnit-brightgreen)
![Status](https://img.shields.io/badge/Status-Em%20Desenvolvimento-yellow)
```

---
