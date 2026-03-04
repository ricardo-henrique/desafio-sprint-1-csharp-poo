using System.Text.Json;
using System.IO;
using BedrockBankCorp.Models;

namespace BedrockBankCorp.Service
{
    public static class BankService
    {
        private const string FilePath = "data/accounts.json";
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
            return JsonSerializer.Deserialize<List<ContaBancaria>>(json) ?? new List<ContaBancaria>();
        }
    }
}