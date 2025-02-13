using System.Globalization;

namespace SistemaBancario
{
    class ContaBancaria
    {
        public Titular Titular { get; set; }
        public int NumeroConta { get; set; }
        public double Saldo { get; private set; }
        public List<string> HistoricoTransacoes = new();

        public ContaBancaria(Titular titular, int numeroConta, double saldo, List<string> historicoTransacoes)
        {
            Titular = titular;
            NumeroConta = numeroConta;
            Saldo = saldo;
            HistoricoTransacoes = historicoTransacoes;
        }

        public void Depositar(double quantia)
        {
            if (quantia > 0.00)
            {
                Saldo += quantia;
                HistoricoTransacoes.Add($"Depósito no valor de R${quantia.ToString("F2", CultureInfo.InvariantCulture)} realizado.");
                Console.WriteLine("Operação realizada.");
            }
            else
            {
                Console.WriteLine("O valor de depósito deve ser maior que zero.");
            }
        }

        public void Sacar(double quantia)
        {
            if (quantia > 0 && quantia <= Saldo)
            {
                Saldo -= quantia + (quantia * 0.01);
                HistoricoTransacoes.Add($"Saque no valor de R${quantia.ToString("F2", CultureInfo.InvariantCulture)} realizado.");
                Console.WriteLine("Operação realizada.");
            }
            else
            {
                Console.WriteLine("Quantia solicitada é inválida.");
            }
        }

        public void ExibirDadosDaConta()
        {
            Console.WriteLine($"Titular: {Titular.Nome}");
            Console.WriteLine($"CPF: {Titular.Cpf}");
            Console.WriteLine($"Endereço: {Titular.Endereco}");
            Console.WriteLine($"Número da conta: {NumeroConta}");
            Console.WriteLine($"Saldo: R$ {Saldo.ToString("F2", CultureInfo.InvariantCulture)}");
        }

        public void ExibirHistoricoDeTransacoes()
        {
            if (HistoricoTransacoes.Count == 0)
            {
                Console.WriteLine("Nenhuma transação foi efetuada.");
            }
            else
            {
                foreach (var t in HistoricoTransacoes)
                {
                    Console.WriteLine(t);
                }
            }
        }

        public void Transferir(ContaBancaria conta, double quantia)
        {
            if (quantia > 0.00 && quantia <= Saldo)
            {
                Saldo -= quantia;
                conta.Depositar(quantia);
                HistoricoTransacoes.Add($"Transferência no valor de R$ {quantia.ToString("F2", CultureInfo.InvariantCulture)} para a conta nº {conta.NumeroConta} - {conta.Titular.Nome} realizada.");
            }
            else
            {
                Console.WriteLine("Quantia solicitada é inválida.");
            }
        }
    }
}
