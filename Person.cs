using System;
using System.Collections.Generic;
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
        public double SecondAccBalance { get; private set; }

        List<string> accounts = new List<string>();
        List<string> transactions = new List<string>();

        public override void GetTransactions()
        {
            Console.WriteLine("Transaction History:");
            int count = 1;
            foreach (var transaction in this.transactions)
            {
                Console.WriteLine($"Transaction {count++}: {transaction}");
            }


        }

        public void FilterTransactions()
        {

            List<string> filteredTransactionsByBalance = transactions.Where(x => Balance < 45).ToList();
            foreach (var transaction in filteredTransactionsByBalance)
            {
                {
                    Console.WriteLine(transaction);

                }



            }
        }

        public Person(string accNumb, double balance, int pin, string username, string password) : base(accNumb, balance, pin, username, password)
        { }

        public override void Deposit(double balance)
        {

            if (balance > 0)
            {
                Balance += balance;
                transactions.Add($"Deposited {balance}\nNew Balance {Balance}");
                Console.WriteLine("Successfully deposited");
            }
            else
            {
                Console.WriteLine("Amount must be positive");
            }

        }

        public override void Withdraw(double balance)
        {
            if (Balance >= balance && balance > 0)
            {
                Balance -= balance;
                transactions.Add($"Withdrew {balance}\nNew Balance {Balance}");
                Console.WriteLine("Successfully withdrew");
            }
            else
            {
                Console.WriteLine("Invalid amount");
            }
        }

        public override void TransferAccToAcc(string secondAcc, double amount)
        {
            if (Balance >= amount && amount > 0)
            {
                Balance -= amount;
                SecondAccBalance += amount;
                transactions.Add($"Transferred {amount} to {secondAcc}\nNew Balance {Balance}");
                Console.WriteLine("Successfully transferred");

            }
            else
            {
                Console.WriteLine("Invalid amount");
            }
        }



        public void BalanceSapr(int period, double amount, int yarly)
        {
            double saprocento = (amount * yarly / 100) / period;

            Balance = (Balance + saprocento);

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
            if (Balance > 0 && AccNumb == inputAccnumb)
                return true;

            return false;
        }
        public override void RegisterUser(int ID, int phoneNumb, string name, string lastName)
        {
            string userInfo = $"ID: {ID}, Phone: {phoneNumb}, Name: {name}, Last name: {lastName}";
            accounts.Add(userInfo);

            foreach (string s in accounts)
                Console.WriteLine(s);

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
                Console.WriteLine("password can not update");
            }

        }


        public override void GetDetailedAccounts()
        {
            List<string> detailedInfo = new List<string>();
            detailedInfo.Add(Balance.ToString());
            detailedInfo.Add(transactions.Count.ToString());
            detailedInfo.Add(Username);
            detailedInfo.Add(AccNumb);
            foreach (var info in detailedInfo)
            {
                Console.WriteLine(info);
            }

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
            if((!RateDict.ContainsKey(fromCurrency)) || !RateDict.ContainsKey(toCurrency))
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
