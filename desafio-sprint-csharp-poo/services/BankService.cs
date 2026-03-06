using System.Text.Json;
using BedrockBankCorp.Models;

namespace BedrockBankCorp.Service
{
    public static class BankService
    {
        private const string FilePath = "accounts.json";
        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        public static void Save(List<ContaBancaria> accounts)
        {
            string json = JsonSerializer.Serialize(accounts, Options);
            File.WriteAllText(FilePath, json);
        }

        public static List<ContaBancaria> Load()
        {
            if (!File.Exists(FilePath)) return new List<ContaBancaria>();

            string json = File.ReadAllText(FilePath);
            var list = JsonSerializer.Deserialize<List<ContaBancaria>>(json) ?? new List<ContaBancaria>();

            if (list.Count > 0)
            {
                int maxId = list.Max(a => int.Parse(a.AccountNumber.Split('-')[1]));
                ContaBancaria.SetNextNumber(maxId + 1);
            }
            return list;
        }
    }
}