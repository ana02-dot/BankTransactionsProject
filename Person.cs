using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    class Person : Account
    {
        public string SecondAcc { get; set; }
        public decimal SecondAccBalance { get; private set; }

        List<string> accounts = new List<string>();
        List<Transaction> transactions = new List<Transaction>();

        public Person(string accNumb, decimal balance, int pin, string username, string password) : base(accNumb, balance, pin, username, password)
        { }
        public override void GetTransactions()
        {
            Console.WriteLine("Transaction History:");
            if (transactions.Count == 0) {
                Console.WriteLine("No transactions found");
                return;
            }
            foreach (var transaction in this.transactions)
            {
                Console.WriteLine(transaction);
            }


        }

        public void FilterTransactionsByAmount(decimal minAmount)
        {

            var filteredTransactions = transactions.Where(x => x.Amount >= minAmount).ToList();

            Console.WriteLine($"Filtered Transactions (Amount is greater than {minAmount}):");
            if (filteredTransactions.Count == 0)
            {
                Console.WriteLine("No transactions found.");
                return;
            }

            foreach (var transaction in filteredTransactions)
            {
                {
                    Console.WriteLine(transaction);

                }

            }
        }

        

        public override void Deposit(decimal amount)
        {

            if (amount > 0)
            {
                Balance += amount;
                transactions.Add(new Transaction(DateTime.Now, amount, "Deposit"));
                Console.WriteLine("Successfully deposited");
            }
            else
            {
                Console.WriteLine("Amount must be positive");
            }

        }

        public override void Withdraw(decimal amount)
        {
            if (Balance >= amount && amount > 0)
            {
                Balance -= amount;
                transactions.Add(new Transaction(DateTime.Now, amount, "Withdraw"));
                Console.WriteLine("Successfully withdrew");
            }
            else
            {
                Console.WriteLine("Invalid amount or amount of money  must be positive");
            }
        }

        public override void TransferAccToAcc(string secondAcc, decimal amount)
        {
            if (Balance >= amount && amount > 0)
            {
                Balance -= amount;
                SecondAccBalance += amount;
                transactions.Add(new Transaction(DateTime.Now, amount, "Transfer"));
                Console.WriteLine("Successfully transferred");

            }
            else
            {
                Console.WriteLine("Invalid amount");
            }
        }



        public void BalanceSapr(int period, decimal amount, int yarly)
        {
            decimal saprocento = (amount * yarly / 100) / period;

            Balance += saprocento;
            Console.WriteLine($"new Balance is {Balance}");

        }

        public override void ValidatePin(int inputPin)
        {


            if (inputPin != Pin)
            {
                Console.WriteLine("incorrect pin, try again");
            }
            else
            {
                Console.WriteLine("correct pin");
            }

        }

        public override bool MinReqBalance(string inputAccnumb)
        {
            MinBalance = 0.01;
            decimal minBalance = Convert.ToDecimal(MinBalance);
            if (Balance >= minBalance  && AccNumb == inputAccnumb)
                return true;

            return false;
        }
        public override void RegisterUser(int ID, int phoneNumb, string name, string lastName)
        {
            string userInfo = $"ID: {ID}, Phone: {phoneNumb}, Name: {name}, Last name: {lastName}";
            accounts.Add(userInfo);


            Console.WriteLine("User registered successfully!");


        }

        public override void UpdatePassword(string oldpassword, string newPassword, string username)
        {

            if (Password == oldpassword && Username == username)
            {
                Password = newPassword;

                Console.WriteLine("password updated successfully");

            }
            else
            {
                Console.WriteLine("password can not been updated");
            }

        }


        public override void GetDetailedAccountsInfo()
        {
            List<string> detailedInfo = new List<string>();
            detailedInfo.Add(Balance.ToString());
            detailedInfo.Add(transactions.Count.ToString());
            detailedInfo.Add(Username);
            detailedInfo.Add(AccNumb);

            Console.WriteLine($"Balance: {detailedInfo[0]}\nNumber of Transactions: {detailedInfo[1]}" +
                $"\nUsername: {detailedInfo[2]}\nAccount Number: {detailedInfo[3]}");
           

        }

        public override void CreateAccForExistingUser(string newID, string newAccNumb)
        {
            if (!accounts.Contains(newID))
            {
                Console.WriteLine("account is registered");
            }
            else
            {
                string existUser = $"your account number is {newAccNumb}";
                accounts.Add(newAccNumb);

                foreach (string s in accounts)
                    Console.WriteLine(s);

                Console.WriteLine("User account created successfully!");

            }


        }

        public override double CurrencyConverter(double amount, string fromCurrency, string toCurrency)
        {
            var RateDict = new Dictionary<string, double> {
                { "USD", 2.72294},
                { "CAD", 1.95863},
                { "EUR", 2.93303 },
                { "CNY", 0.380104 },
                { "GBP", 3.52842},
                { "TRY", 0.0792585},
                { "GEL", 1 }

        };
            if((!RateDict.ContainsKey(fromCurrency)) && !RateDict.ContainsKey(toCurrency))
            {
                throw new ArgumentException("Invalid Currency");
            }

            if (fromCurrency == "GEL")
            {
                return amount / RateDict[toCurrency];
            }
            else if (toCurrency == "GEL")
            {
                return amount * RateDict[fromCurrency];
            }
            else
            {
                return amount * (RateDict[fromCurrency] / RateDict[toCurrency]);
            }

        }
    }
}
