namespace Models.Transactions;

public record Transaction(int Id, TransactionType Type, int Value);