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
        public double Balance {  get;  protected set; }
        public string Username {  get; private set; }
        public int Pin {  get; private set; }

        public string Password{  get; protected set; }

        public Account(string accNumb, double balance, int pin, string username, string password)
        {
            AccNumb = accNumb;
            Balance = balance;
            Pin = pin;  
            Username = username;
            Password = password;
            
        }

        
        public abstract void TransferAccToAcc(string toAccount, double amount);
        public abstract void Deposit(double balance);
        public abstract void Withdraw(double balance);
        public abstract void ValidatePin(int inputPin);
        public abstract void RegisterUser(int ID, int phoneNumb, string name, string lastName);
        public abstract bool MinReqBalance(string inputAccnumb);
        public abstract void UpdatePassword(string oldpassword, string newPassword, string username);
        public abstract void GetTransactions();
        public abstract void GetDetailedAccounts();

        public abstract void CreateAccForExistingUser(string newID, string newAccNumb);

        public abstract double CurrencyConverter(double amount, string fromCurrency, string toCurrency);


    }
}
