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
                if (_contaLogada is ContaEmpresarial emp)
                {
                    Console.WriteLine($"Limite de Empréstimo: {emp.LoanLimit:C}");
                }
                Console.WriteLine("\nOque deseja fazer?");
                Console.WriteLine("\n1. Despositar");
                Console.WriteLine("2. Sacar");
                if (_contaLogada is ContaEmpresarial) Console.WriteLine("3. Solicitar Empréstimo");
                Console.WriteLine("0. Logout");

                Console.Write("\nEscolha uma operação: ");
                string options = Console.ReadLine()!;

                switch (options)
                {
                    case "1":
                        decimal dep = GetAmountFromUser();
                        _contaLogada.Deposit(dep);
                        if (_contaLogada is ContaPoupanca poupanca)
                        {
                            poupanca.ApplyInterest();
                        }
                        Console.WriteLine("Depósito concluído.");
                        Console.Clear();
                        break;
                    case "2":
                        decimal saq = GetAmountFromUser();
                        if (_contaLogada.Withdraw(saq))
                            Console.WriteLine("Saque realizado!");
                            Thread.Sleep(2000);
                        break;
                    case "3":
                        HandleSpecificAction();
                        break;
                    case "0":
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

            if (_contaLogada is ContaEmpresarial empresarial)
            {
                empresarial.TakeLoan(GetAmountFromUser());
            }
        }
    }
}