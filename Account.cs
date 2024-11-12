using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Account
    {
        public string AccNumb { get;  private set; }
        public decimal Balance {  get;  protected set; }
        public string Username {  get; private set; }
        public int Pin {  get; private set; }

        public string Password{ get; protected set; }

        public double MinBalance { get; protected set; }
        public Account(string accNumb, decimal balance, int pin, string username, string password)
        {
            AccNumb = accNumb;
            Balance = balance;
            Pin = pin;  
            Username = username;
            Password = password;
            
        }

        
        public abstract void TransferAccToAcc(string toAccount, decimal amount);
        public abstract void Deposit(decimal balance);
        public abstract void Withdraw(decimal balance);
        public abstract void ValidatePin(int inputPin);
        public abstract void RegisterUser(int ID, int phoneNumb, string name, string lastName);
        public abstract bool MinReqBalance(string inputAccnumb);
        public abstract void UpdatePassword(string oldpassword, string newPassword, string username);
        public abstract void GetTransactions();
        public abstract void GetDetailedAccountsInfo();

        public abstract void CreateAccForExistingUser(string newID, string newAccNumb);

        public abstract double CurrencyConverter(double amount, string fromCurrency, string toCurrency);


    }
}
