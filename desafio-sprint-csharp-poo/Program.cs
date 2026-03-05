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
        options.Add(2, new MenuDisplayAccounts());
        options.Add(4, new MenuExit());

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
            Console.WriteLine("Digite 2 para mostrar todas as contas");
            Console.WriteLine("Digite 4 para sair do sistema");
        }

        DisplayMenuOptions();
    }
}