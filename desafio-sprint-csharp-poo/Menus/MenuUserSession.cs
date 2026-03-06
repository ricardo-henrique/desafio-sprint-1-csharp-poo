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
                Console.WriteLine($"=== Área DO CLIENTE ===");
                Console.WriteLine($"=== {_contaLogada.AccountType.ToUpper()} | {_contaLogada.Holder} ===");
                Console.WriteLine($"Saldo: {_contaLogada.Balance:C}");
                Console.WriteLine("\nOque deseja fazer?");
                Console.WriteLine("\n1. Despositar");
                Console.WriteLine("2. Sacar");
                Console.WriteLine("3. Logout");

                Console.Write("\nEscolha uma operação: ");
                string options = Console.ReadLine()!;

                switch (options)
                {
                    case "1":
                        decimal dep = GetAmountFromUser();
                        _contaLogada.Deposit(dep);
                        HandleSpecificAction();
                        Console.WriteLine("Depósito concluído.");
                        Console.Clear();
                        break;
                    case "2":
                        decimal saq = GetAmountFromUser("Valor para saque: ");
                        if (_contaLogada.Withdraw(saq))
                            Console.WriteLine("Saque realizado!");
                        break;
                    case "3":
                        logedIn = false;
                        Console.WriteLine("Saindo da Conta...");
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opção Invalida");
                        break;
                }
                if (logedIn)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        private void HandleSpecificAction()
        {
            if (_contaLogada is ContaPoupanca poupanca)
            {
                poupanca.ApplyInterest();
            }
            else if (_contaLogada is ContaEmpresarial empresarial)
            {
                empresarial.TakeLoan(GetAmountFromUser());
            }
        }
    }
}