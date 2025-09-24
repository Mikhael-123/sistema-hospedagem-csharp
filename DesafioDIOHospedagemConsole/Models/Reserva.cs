namespace DesafioDIOHospedagemConsole.Models;

public class Reserva
{
  public List<Pessoa> Hospedes { get; set; }
  public Suite Suite { get; set; }
  public int DiasReservados { get; set; }
  public decimal CalcularValorDiaria()
  {
    if (DiasReservados >= 10)
    {
      double porcentagem = Convert.ToDouble(Suite.ValorDiaria * DiasReservados) * 0.1;
      Console.WriteLine($"Desconto de 10 dias: {porcentagem.ToString("C2")}");
      return Suite.ValorDiaria * DiasReservados - Convert.ToDecimal(porcentagem);
    }
    else
    {
      return Suite.ValorDiaria * DiasReservados;
    }
  }
  public void CadastrarHospedes(List<Pessoa> hospedes)
  {
    Hospedes = hospedes;
  }
  public void CadastrarSuite(Suite suite)
  {
    Suite = suite;
  }
  public int ObterQuantidadeHospedes()
  {
    return Hospedes.Count;
  }
}
