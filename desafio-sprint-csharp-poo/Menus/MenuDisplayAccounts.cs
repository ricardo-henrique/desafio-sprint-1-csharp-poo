using BedrockBankCorp.Models;

namespace BedrockBankCorp.Menus
{
    internal class MenuDisplayAccounts : Menu
    {
        public override void Execute(List<ContaBancaria> registeredAccounts)
        {
            base.Execute(registeredAccounts);
            DisplayOptionsTitle("Exibindo todas as contas");

            foreach (var conta in registeredAccounts)
            {
                Console.WriteLine(conta.ToString());
            }
        }
    }
}