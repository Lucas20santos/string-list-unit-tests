namespace DesafioProjeto.Services
{
    public class ValidacoesString
    {
        public int RetornarQuantidadeCaracteres(string texto) => string.IsNullOrEmpty(texto) ? 0 : texto.Length;
        public bool ContemCaractere(string texto, string textoProcurado) => !string.IsNullOrEmpty(texto) && !string.IsNullOrEmpty(textoProcurado) && texto.Contains(textoProcurado);
        public bool TextoTerminaCom(string texto, string textoProcurado) => !string.IsNullOrEmpty(texto) && !string.IsNullOrEmpty(textoProcurado) && texto.EndsWith(textoProcurado);
    }
}