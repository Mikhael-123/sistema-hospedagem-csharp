namespace DesafioDIOHospedagemConsole.Models;

public class Reserva
{
  public Reserva(List<Pessoa> hospedes, Suite suite, int diasReservados)
  {
    Hospedes = hospedes;
    Suite = suite;
    DiasReservados = diasReservados;
  }

  public List<Pessoa> Hospedes { get; set; }
  public Suite Suite { get; set; }
  public int DiasReservados { get; set; }
  public decimal CalcularValorDiaria()
  {
    if (DiasReservados >= 10)
    {
      double porcentagem = Convert.ToDouble(Suite.ValorDiaria * DiasReservados) * 0.1;
      Console.WriteLine($"Desconto de 10 dias:");
      Console.WriteLine(porcentagem.ToString("C2"));
      return Suite.ValorDiaria * DiasReservados - Convert.ToDecimal(porcentagem);
    }
    else
    {
      return Suite.ValorDiaria * DiasReservados;
    }
  }
}
