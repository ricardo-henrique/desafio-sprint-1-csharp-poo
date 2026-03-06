namespace BedrockBankCorp.Models
{
    class ContaCorrente : ContaBancaria
    {
        private const decimal WithdrawalFee = 2.5m;

        public ContaCorrente(string name, string password) : base(name, password, "Conta Corrente")
        {
        }

        public override bool Withdraw(decimal amount)
        {
            decimal totalToDebit = amount + WithdrawalFee;


            if (totalToDebit > Balance)
            {
                Console.WriteLine($"Transação Negada: Saldo insuficiente");
                return false;
            }

            Balance -= totalToDebit;
            Console.WriteLine($"Saque de R${amount:C} (taxa: {WithdrawalFee:C}). Seu saldo é: {Balance}");
            return true;
        }
    }
}