using System.Text.Json.Serialization;

namespace BedrockBankCorp.Models
{
    [JsonDerivedType(typeof(ContaPoupanca), typeDiscriminator: "Conta Poupança")]
    [JsonDerivedType(typeof(ContaCorrente), typeDiscriminator: "Conta Corrente")]
    [JsonDerivedType(typeof(ContaEmpresarial), typeDiscriminator: "Conta Empresarial")]
    public abstract class ContaBancaria
    {
        private static int _nextAccountNumber = 1;
        public string AccountNumber { get; private set; }
        public string Holder { get; }
        public decimal Balance { get; protected set; }
        public string AccountType { get; }
        protected ContaBancaria(string name, decimal initialBalance, string type)
        {
            AccountNumber = $"001-{_nextAccountNumber:D4}";
            Holder = name;
            Balance = initialBalance;
            AccountType = type;
        }

        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("O valor tem que ser maior que 0");
            }

            Balance += amount;
        }

        public abstract bool Withdraw(decimal amount);

        public static void SetNextNumber(int next)
        {
            _nextAccountNumber = next;
        }
    }
}