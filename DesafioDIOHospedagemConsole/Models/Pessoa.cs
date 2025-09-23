namespace DesafioDIOHospedagemConsole.Models;

public class Pessoa
{
  public Pessoa(string nome, string sobrenome)
  {
    Nome = nome;
    Sobrenome = sobrenome;
  }

  public string Nome { get; set; }
  public string Sobrenome { get; set; }
}
