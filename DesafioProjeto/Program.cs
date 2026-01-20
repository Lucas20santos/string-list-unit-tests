using DesafioProjeto.Services;

ValidacoesLista vl = new ValidacoesLista();

// Achar numero dentro da lista
Console.WriteLine(vl.ListaContemDeterminadoNumero([1, 2, 3, 4, 5], 4));


// Retornar lista sem numero negativo
foreach (var item in vl.RemoverNumerosNegativos([-1, 2, 3, -5]))
{
    Console.Write(item + " ");
}
Console.WriteLine();
