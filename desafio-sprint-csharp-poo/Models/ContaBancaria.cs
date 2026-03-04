using System.Text.Json.Serialization;

namespace BedrockBankCorp.Models
{
    [JsonDerivedType(typeof(ContaPoupanca), typeDiscriminator: "Conta Poupança")]
    [JsonDerivedType(typeof(ContaCorrente), typeDiscriminator: "Conta Corrente")]
    [JsonDerivedType(typeof(ContaEmpresarial), typeDiscriminator: "Conta Empresarial")]
    public abstract class ContaBancaria
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

        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("O valor tem que ser maior que 0");
            }

            Balance += amount;
        }

        public abstract bool Withdraw(decimal amount);
    }
}