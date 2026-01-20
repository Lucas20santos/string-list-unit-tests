namespace DesafioProjeto.Services
{
    public class ValidacoesLista
    {
        public List<int> RemoverNumerosNegativos(List<int> lista) => lista == null ? throw new ArgumentNullException(nameof(lista)): lista.Where(x => x >= 0).ToList();
        public bool ListaContemDeterminadoNumero(List<int> lista, int numero) => lista == null ? throw new ArgumentNullException(nameof(lista)): lista.Contains(numero);
        public List<int> MultiplicarNumerosLista(List<int> lista, int numero) => lista == null ? throw new ArgumentNullException(nameof(lista)) : lista.Select(x => x * numero).ToList();
        public int RetornarMaiorNumeroLista(List<int> lista) => lista == null || !lista.Any() ? throw new ArgumentException("Lista nula ou vazia") : lista.Max();
        public int RetornarMenorNumeroLista(List<int> lista) => lista == null || !lista.Any() ? throw new ArgumentException("Lista nula ou vazia") : lista.Min();
    }
}