using BedrockBankCorp.Models;

namespace BedrockBankCorp.Menus
{
    internal class MenuDisplayAccounts : Menu
    {
        public override void Execute(List<ContaBancaria> registeredAccounts)
        {
            base.Execute(registeredAccounts);
            DisplayOptionsTitle("Exibindo todas as contas:");

            foreach (var conta in registeredAccounts)
            {

                if (conta != null)
                {
                    Console.WriteLine($"Titular da conta: {conta.Holder}");
                }
                else
                {
                    Console.WriteLine("Nenhuma conta registrada");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
        }
    }
}