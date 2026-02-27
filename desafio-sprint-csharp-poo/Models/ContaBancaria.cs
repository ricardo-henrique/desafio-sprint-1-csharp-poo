namespace BedrockBankCorp.Models
{
    abstract class ContaBancaria
    {
        public int AccountNumber { get; }
        public string Holder { get; }
        public decimal Balance { get; protected set; }
        public string AccountType { get; }
        protected ContaBancaria(int accNum, string name, decimal initialBalance, string type)
        {
            AccountNumber = accNum;
            Holder = name;
            Balance = initialBalance;
            AccountType = type;
        }


    }
}