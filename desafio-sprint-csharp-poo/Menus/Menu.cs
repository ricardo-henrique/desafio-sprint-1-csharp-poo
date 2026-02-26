namespace BedrockBankCorp.Menu
{
    class Menu
    {
        public void DisplayOptionsTitle(string Title)
        {
            int amountOfLetters = Title.Length;
            string asterisk = string.Empty.PadLeft(amountOfLetters, '*');
            Console.WriteLine(asterisk);
            Console.WriteLine(Title);
            Console.WriteLine(asterisk + "\n");
        }

        public virtual void Execute()
        {

        }
    }
}