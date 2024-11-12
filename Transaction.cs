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
        public decimal Amount { get; }
        public string Type { get; }

        public Transaction(DateTime date, decimal amount, string type)
        {
            Date = date;
            Amount = amount;
            Type = type;
        }

        public override string ToString()
        {
            return $"{Date:yyyy-MM-dd HH:mm:ss} - {Type}: {Amount}";
        }
    }
}
