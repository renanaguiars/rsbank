using SistemaBancario;

Titular titular1 = new Titular("Renan Aguiar", "111.222.333-45", "Rua das Papoulas, 10");
Titular titular2 = new Titular("Juliana Ferreira", "123.456.789-10", "Rua das Margaridas, 8");
ContaBancaria c1 = new ContaBancaria(titular1, 123, 2500.00, new List<string>());
ContaBancaria c2 = new ContaBancaria(titular2, 322, 1300.00, new List<string>());

void ExibirLogo()
{
    Console.WriteLine(@"
██████╗░░██████╗  ██████╗░░█████╗░███╗░░██╗██╗░░██╗
██╔══██╗██╔════╝  ██╔══██╗██╔══██╗████╗░██║██║░██╔╝
██████╔╝╚█████╗░  ██████╦╝███████║██╔██╗██║█████═╝░
██╔══██╗░╚═══██╗  ██╔══██╗██╔══██║██║╚████║██╔═██╗░
██║░░██║██████╔╝  ██████╦╝██║░░██║██║░╚███║██║░╚██╗
╚═╝░░╚═╝╚═════╝░  ╚═════╝░╚═╝░░╚═╝╚═╝░░╚══╝╚═╝░░╚═╝
");
}

void ExibirInterfaceInicial()
{
    ExibirLogo();
    Console.Write("CPF: ");
    string cpf = Console.ReadLine()!;
    Console.Write("Número da conta: ");
    int num = int.Parse(Console.ReadLine()!);
    if (titular1.Cpf == cpf && c1.NumeroConta == num)
    {
        Console.WriteLine("Acesso autorizado.");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirMenu();
    }
    else
    {
        Thread.Sleep(2000);
        Console.Clear();
        Console.WriteLine("Conta não encontrada no banco de dados. Acesso negado.");
    }
}

void ExibirMenu()
{
    ExibirLogo();
    Console.WriteLine("CAIXA ELETRÔNICO");
    Console.WriteLine("\n1 - Depósito");
    Console.WriteLine("2 - Saque");
    Console.WriteLine("3 - Listar histórico de transações");
    Console.WriteLine("4 - Transferência");
    Console.WriteLine("5 - Exibir dados da conta");
    Console.WriteLine("0 - Sair");

    Console.Write("\nDigite sua opção: ");
    int opcao = int.Parse(Console.ReadLine()!);
    switch (opcao)
    {
        case 1:
            EfetuarDeposito();
            break;
        case 2:
            EfetuarSaque();
            break;
        case 3:
            ListarHistoricoDeTransacoes();
            break;
        case 4:
            Transferencia();
            break;
        case 5:
            ExibirDadosDaConta();
            break;
        case 0:
            Console.WriteLine();
            break;
    }
}

void ExibirTituloFormatado(string titulo)
{
    int qtdLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(qtdLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void EfetuarDeposito()
{
    Console.Clear();
    ExibirTituloFormatado("Depósito");
    Console.Write("\nQual a quantia que deseja depositar? ");
    double quantia = double.Parse(Console.ReadLine()!);
    c1.Depositar(quantia);
    Thread.Sleep(1000);
    Console.Clear();
    ExibirMenu();
}

void EfetuarSaque()
{
    Console.Clear();
    ExibirTituloFormatado("Saque");
    Console.WriteLine("O RS Bank cobra uma taxa de 1% sobre o valor do saque.");
    Console.Write("\nQual a quantia que deseja sacar? ");
    double quantia = double.Parse(Console.ReadLine()!);
    c1.Sacar(quantia);
    Thread.Sleep(1000);
    Console.Clear();
    ExibirMenu();
}

void ListarHistoricoDeTransacoes()
{
    Console.Clear();
    ExibirTituloFormatado("Histórico de transações");
    c1.ExibirHistoricoDeTransacoes();
    Console.WriteLine("\nDigite uma tecla para voltar ao menu.");
    Console.ReadKey();
    Console.Clear();
    ExibirMenu();
}

void Transferencia()
{
    Console.Clear();
    ExibirTituloFormatado("Transferência");
    Console.Write("Número da conta: ");
    int num = int.Parse(Console.ReadLine()!);
    if (c2.NumeroConta == num)
    {
        Console.WriteLine($"Transferência: {c1.Titular.Nome} => {c2.Titular.Nome}\n");
        Console.Write("Quanto deseja transferir? ");
        double quantia = double.Parse(Console.ReadLine()!);
        c1.Transferir(c2, quantia);
    }
    else
    {
        Console.WriteLine("Número de conta inválido.");
    }

    Console.WriteLine("\nDigite uma tecla para voltar ao menu.");
    Console.ReadKey();
    Console.Clear();
    ExibirMenu();
}

void ExibirDadosDaConta()
{
    Console.Clear();
    ExibirTituloFormatado("Dados da Conta");
    c1.ExibirDadosDaConta();
    Console.WriteLine("\nDigite uma tecla para voltar ao menu.");
    Console.ReadKey();
    Console.Clear();
    ExibirMenu();
}

ExibirInterfaceInicial();