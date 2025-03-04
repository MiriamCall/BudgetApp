namespace BudgetApp;

// BudgetManager.cs
using System;
using System.Collections.Generic;
using System.IO;

public class BudgetManager
{
    private List<Transaction> transactions = new List<Transaction>();
    private string filePath = "budget_data.txt";

    public void AddTransaction(string description, decimal amount)
    {
        transactions.Add(new Transaction(description, amount));
        Console.WriteLine("Transaction added!");
    }

    public void ViewTransactions()
    {
        Console.WriteLine("\n=== Transaction History ===");
        foreach (var t in transactions)
        {
            Console.WriteLine(t);
        }
    }

    public void ViewBalance()
    {
        decimal balance = 0;
        foreach (var t in transactions)
        {
            balance += t.Amount;
        }
        Console.WriteLine($"\nCurrent Balance: {balance:C}");
    }

    public void SaveData()
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var t in transactions)
            {
                writer.WriteLine($"{t.Description},{t.Amount}");
            }
        }
    }

    public void LoadData()
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 2 && decimal.TryParse(parts[1], out decimal amount))
                {
                    transactions.Add(new Transaction(parts[0], amount));
                }
            }
        }
    }
}
