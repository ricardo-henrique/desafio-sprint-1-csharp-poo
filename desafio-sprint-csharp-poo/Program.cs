using BedrockBankCorp.Models;
using BedrockBankCorp.Service;
using BedrockBankCorp.Menus;

internal class Program
{
    private static void Main()
    {

        List<ContaBancaria> registeredAccounts = BankService.Load();

        Dictionary<int, Menu> options = new Dictionary<int, Menu>();
        options.Add(1, new MenuRegisterAccount());
        options.Add(2, new MenuLogin());
        options.Add(3, new MenuExit());

        void DisplayLogo()
        {
            Console.WriteLine(@$"
██████╗░███████╗██████╗░██████╗░░█████╗░░█████╗░██╗░░██╗  ██████╗░░█████╗░███╗░░██╗░█████╗░░█████╗░██████╗░██████╗░
██╔══██╗██╔════╝██╔══██╗██╔══██╗██╔══██╗██╔══██╗██║░██╔╝  ██╔══██╗██╔══██╗████╗░██║██╔══██╗██╔══██╗██╔══██╗██╔══██╗
██████╦╝█████╗░░██║░░██║██████╔╝██║░░██║██║░░╚═╝█████═╝░  ██████╦╝███████║██╔██╗██║██║░░╚═╝██║░░██║██████╔╝██████╔╝
██╔══██╗██╔══╝░░██║░░██║██╔══██╗██║░░██║██║░░██╗██╔═██╗░  ██╔══██╗██╔══██║██║╚████║██║░░██╗██║░░██║██╔══██╗██╔═══╝░
██████╦╝███████╗██████╔╝██║░░██║╚█████╔╝╚█████╔╝██║░╚██╗  ██████╦╝██║░░██║██║░╚███║╚█████╔╝╚█████╔╝██║░░██║██║░░░░░
╚═════╝░╚══════╝╚═════╝░╚═╝░░╚═╝░╚════╝░░╚════╝░╚═╝░░╚═╝  ╚═════╝░╚═╝░░╚═╝╚═╝░░╚══╝░╚════╝░░╚════╝░╚═╝░░╚═╝╚═╝░░░░░");
        }

        void DisplayMenuOptions()
        {
            DisplayLogo();
            Console.WriteLine("Digite 1 para registrar conta");
            Console.WriteLine("Digite 2 para logar na sua conta");
            Console.WriteLine("Digite 3 para sair do sistema");

            Console.Write("\nDigite a sua opção: ");
            int selectedOption = int.Parse(Console.ReadLine()!);

            if (options.ContainsKey(selectedOption))
            {
                Menu menuToBeDisplayed = options[selectedOption];
                menuToBeDisplayed.Execute(registeredAccounts);

                if (selectedOption > 0) DisplayMenuOptions();
            }
            else
            {
                Console.WriteLine("Opção inválida");
            }
        }

        DisplayMenuOptions();
    }
}