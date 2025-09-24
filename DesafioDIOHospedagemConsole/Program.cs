using DesafioDIOHospedagemConsole.Models;
using DesafioDIOHospedagemConsole.Utils;

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
// Variável com funções uteis
Utils utils = new Utils();

int numeroSuite = 0;

utils.Etapa1(reserva);
numeroSuite = utils.Etapa2(reserva, suitesDisponiveis);
utils.Etapa3(reserva);

utils.Titulo("Reserva Feita!");
Console.WriteLine("");
Console.WriteLine($"Pessoas cadastradas ({reserva.ObterQuantidadeHospedes()}):");
for (int i = 0; i < reserva.Hospedes.Count; i++)
{
  Console.WriteLine($"Hospede {i + 1}: {reserva.Hospedes[i].NomeCompleto()}");
}
Console.WriteLine("");
Console.WriteLine($"Suite Nº {numeroSuite}");
Console.WriteLine($"Tipo: {reserva.Suite.Tipo}");
Console.WriteLine($"Capacidade: {reserva.Suite.Capacidade}");
Console.WriteLine($"Valor da diaria: {reserva.Suite.ValorDiaria.ToString("C2")}");
Console.WriteLine("");
Console.WriteLine($"Dias reservados: {reserva.DiasReservados}");
Console.WriteLine($"Valor total: {reserva.CalcularValorDiaria().ToString("C2")}");