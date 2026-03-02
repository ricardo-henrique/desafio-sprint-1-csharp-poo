namespace BedrockBankCorp.Models
{
    class ContaPoupanca : ContaBancaria
    {
        public decimal InterestRate { get; private set; }

        public ContaPoupanca(int accNum, string name, decimal initialBalance, decimal interestRate) : base(accNum, name, initialBalance, "Conta Poupança")
        {
            InterestRate = interestRate;
        }

        public override bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Transação Negada: O valor de saque tem que ser maior que 0");
            }

            if (amount > Balance)
            {
                Console.WriteLine("Transação Negada: Você não tem saldo suficiente para sacar este valor");
                return false;
            }

            Balance -= amount;
            Console.WriteLine($"Você sacou {amount:C}. Novo Saldo: {Balance:C}");
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