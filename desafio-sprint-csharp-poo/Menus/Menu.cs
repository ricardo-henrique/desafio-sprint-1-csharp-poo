using BedrockBankCorp.Models;

namespace BedrockBankCorp.Menus
{
    class Menu
    {
        protected void DisplayOptionsTitle(string title)
        {
            int amountOfLetters = title.Length;
            string asterisk = string.Empty.PadLeft(amountOfLetters, '*');
            Console.WriteLine(asterisk);
            Console.WriteLine(title);
            Console.WriteLine(asterisk + "\n");
        }

        public virtual void Execute(List<ContaBancaria> registeredAccounts)
        {
            Console.Clear();
        }
    }
}