using SistemaBancario;

Titular t1 = new("Renan Aguiar", "133.729.497-73", "Rua Edessa, 10 - Cariacica ES");
Titular t2 = new("Lorraine Vieira", "159.003.187-37", "Rua da União, 130 - Venda Nova do Imigrante ES");

ContaBancaria c1 = new(t1, 123);
ContaBancaria c2 = new(t2, 456, 1500);

ContaBancaria contaLogada = null;

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
    Console.Clear();
    ExibirLogo();
    Console.WriteLine("\nBem-vindo(a) ao caixa eletrônico do RS Bank. O que deseja fazer?");
    Console.WriteLine("\n[1] - Acessar sua conta bancária");
    Console.WriteLine("[0] - Encerrar o programa");
    Console.Write("\nSua opção: ");
    int op = int.Parse(Console.ReadLine()!);
    if(op == 1)
    {
        Console.Clear();
        ExibirTituloFormatado("ÁREA DE LOGIN");
        Console.Write("\nCPF: ");
        string cpf = Console.ReadLine()!;
        Console.Write("Número da conta: ");
        int num = int.Parse(Console.ReadLine()!);

        Console.WriteLine("\nCarregando... Por favor aguarde...");
        Thread.Sleep(3000);

        if (t1.Cpf == cpf && c1.NumeroConta == num)
        {
            contaLogada = c1;
            Console.WriteLine($"\nAcesso autorizado. Seja bem-vindo(a) {t1.Nome}");
            Thread.Sleep(3000);
            Console.Clear();
            ExibirMenu();
        }
        else if (t2.Cpf == cpf && c2.NumeroConta == num)
        {
            contaLogada = c2;
            Console.WriteLine($"\nAcesso autorizado. Seja bem-vindo(a) {t2.Nome}");
            Thread.Sleep(3000);
            Console.Clear();
            ExibirMenu();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("\nConta não encontrada na base de dados. Acesso negado.");
            Thread.Sleep(3000);
            ExibirInterfaceInicial();
        }
    }
    else
    {
        Console.WriteLine("\nVocê escolheu sair. Programa finalizado.");
        Thread.Sleep(3000);
    }
}

void ExibirMenu()
{
    ExibirLogo();
    ExibirTituloFormatado("CAIXA ELETRÔNICO - MENU");
    Console.WriteLine("\n[1] - Depósito");
    Console.WriteLine("[2] - Saque");
    Console.WriteLine("[3] - Extrato");
    Console.WriteLine("[4] - Transferência");
    Console.WriteLine("[5] - Exibir informações da conta");
    Console.WriteLine("[0] - Sair");

    Console.Write("\nDigite sua opção: ");
    int opcao = int.Parse(Console.ReadLine()!);
    switch (opcao)
    {
        case 1: EfetuarDeposito();
            break;
        case 2: EfetuarSaque();
            break;
        case 3: ListarHistoricoDeTransacoes();
            break;
        case 4: Transferencia();
            break;
        case 5: ExibirDadosDaConta();
            break;
        case 0: Console.WriteLine("Você escolheu sair. Fim do programa.");
            break;
        default:
            Console.WriteLine("Opção inválida. Fim do programa");
            break;
    }
}

void ExibirTituloFormatado(string titulo)
{
    int qtdLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(qtdLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos);
}

void EfetuarDeposito()
{
    Console.Clear();
    ExibirTituloFormatado("DEPÓSITO");
    Console.Write("\nQual a quantia que deseja depositar? ");
    double quantia = double.Parse(Console.ReadLine()!);
    contaLogada.Depositar(quantia);
    Thread.Sleep(3000);
    Console.Clear();
    ExibirMenu();
}

void EfetuarSaque()
{
    Console.Clear();
    ExibirTituloFormatado("SAQUE");
    Console.WriteLine("O RS Bank cobra uma taxa de 1% sobre o valor do saque.");
    Console.Write("\nQual a quantia que deseja sacar? ");
    double quantia = double.Parse(Console.ReadLine()!);
    contaLogada.Sacar(quantia);
    Thread.Sleep(3000);
    Console.Clear();
    ExibirMenu();
}

void ListarHistoricoDeTransacoes()
{
    Console.Clear();
    ExibirTituloFormatado("EXTRATO");
    contaLogada.ExibirExtrato();
    Console.WriteLine("\nDigite uma tecla para voltar ao menu.");
    Console.ReadKey();
    Console.Clear();
    ExibirMenu();
}

void Transferencia()
{
    Console.Clear();
    ExibirTituloFormatado("TRANSFERÊNCIA");
    Console.Write("Número da conta: ");
    int num = int.Parse(Console.ReadLine()!);
    if (c2.NumeroConta == num)
    {
        Console.WriteLine($"\nTransferência: {c1.Titular.Nome} => {c2.Titular.Nome}\n");
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
    ExibirTituloFormatado("DADOS DA CONTA");
    contaLogada.ExibirDadosDaConta();
    Console.WriteLine("\nDigite uma tecla para voltar ao menu.");
    Console.ReadKey();
    Console.Clear();
    ExibirMenu();
}

ExibirInterfaceInicial();