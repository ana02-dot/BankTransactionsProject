using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Transaction
    {
        public DateTime Date { get; }
        public double Amount { get; }
        public string Type { get; }
        public string Description { get; }

        public Transaction(DateTime date, double amount, string type, string description)
        {
            Date = date;
            Amount = amount;
            Type = type;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Date:yyyy-MM-dd HH:mm:ss} - {Type}: {Amount} - {Description}";
        }
    }
}
