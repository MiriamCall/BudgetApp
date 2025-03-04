namespace BudgetApp;

// Transaction.cs
public class Transaction
{
    public string Description { get; }
    public decimal Amount { get; }

    public Transaction(string description, decimal amount)
    {
        Description = description;
        Amount = amount;
    }

    public override string ToString()
    {
        return $"{Description}: {Amount:C}";
    }
}
