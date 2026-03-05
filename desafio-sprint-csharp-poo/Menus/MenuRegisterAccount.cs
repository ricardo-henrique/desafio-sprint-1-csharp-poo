using BedrockBankCorp.Models;

namespace BedrockBankCorp.Menus
{
    internal class MenuRegisterAccount : Menu
    {
        public override void Execute(List<ContaBancaria> registeredAccounts)
        {
            base.Execute(registeredAccounts);
            DisplayOptionsTitle("Registro de Nova Conta");

            Console.WriteLine("Digite 1 para Conta Poupança, 2 para Conta Corrente e 3 para Conta Empresarial");
            string type = Console.ReadLine()!;

            Console.Write("Digite seu nome completo: ");
            string holder = Console.ReadLine()!;
            Console.Write("Saldo Inicial: ");
            decimal balance = decimal.Parse(Console.ReadLine()!);

            if (type == "1")
                registeredAccounts.Add(new ContaPoupanca(holder, balance));
            else if (type == "2")
                registeredAccounts.Add(new ContaCorrente(holder, balance));
            else if (type == "3")
                registeredAccounts.Add(new ContaEmpresarial(holder, balance, 5000m));
            else
                Console.WriteLine("Essa tipo não existe");

            Console.WriteLine("\nConta registrada com sucesso");
        }
    }
}