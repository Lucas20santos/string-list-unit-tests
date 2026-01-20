using DesafioProjeto.Services;

namespace DesafioProjetoTests
{
    public class ValidacaoListaTests
    {
        private readonly ValidacoesLista _validacoes;

        public ValidacaoListaTests()
        {
            _validacoes = new ValidacoesLista();
        }
        // ========= Inicio dos Testes para Testar o Método Remover Numeros Negativos =========
        public static IEnumerable<object[]> ListasDeTesteNumerosNegativos => new List<object[]>
        {
            new object[] {new List<int> {5, 6, 7, -8, 9},                           new List<int> {5, 6, 7, 9}},
            new object[] {new List<int> {1, 2, 3, 4},                               new List<int> {1, 2, 3, 4} },
            new object[] {new List<int> {-1, -2, -3},                               new List<int>() },
            new object[] {new List<int> {-1, 0, 1},                                 new List<int> {0, 1} },
            new object[] {new List<int> (),                                         new List<int>() },
            new object[] {new List<int> {-1, 2, 3, 3, -4, 3},                       new List<int> {2, 3, 3, 3} },
            new object[] { new List<int> {int.MinValue, -1, 0, 1, int.MaxValue},    new List<int> {0, 1, int.MaxValue}}
        };

        [Theory]
        [MemberData(nameof(ListasDeTesteNumerosNegativos))]
        public void RemoverNumerosNegativos_DeveRetornarUmaListaSemNumerosNegativo_QuandoPassadoListaContendoNumeroNegativoOuNao
        (List<int> listaOrginal, List<int> listaEsperada)
        {
            // Arrange
            // Act
            var resultado = _validacoes.RemoverNumerosNegativos(listaOrginal);

            // Assert
            Assert.Equal(listaEsperada, resultado);
        }
        [Fact]
        public void ObterSomenteNumerosPositivos_DeveLancarExcecao_QuandoListaForNula()
        {
            // Arrange
            List<int> lista = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _validacoes.RemoverNumerosNegativos(lista!));
        }
        // ========= Final dos Testes para Testar o Método Remover Numeros Negativos =========

        // ========= Inicio dos Testes para Testar o Método que verifica se contem numero na lista =========        
        public static IEnumerable<object[]> ListaDeTesteContemNumeroTrue => new List<object[]>
        {
            new object[] { new List<int> {1, 2, 3}, 2},
            new object[] { new List<int> {5, 5, 5}, 5},
            new object[] { new List<int> {0, 1, 2}, 0},
            new object[] { new List<int> {-5, -4, -6}, -4},
            new object[] { new List<int> {int.MinValue, int.MaxValue}, int.MaxValue},
            new object[] { new List<int> {int.MinValue, 0, 1}, int.MinValue }
        };
        [Theory]
        [MemberData(nameof(ListaDeTesteContemNumeroTrue))]
        public void ListaContemDeterminadoNumero_DeveRetornarVerdadeiro_QuandoNumeroPassadoConterNaLista
        (List<int> listaPassada, int valor)
        {
            // Arrange
            // Act
            var resultado = _validacoes.ListaContemDeterminadoNumero(listaPassada, valor);

            // Assert
            Assert.True(resultado);
        }
        public static IEnumerable<object[]> ListaDeTesteContemNumeroFalse => new List<object[]>
        {
            new object[] { new List<int> {1, 2, 3}, 4},
            new object[] { new List<int> (), 1},
            new object[] { new List<int> {-1, -2, -3}, 3},
            new object[] { new List<int> {5, 4, 6}, -4},
            new object[] { new List<int> {1, 2, 3}, 0},
            new object[] { new List<int> {1, 2, 3, 4, 5}, 6 }
        };
        [Theory]
        [MemberData(nameof(ListaDeTesteContemNumeroFalse))]
        public void ListaContemDeterminadoNumero_DeveRetornarFalso_QuandoNumeroPassadoConterNaLista
        (List<int> listaPassada, int valor)
        {
            // Arrange
            // Act
            var resultado = _validacoes.ListaContemDeterminadoNumero(listaPassada, valor);

            // Assert
            Assert.False(resultado);
        }
        [Fact]
        public void ListaContemDeterminadoNumero_DeveLancarExcecao_QuandoListaForNula()
        {
            // Arrange
            List<int> lista = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _validacoes.ListaContemDeterminadoNumero(lista, 5));
        }
        // ========= Final dos Testes para Testar o Método Remover Numeros Negativos =========

        // #######################################################################################################################
        public static IEnumerable<object[]> ListaDeTesteMultiplicarTodosElementosPorUmNumero => new List<object[]>
        {
            new object[] { new List<int> { 2, 3, 4 }, 2, new List<int> { 4, 6, 8 } },
            new object[] { new List<int> { 5 }, 3, new List<int> { 15 } },
            new object[] { new List<int> { 2, 0, 4 }, 5, new List<int> { 10, 0, 20 } },
            new object[] { new List<int>(), 10, new List<int>() },
            new object[] { new List<int> { -2, 3, 4 }, 2, new List<int> { -4, 6, 8 } },
            new object[] { new List<int> { -2, -3, 4 }, 3, new List<int> { -6, -9, 12 } },
            new object[] { new List<int> { -2, -3, -4 }, -1, new List<int> { 2, 3, 4 } },
            new object[] { new List<int> { 1000, 2000, 3000 }, 2, new List<int> { 2000, 4000, 6000 } },
            new object[] { new List<int> { 2, 2, 2 }, 2, new List<int> { 4, 4, 4 } },
            new object[] { new List<int> { 2, 3, 4 }, 0, new List<int> { 0, 0, 0 } }
        };

        [Theory]
        [MemberData(nameof(ListaDeTesteMultiplicarTodosElementosPorUmNumero))]
        public void MultiplicarNumeroDaLista_DeveRetornarUmaListaComElementosMultiplicadosPeloNumero(
            List<int> lista, int numero, List<int> resultadoEsperado)
        {
            // Arrange
            // Act
            var resultado = _validacoes.MultiplicarNumerosLista(lista, numero);

            // Assert
            Assert.Equal(resultadoEsperado, resultado);
        }
        [Fact]
        public void MultiplicarNumeroDaLista_DeveLancarExcecao_QuandoListaForNula()
        {
            // Arrange
            List<int> lista = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _validacoes.MultiplicarNumerosLista(lista, 5));
        }

        // #######################################################################################################################
        public static IEnumerable<object[]> ListaDeTestDeNumerosParaRetornarOMaior => new List<object[]>
        {
            new object[] {new List<int> { 1, 2, 3, 4, 5}, 5 },
            new object[] {new List<int> { -10, -5, -3, -8}, -3 },
            new object[] {new List<int> { -2, 7, 0, -1}, 7 },
            new object[] {new List<int> { 9 }, 9 },
            new object[] {new List<int> { 2, 2, 2, 2 }, 2 },
            new object[] {new List<int> { 1000, 5000, 3000 }, 5000}
        };
        [Theory]
        [MemberData(nameof(ListaDeTestDeNumerosParaRetornarOMaior))]
        public void RetornarMaiorNumeroLista_DeveRetornarMaiorValor_QuandoPassadoListaDeNumero(List<int> lista, int resultadoEsperado)
        {
            // Arrange
            // Act
            var resultado = _validacoes.RetornarMaiorNumeroLista(lista);

            // Assert
            Assert.Equal(resultadoEsperado, resultado);
        }
        [Fact]
        public void RetornarMaiorNumeroLista_DeveRetornarExcecoes_QuandoPassadoListaDeNumeroNula()
        {
            // Arrange
            List<int> lista = null;


            // Act
            var excessao = Assert.Throws<ArgumentException>(() => _validacoes.RetornarMaiorNumeroLista(lista));

            // Assert
            Assert.Equal("Lista nula ou vazia", excessao.Message);
        }
        [Fact]
        public void RetornarMaiorNumeroLista_DeveRetornarExcecoes_QuandoPassadoListaDeNumeroVazia()
        {
            // Arrange
            List<int> lista = new List<int> { };

            // Act
            var excessao = Assert.Throws<ArgumentException>(() => _validacoes.RetornarMaiorNumeroLista(lista));

            // Assert
            Assert.Equal("Lista nula ou vazia", excessao.Message);
        }

        // #######################################################################################################################
        public static IEnumerable<object[]> ListaDeTestDeNumerosParaRetornarOMenor => new List<object[]>
        {
            new object[] {new List<int> { 1, 2, 3, 4, 5}, 1 },
            new object[] {new List<int> { -10, -5, -3, -8}, -10 },
            new object[] {new List<int> { -2, 7, 0, -1}, -2 },
            new object[] {new List<int> { 9 }, 9 },
            new object[] {new List<int> { 2, 2, 2, 2 }, 2 },
            new object[] {new List<int> { 1000, 5000, 3000 }, 1000}
        };
        [Theory]
        [MemberData(nameof(ListaDeTestDeNumerosParaRetornarOMaior))]
        public void RetornarMenorNumeroLista_DeveRetornarMenorValor_QuandoPassadoListaDeNumero(List<int> lista, int resultadoEsperado)
        {
            // Arrange
            // Act
            var resultado = _validacoes.RetornarMaiorNumeroLista(lista);

            // Assert
            Assert.Equal(resultadoEsperado, resultado);
        }
        [Fact]
        public void RetornarMenorNumeroLista_DeveRetornarExcecoes_QuandoPassadoListaDeNumeroNula()
        {
            // Arrange
            List<int> lista = null;


            // Act
            var excessao = Assert.Throws<ArgumentException>(() => _validacoes.RetornarMaiorNumeroLista(lista));

            // Assert
            Assert.Equal("Lista nula ou vazia", excessao.Message);
        }
        [Fact]
        public void RetornarMenorNumeroLista_DeveRetornarExcecoes_QuandoPassadoListaDeNumeroVazia()
        {
            // Arrange
            List<int> lista = new List<int> { };

            // Act
            var excessao = Assert.Throws<ArgumentException>(() => _validacoes.RetornarMaiorNumeroLista(lista));

            // Assert
            Assert.Equal("Lista nula ou vazia", excessao.Message);
        }
    }
}