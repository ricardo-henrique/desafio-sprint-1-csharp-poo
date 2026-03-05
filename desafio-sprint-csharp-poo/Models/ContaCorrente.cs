namespace BedrockBankCorp.Models
{
    class ContaCorrente : ContaBancaria
    {
        private const decimal WithdrawalFee = 2.5m;

        public ContaCorrente(string name, decimal initialBalance, string password) : base(name, initialBalance, "Conta Corrente", password)
        {
        }

        public override bool Withdraw(decimal amount)
        {
            decimal totalToDebit = amount + WithdrawalFee;


            if (totalToDebit > Balance)
            {
                Console.WriteLine($"Transação Negada: Saldo insuficiente");
                Console.Clear();
                return false;
            }

            Balance -= totalToDebit;
            Console.WriteLine($"Saque de R${amount:C} (taxa: {WithdrawalFee:C}). Seu saldo é: {Balance}");
            return true;
        }
    }
}