# BankTransactionsProject

A C# console application that simulates the core logic of a **banking system**, allowing you to manage people, accounts, and transactions. It’s a great project to practice object-oriented programming, data modeling, and LINQ.

## 📌 Key Features

- Create and manage **Person** objects with personal details
- Manage **Account** objects with balance and account types
- (Optional) Add and categorize **Transaction** records
- Use LINQ to query, filter, and summarize data
- Structured with clean, modular C# code

## 🧱 Project Structure

- `Person.cs` – Represents a customer with fields like `Id`, `Name`, `Email`
- `Account.cs` – Represents a bank account with `Balance`, `AccountType`, and ownership via `PersonId`
- `Transaction.cs` *(assumed)* – Represents a financial transaction
- `Program.cs` – The entry point with logic for running and testing the banking logic

## 🛠️ Technologies Used

- C# (.NET 8 Console App)
- Object-Oriented Programming
- LINQ
- Enum usage (`AccountType`)
- Basic Data Validation

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- An IDE like Visual Studio or Rider

### Running the App

1. Clone the repo:

   ```bash
   git clone https://github.com/ana02-dot/BankTransactionsProject.git
   cd BankTransactionsProject


## 🔐 Sample Classes

### Person.cs
```csharp
public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
