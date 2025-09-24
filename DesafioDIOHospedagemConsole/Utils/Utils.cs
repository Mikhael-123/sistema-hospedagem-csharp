using DesafioDIOHospedagemConsole.Models;

namespace DesafioDIOHospedagemConsole.Utils;

public class Utils
{
  public void Titulo(string titulo)
  {
    Console.WriteLine($"------------ {titulo} ------------");
  }
  public void Etapa1(Reserva reserva)
  {
    Titulo("Bem Vindo ao Hotel!");
    Console.WriteLine("Deseja se hospedar sozinho ou com mais pessoas?");
    Console.WriteLine("1. Somente eu");
    Console.WriteLine("2. Eu e mais pessoas");
    int opcaoEscolhidaPessoas = Convert.ToInt32(Console.ReadLine());
    Console.Clear();;
    int numeroPessoas = 1;

    if (opcaoEscolhidaPessoas == 2)
    {
      Titulo("Quantidade de Hospedes");
      Console.WriteLine("Quantas pessoas irão se hospedar?");
      int numeroPessoasConsole = Convert.ToInt32(Console.ReadLine());

      while (numeroPessoasConsole > 4)
      {
        Console.WriteLine("A quantidade máxima de hospedes é 4. Escreva um outro número");
        numeroPessoasConsole = Convert.ToInt32(Console.ReadLine());
      }

      numeroPessoas = numeroPessoasConsole;
    }

    List<Pessoa> listaPessoas = new List<Pessoa>();
    while (listaPessoas.Count < numeroPessoas)
    {
      Titulo("Cadastro de pessoas");
      Console.WriteLine($"Pessoa {listaPessoas.Count + 1}");
      Console.WriteLine("Informe o nome:");
      string nomePessoaConsole = Console.ReadLine();
      Console.WriteLine("Informe o sobrenome:");
      string sobrenomePessoaConsole = Console.ReadLine();

      Pessoa novaPessoa = new Pessoa(nomePessoaConsole, sobrenomePessoaConsole);
      listaPessoas.Add(novaPessoa);
    }
    reserva.CadastrarHospedes(listaPessoas);
    Console.Clear();;
  }
  public int Etapa2(Reserva reserva, List<Suite> suitesDisponiveis)
  {
    Titulo("Categoria de Suíte");
    Console.WriteLine("Que tipo de suíte você deseja?");
    Console.WriteLine("1. Premium");
    Console.WriteLine("2. Básica");
    int opcaoEscolhidaSuite = Convert.ToInt32(Console.ReadLine());
    Console.Clear();;
    string tipoSuite = "";

    switch (opcaoEscolhidaSuite)
    {
      case 1:
        tipoSuite = "Premium";
        break;
      case 2:
        tipoSuite = "Básica";
        break;
      default:
        break;
    }
    List<Suite> suitesFiltradas = suitesDisponiveis.FindAll(suite => Convert.ToBoolean(suite.Tipo == tipoSuite));
    Console.Clear();;

    Titulo("Suítes disponíveis:");
    for (int i = 0; i < suitesFiltradas.Count; i++)
    {
      Suite suite = suitesFiltradas[i];
      Console.WriteLine($"{i + 1}.");
      Console.WriteLine($"Tipo: {suite.Tipo}");
      Console.WriteLine($"Capacidade: {suite.Capacidade}");
      Console.WriteLine($"Valor da diária: {suite.ValorDiaria.ToString("C2")}");
    }

    Console.WriteLine("");
    Console.WriteLine("Escreva o número da suíte que você deseja:");
    int opcaoEscolhidaNumeroSuite = Convert.ToInt32(Console.ReadLine());
    Suite suiteEscolhida = suitesFiltradas[opcaoEscolhidaNumeroSuite - 1];

    while (reserva.Hospedes.Count() > suiteEscolhida.Capacidade)
    {
      Console.WriteLine($"O número de pessoas atual ({reserva.Hospedes.Count()}) excede a capacidade máxima da suíte. Por favor escolha uma outra suíte");
      opcaoEscolhidaNumeroSuite = Convert.ToInt32(Console.ReadLine());
      suiteEscolhida = suitesFiltradas[opcaoEscolhidaNumeroSuite - 1];
    }

    reserva.CadastrarSuite(suiteEscolhida);
    Console.Clear();;
    return opcaoEscolhidaNumeroSuite;
  }

  public void Etapa3(Reserva reserva)
  {
    Titulo("Tempo de hospedagem");
    Console.WriteLine("Por quantos dias você deseja ficar hospedado?");
    int diasReservadosConsole = Convert.ToInt32(Console.ReadLine());
    reserva.DiasReservados = diasReservadosConsole;
    Console.Clear();;
  }
}
