using System;
using BudgetApp; // Add this line to reference BudgetManager

class Program
{
    static void Main()
    {
        BudgetManager budget = new BudgetManager();
        budget.LoadData();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Budget App ===");
            Console.WriteLine("1. Add Income");
            Console.WriteLine("2. Add Expense");
            Console.WriteLine("3. View Transactions");
            Console.WriteLine("4. View Balance");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddTransaction(budget, true);
                    break;
                case "2":
                    AddTransaction(budget, false);
                    break;
                case "3":
                    budget.ViewTransactions();
                    Console.ReadLine();
                    break;
                case "4":
                    budget.ViewBalance();
                    Console.ReadLine();
                    break;
                case "5":
                    budget.SaveData();
                    return;
                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
        }
    }

    static void AddTransaction(BudgetManager budget, bool isIncome)
    {
        Console.Write("Enter description: ");
        string description = Console.ReadLine();

        Console.Write("Enter amount: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
        {
            Console.WriteLine("Invalid amount. Press Enter to continue.");
            Console.ReadLine();
            return;
        }

        budget.AddTransaction(description, isIncome ? amount : -amount);
        Console.WriteLine("Transaction added! Press Enter to continue.");
        Console.ReadLine();
    }
}
