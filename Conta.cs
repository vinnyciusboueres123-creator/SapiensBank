using System.Text.Json.Serialization;

public class Conta
{
    public int Numero { get; set; }
    public string Cliente { get; set; }
    public string Cpf { get; set; }
    public string Senha { get; set; }
    public decimal Saldo { get; set; }
    public decimal Limite { get; set; }
    public decimal Saque { get; set; }
    public decimal Deposito { get; set; }
    public decimal SaldoDisponivel { get; set; }
    
    [JsonIgnore]
    public decimal SaldoDisponível => Saldo + Limite;

    public Conta(int numero, string cliente, string cpf, string senha, decimal limite = 0)
    {
        Numero = numero;
        Cliente = cliente;
        Cpf = cpf;
        Senha = senha;
        Limite = limite;
    }
    public Conta(decimal saque, decimal deposito, decimal saldoDisponivel)
    {
        Saque = saque;
        Deposito = deposito;
        SaldoDisponivel = saldoDisponivel;

        Cliente = string.Empty;
        Cpf = string.Empty;
        Senha = string.Empty;
    }
}
