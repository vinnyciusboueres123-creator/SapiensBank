using static System.Console ;

namespace SapiensBank;

public class Screen
{
    private readonly Banco _banco;
    private readonly string _titulo = " Sapiens Bank";

    public Screen(Banco banco)
    {
        _banco = banco;
    }

    public void MenuPrincipal()
    {
        CriarTitulo(_titulo);
        WriteLine(" [1] Criar Conta");
        WriteLine(" [2] Listar Contas");
        WriteLine(" [3] Efetuar Saque");
        WriteLine(" [4] Efetuar Depósito");
        ForegroundColor = ConsoleColor.Red;
        WriteLine("\n [9] Sair");
        ForegroundColor = ConsoleColor.White;
        CriarLinha();
        ForegroundColor = ConsoleColor.Yellow;
        Write(" Digite a opção desejada: ");
        var opcao = ReadLine() ?? "";
        ForegroundColor = ConsoleColor.White;
        switch (opcao)
        {
            case "1": MenuCriarConta(); break;
            case "2": MenuListarContas(); break;
        }
        if (opcao != "9")
        {
            MenuPrincipal();
        }
        _banco.SaveContas();
    }

    public void MenuCriarConta()
    {
        CriarTitulo(_titulo + " - Criar Conta");
        Write(" Numero:  ");
        var numero = Convert.ToInt32(ReadLine());
        Write(" Cliente: ");
        var cliente = ReadLine() ?? "";
        Write(" CPF:     ");
        var cpf = ReadLine() ?? "";
        Write(" Senha:   ");
        var senha = ReadLine() ?? "";
        Write(" Limite:  ");
        var limite = Convert.ToDecimal(ReadLine());

        var conta = new Conta(numero, cliente, cpf, senha, limite);
        _banco.Contas.Add(conta);

        CriarLinha();
        ForegroundColor = ConsoleColor.Green;
        Write(" Conta criada com sucesso! \n [ENTER] para continuar");
        ForegroundColor = ConsoleColor.White;
        ReadLine();
        MenuPrincipal();
    }

    public void MenuListarContas()
    {
        CriarTitulo(_titulo + " - Listar Contas");
        foreach (var conta in _banco.Contas)
        {
            WriteLine($" Conta: {conta.Numero} - {conta.Cliente}");
            WriteLine($" Saldo: {conta.Saldo:C} | Limite: {conta.Limite:C}");
            WriteLine($" Saldo Disponível: {conta.SaldoDisponível:C}\n");
        }

        CriarLinha();
        ForegroundColor = ConsoleColor.Green;
        Write(" [ENTER] para continuar");
        ForegroundColor = ConsoleColor.White;
        ReadLine();
        MenuPrincipal();
    }

    public string CriarMenu(string titulo)
    {
        CriarTitulo(titulo);
        WriteLine(" [1] Criar Conta");
        WriteLine(" [2] Listar Contas");
        WriteLine(" [3] Efetuar Saque");
        WriteLine(" [4] Efetuar Depósito");
        WriteLine("\n [9] Sair");
        CriarLinha();
        Write(" Digite a opção desejada: ");
        return ReadLine() ?? "";
    }

    public void CriarLinha()
    {
        WriteLine("-------------------------------------------------");
    }

    public void CriarTitulo(string titulo)
    {
        Clear();
        ForegroundColor = ConsoleColor.White;
        CriarLinha();
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine(titulo);
        ForegroundColor = ConsoleColor.White;
        CriarLinha();

    }

    

}
