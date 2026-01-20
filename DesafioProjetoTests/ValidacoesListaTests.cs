using DesafioProjeto.Services;

namespace DesafioProjetoTests
{
    public class ValidacoesListaTests
    {
        private readonly ValidacoesString _validaString = new ValidacoesString();

        [Theory]
        [InlineData("Hello")]
        [InlineData("Helllo World")]
        public void RetornarQuantidadeCaracteres_DeveRetornar_TamanhoCorretoDaString(string texto)
        {
            // Arrange
            int quantidadeEsperada = texto.Length;

            // Act
            int resultado = _validaString.RetornarQuantidadeCaracteres(texto);

            // Assert
            Assert.Equal(quantidadeEsperada, resultado);
        }

        [Theory]
        [InlineData("Hello World")]
        [InlineData("Hello")]
        public void ContemCaractere_DeveRetornarVerdadeiro_QuandoForPassadoOCaracterNeleContido(string texto)
        {
            // Arrange
            string trechoProcurado = "Hel";

            // Act
            bool contem = _validaString.ContemCaractere(texto, trechoProcurado);

            // Assert
            Assert.True(contem);
        }

        [Theory]
        [InlineData("Testando")]
        public void ContemCaractere_DeveRetornarFalso_QuandoForPassadoOCaracterNeleContido(string texto)
        {
            // Arrange
            string trechoProcurado = "xlc";

            // Act
            bool contem = _validaString.ContemCaractere(texto, trechoProcurado);

            // Assert
            Assert.False(contem);
        }
        [Theory]
        [InlineData("Hello World")]
        [InlineData("World")]
        public void TextoTerminadoCom_DeveRetornarVerdadeiro_QuandoForPassadoTrechoContidoNoFinalDaString(string texto)
        {
            // Arrange
            string trechoProcurado = "rld";

            // Act
            bool contem = _validaString.TextoTerminaCom(texto, trechoProcurado);

            // Assert
            Assert.True(contem);
        }
        [Theory]
        [InlineData("Hello World")]
        [InlineData("World")]
        public void TextoTerminadoCom_DeveRetornarFalso_QuandoForPassadoTrechoQueNaoContidoNoFinalDaString(string texto)
        {
            // Arrange
            string trechoProcurado = "Hld";

            // Act
            bool contem = _validaString.TextoTerminaCom(texto, trechoProcurado);

            // Assert
            Assert.False(contem);
        }
    }
}