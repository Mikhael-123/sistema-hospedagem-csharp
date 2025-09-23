namespace DesafioDIOHospedagemConsole.Models;

public class Suite
{
  public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
  {
    Tipo = tipoSuite;
    Capacidade = capacidade;
    ValorDiaria = valorDiaria;
  }

  public string Tipo { get; set; }
  public int Capacidade { get; set; }
  public decimal ValorDiaria { get; set; }
}
