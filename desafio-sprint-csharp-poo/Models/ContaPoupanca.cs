namespace BedrockBankCorp.Models
{
    class ContaPoupanca : ContaBancaria
    {
        public decimal InterestRate { get; }
        public const decimal StandardRate = 0.05m;

        public ContaPoupanca(string name, decimal initialBalance, string password) : base(name, initialBalance, "Conta Poupança", password)
        {
            InterestRate = StandardRate;
        }

        public override bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Transação Negada: O valor de saque tem que ser maior que 0");
                return false;
            }

            if (amount > Balance)
            {
                Console.WriteLine("Transação Negada: Você não tem saldo suficiente para sacar este valor");
                return false;
            }

            Balance -= amount;
            Console.WriteLine($"Você sacou {amount:C}. Novo Saldo: {Balance:C}");
            Console.Clear();
            return true;
        }

        public void ApplyInterest()
        {
            decimal interest = Balance * InterestRate;
            Deposit(interest);
            Console.WriteLine($"Rendimento de {interest:C} aplicados a uma taxa de {InterestRate:P}");
        }
    }
}