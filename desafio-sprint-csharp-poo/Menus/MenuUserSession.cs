using BedrockBankCorp.Models;

namespace BedrockBankCorp.Menus
{
    internal class MenuUserSession : Menu
    {
        private readonly ContaBancaria _contaLogada;

        public MenuUserSession(ContaBancaria conta)
        {
            _contaLogada = conta;
        }

        public override void Execute(List<ContaBancaria> registeredAccounts)
        {
            bool logedIn = true;
            while (logedIn)
            {
                Console.Clear();
                Console.WriteLine($"=== Área DO CLIENTE | {_contaLogada.Holder} ===");
                Console.WriteLine($"Conta: {_contaLogada.AccountNumber} | Saldo: {_contaLogada.Balance}");
                Console.WriteLine("\n1. Despositar");
                Console.WriteLine("2. Sacar");
                Console.WriteLine("0. Logout");

                Console.Write("\nEscolha uma operação: ");
                string options = Console.ReadLine()!;

                switch (options)
                {
                    case "1":
                        Console.Write("Valor do depósito");
                        _contaLogada.Deposit(decimal.Parse(Console.ReadLine()!));
                        Console.Clear();
                        break;
                    case "2":
                        Console.Write("Valor do saque: ");
                        _contaLogada.Withdraw(decimal.Parse(Console.ReadLine()!));
                        break;
                    case "3":
                        logedIn = false;
                        break;
                    default:
                        Console.WriteLine("Opção Invalida");
                        break;
                }
                if (options != "0")
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}