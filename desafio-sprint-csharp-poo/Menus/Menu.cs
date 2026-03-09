using BedrockBankCorp.Models;

namespace BedrockBankCorp.Menus
{
    internal abstract class Menu
    {
        protected void DisplayOptionsTitle(string title)
        {
            int amountOfLetters = title.Length;
            string asterisk = string.Empty.PadLeft(amountOfLetters, '*');
            Console.WriteLine(asterisk);
            Console.WriteLine(title);
            Console.WriteLine(asterisk + "\n");
        }

        protected decimal GetAmountFromUser()
        {
            Console.Write("Digite o valor: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                return amount;
            }
            Console.WriteLine("Valor inválido. Considerando R$ 0,00.");
            return 0;
        }

        public virtual void Execute(List<ContaBancaria> registeredAccounts)
        {
            Console.Clear();
        }
    }
}