using System.Globalization;

namespace SistemaBancario
{
    class ContaBancaria
    {
        public Titular Titular { get; set; }
        public int NumeroConta { get; set; }
        public double Saldo { get; private set; }
        private List<Transacao> HistoricoTransacoes = new();

        public ContaBancaria(Titular titular, int numeroConta, double saldo = 0)
        {
            Titular = titular;
            NumeroConta = numeroConta;
            Saldo = saldo;
            HistoricoTransacoes = new List<Transacao>();
        }

        public void Depositar(double quantia)
        {
            if (quantia > 0)
            {
                Saldo += quantia;
                Console.WriteLine($"\nDepósito no valor de R${quantia.ToString("F2", CultureInfo.InvariantCulture)} realizado.");
                HistoricoTransacoes.Add(new Transacao(DateTime.Now, "Depósito", quantia));
            }
            else
            {
                Console.WriteLine("\nO valor de depósito deve ser maior que zero.");
            }
        }

        public void Sacar(double quantia)
        {
            if (quantia > 0 && quantia <= Saldo)
            {
                double taxa = quantia * 0.01;
                double total = quantia + taxa;

                Saldo -= total;
                Console.WriteLine($"\nSaque no valor de R${quantia.ToString("F2", CultureInfo.InvariantCulture)} realizado.");
                HistoricoTransacoes.Add(new Transacao(DateTime.Now, "Saque", quantia));
            }
            else
            {
                Console.WriteLine($"\nNão foi possível realizar o saque de R${quantia:F2}. Saldo insuficiente.");
            }
        }

        public void ExibirDadosDaConta()
        {
            Console.WriteLine($"\nTitular: {Titular.Nome.ToUpper()}");
            Console.WriteLine($"CPF: {Titular.Cpf}");
            Console.WriteLine($"Endereço: {Titular.Endereco.ToUpper()}");
            Console.WriteLine($"Número da conta: {NumeroConta}");
            Console.WriteLine($"Saldo: R$ {Saldo.ToString("F2", CultureInfo.InvariantCulture)}");
        }

        public void ExibirExtrato()
        {
            if (HistoricoTransacoes.Count == 0)
            {
                Console.WriteLine("\nNenhuma transação foi efetuada até o momento.");
            }
            else
            {
                Console.Write("\nQual o tipo de transação? (Depósito/Saque/Transferência): ");
                string tipo = Console.ReadLine();
                if (tipo == "Depósito" || tipo == "Saque" || tipo == "Transferência")
                {
                    var filtradas = HistoricoTransacoes.Where(t => t.Tipo == tipo);
                    if (!filtradas.Any())
                    {
                        Console.WriteLine($"\nNenhuma transação do tipo {tipo} encontrada.");
                    }
                    else
                    {
                        foreach (var t in filtradas)
                        {
                            Console.WriteLine($"\n- {t.Data:dd/MM/yyyy HH:mm} - {t.Tipo} de R$ {t.Valor.ToString("F2", CultureInfo.InvariantCulture)}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nOpção inválida");
                }
            }
        }

        public void Transferir(ContaBancaria conta, double quantia)
        {
            if (quantia > 0 && quantia <= Saldo)
            {
                Saldo -= quantia;
                Console.WriteLine($"\nTransferência de R$ {quantia.ToString("F2", CultureInfo.InvariantCulture)} para a conta nº {conta.NumeroConta} - {conta.Titular.Nome} realizada.");
                HistoricoTransacoes.Add(new Transacao(DateTime.Now, "Transferência", quantia));
            }
            else
            {
                Console.WriteLine("\nQuantia solicitada para transferência é inválida.");
            }
        }
    }

    public class Transacao
    {
        public DateTime Data { get; }
        public string Tipo { get; }
        public double Valor { get; }

        public Transacao(DateTime data, string tipo, double valor)
        {
            Data = data;
            Tipo = tipo;
            Valor = valor;
        }
    }
}