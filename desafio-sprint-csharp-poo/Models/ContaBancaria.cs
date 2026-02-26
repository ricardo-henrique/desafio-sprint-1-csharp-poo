namespace BedrockBankCorp.Models
{
    abstract class ContaBancaria
    {
        private int AccountNumber { get; }
        private string AccountHolder { get; }
        private double Balance { get; set; }


        public virtual void Deposit(decimal amount)
        {
        }

        public virtual void Withdraw(decimal amount)
        {

        }

        public virtual void MakeLoan(decimal amount)
        {

        }
    }
}