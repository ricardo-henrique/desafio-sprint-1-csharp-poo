using BedrockBankCorp.Models;

namespace BedrockBankCorp.Menus
{
    internal class MenuExit : Menu
    {
        public override void Execute(List<ContaBancaria> registeredAccounts)
        {
            Console.WriteLine("Até mais :)");
        }
    }
}