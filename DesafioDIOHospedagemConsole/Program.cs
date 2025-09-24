using DesafioDIOHospedagemConsole.Models;

// Suites disponíveis
List<Suite> suitesDisponiveis = new List<Suite>
{
  new Suite(tipoSuite: "Premium", capacidade: 1, valorDiaria: 350.00m),
  new Suite(tipoSuite: "Premium", capacidade: 1, valorDiaria: 360.00m),
  new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 500.00m),
  new Suite(tipoSuite: "Premium", capacidade: 3, valorDiaria: 600.00m),
  new Suite(tipoSuite: "Premium", capacidade: 4, valorDiaria: 750.00m),
  new Suite(tipoSuite: "Básica", capacidade: 1, valorDiaria: 150.00m),
  new Suite(tipoSuite: "Básica", capacidade: 1, valorDiaria: 160.00m),
  new Suite(tipoSuite: "Básica", capacidade: 2, valorDiaria: 200.00m),
  new Suite(tipoSuite: "Básica", capacidade: 3, valorDiaria: 250.00m),
  new Suite(tipoSuite: "Básica", capacidade: 4, valorDiaria: 300.00m),
};
// Variável que vai guardar a reserva que vai ser feita
Reserva reserva = new Reserva();

Console.WriteLine("Bem Vindo ao Hotel!");
Console.WriteLine("Deseja se hospedar sozinho ou com mais pessoas?");
Console.WriteLine("1. Somente eu");
Console.WriteLine("2. Eu e mais pessoas");
int opcaoEscolhidaPessoas = Convert.ToInt32(Console.ReadLine());
Console.Clear();
int numeroPessoas = 1;

if (opcaoEscolhidaPessoas == 2)
{
  // Só executar esta linha se a opção 2 for escolhida
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
  Console.WriteLine("Cadastro de pessoas");
  Console.WriteLine($"Pessoa {listaPessoas.Count + 1}");
  Console.WriteLine("Informe o nome:");
  string nomePessoaConsole = Console.ReadLine();
  Console.WriteLine("Informe o sobrenome:");
  string sobrenomePessoaConsole = Console.ReadLine();

  Pessoa novaPessoa = new Pessoa(nomePessoaConsole, sobrenomePessoaConsole);
  listaPessoas.Add(novaPessoa);
}
reserva.CadastrarHospedes(listaPessoas);
Console.Clear();

Console.WriteLine("Que tipo de suíte você deseja?");
Console.WriteLine("1. Premium");
Console.WriteLine("2. Básica");
int opcaoEscolhidaSuite = Convert.ToInt32(Console.ReadLine());
Console.Clear();
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
Console.WriteLine("Suítes disponíveis:");
for (int i = 0; i < suitesFiltradas.Count; i++)
{
  Suite suite = suitesFiltradas[i];
  Console.WriteLine("");
  Console.WriteLine($"{i + 1}.");
  Console.WriteLine($"Tipo: {suite.Tipo}");
  Console.WriteLine($"Capacidade: {suite.Capacidade}");
  Console.WriteLine($"Valor da diária: {suite.ValorDiaria.ToString("C2")}");
}

Console.WriteLine("Escreva o número da suíte que você deseja:");
int opcaoEscolhidaNumeroSuite = Convert.ToInt32(Console.ReadLine());
Suite suiteEscolhida = suitesFiltradas[opcaoEscolhidaNumeroSuite - 1];

while (reserva.Hospedes.Count() > suiteEscolhida.Capacidade)
{
  Console.WriteLine($"O número de pessoas atual {reserva.Hospedes.Count()} excede a capacidade máxima da suíte. Ppor favor escolha uma outra suíte");
  opcaoEscolhidaNumeroSuite = Convert.ToInt32(Console.ReadLine());
  suiteEscolhida = suitesFiltradas[opcaoEscolhidaNumeroSuite - 1];
}

reserva.CadastrarSuite(suiteEscolhida);
Console.Clear();

Console.WriteLine("Por quantos dias você deseja ficar hospedado?");
int diasReservadosConsole = Convert.ToInt32(Console.ReadLine());
reserva.DiasReservados = diasReservadosConsole;
Console.Clear();

Console.WriteLine("Reserva Feita!");
Console.WriteLine("");
Console.WriteLine($"Pessoas cadastradas ({reserva.ObterQuantidadeHospedes()}):");
foreach (Pessoa pessoa in reserva.Hospedes)
{
  Console.WriteLine($"Nome: {pessoa.Nome}");
  Console.WriteLine($"Sobrenome: {pessoa.Sobrenome}");
}
Console.WriteLine("");
Console.WriteLine($"Suite Nº {opcaoEscolhidaNumeroSuite}");
Console.WriteLine($"Tipo: {reserva.Suite.Tipo}");
Console.WriteLine($"Capacidade: {reserva.Suite.Capacidade}");
Console.WriteLine($"Valor da diaria: {reserva.Suite.ValorDiaria.ToString("C2")}");
Console.WriteLine("");
Console.WriteLine($"Dias reservados: {reserva.DiasReservados}");
Console.WriteLine($"Valor total: {reserva.CalcularValorDiaria().ToString("C2")}");