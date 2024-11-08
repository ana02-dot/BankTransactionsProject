using ConsoleApp1;

internal class Program
{
    private static void Main(string[] args)
    {

        Person person1 = new Person("ge2321", 100, 3030,"chkhuto","password");
        person1.Deposit(200);
        person1.Withdraw(5);
        person1.Withdraw(50);
        person1.Deposit(200);

        Console.WriteLine(person1.MinReqBalance("ge2321"));
        //Console.WriteLine(person1.Balance);
        //person1.TransferAccToAcc("sdaas", 30);
        // Console.WriteLine(person1.SecondAccBalance);

        //person1.BalanceSapr(12, 2, 23);

        //Console.WriteLine(person1.MinReqBalance("ge2321"));
        //person1.ValidatePin(30302);

        //person1.RegisterUser(01014048, 59957500, "chkhuot", "ch");

        /*
                Console.WriteLine(person1.Password);
                person1.UpdatePassword("password", "newpass", "chkhuto");
                Console.WriteLine(person1.Password);*/

        Console.WriteLine("\nFull Transaction History:");
        person1.GetTransactions();

        person1.FilterTransactionsByAmount(50);

        //person1.GetDetailedAccounts();

        //person1.CreateAccForExistingUser("010180056", "ge09090");

       // Console.WriteLine(person1.CurrencyConverter(100, "USD", "GEL"));
    }
}