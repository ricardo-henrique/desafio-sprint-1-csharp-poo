using BedrockBankCorp.Models;

namespace BedrockBankCorp.Menus
{
    internal class MenuLogin : Menu
    {
        public override void Execute(List<ContaBancaria> registeredAccounts)
        {
            base.Execute(registeredAccounts);
            DisplayOptionsTitle("Login do cliente");

            Console.Write("Digite o numero da conta (ex: 001-0001):");
            string number = Console.ReadLine()!;
            Console.Write("Digite sua senha: ");
            string password = Console.ReadLine()!;

            var account = registeredAccounts.FirstOrDefault(a => a.AccountNumber == number && a.Password == password);
            if (account != null)
            {
                Console.WriteLine($"\nLogin realizado com sucesso! Bem-Vindo, {account.Holder}");
                Thread.Sleep(1500);
                Console.Clear();

                var session = new MenuUserSession(account);
                session.Execute(registeredAccounts);
            }
            else
            {
                Console.WriteLine("\nNúmero da conta ou senha incorretos");
                Console.Clear();
            }
        }
    }
}