namespace BedrockBankCorp.Models
{
    class ContaEmpresarial : ContaBancaria
    {
        public decimal LoanLimit { get; set; }

        public ContaEmpresarial(string name, string password, decimal loanLimit) : base(name, password, "Conta Empresarial")
        {
            LoanLimit = loanLimit;
        }

        public override bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Transação Negada: Valor de saque dever ser maior que 0");
                return false;
            }

            if (amount > (Balance + LoanLimit))
            {
                Console.WriteLine("Transação negada: limite de empréstimo excedido.");
                return false;
            }

            Balance -= amount;

            if (Balance < 0)
            {
                Console.WriteLine($"Retirou {amount:C}. Aviso: Você está usando {Math.Abs(Balance):C} do seu limite de empréstimo!");
            }
            else
            {
                Console.WriteLine($"Retirou {amount:C}. Saldo novo: {Balance:C}");
            }
            Console.Clear();
            return true;
        }

        public void TakeLoan(decimal amount)
        {
            if (amount <= LoanLimit)
            {
                Deposit(amount);
                Console.WriteLine($"Emprestimo de {amount:C} creditado com sucesso na sua conta.");
            }
        }
    }
}