using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AccountsLib;

namespace Accounts
{
    class Program
    {
        static void Main(string[] args)
        {
            var acc = AccountFactory.CreateAccount(0);
            var fl = true;

            while (fl)
            {
                Console.WriteLine("Select A action");
                Console.WriteLine("     d for Deposit");
                Console.WriteLine("     w for Withdraw");
                Console.WriteLine("     b for watch your balance");
                Console.WriteLine("     q for exit");

                var str = Console.ReadLine();

                string amount;
                switch (str)
                {
                    case "d":
                        try
                        {
                            Console.WriteLine("Enter amount for Deposit");
                            amount = Console.ReadLine();
                            if (amount != null) acc.Deposit(int.Parse(amount));
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case "w":
                        Console.WriteLine("Enter amount for Withdrow");
                        amount = Console.ReadLine();
                        if (amount != null)
                        {
                            try
                            {
                                Console.WriteLine(acc.Withdraw(int.Parse(amount))
                                    ? "Withdrow Success"
                                    : "you dont have enough money");
                            }
                            catch (ArgumentOutOfRangeException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            catch (InsufficientFundsException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        break;

                    case "b":
                        Console.WriteLine("Your balance is " + acc.Balance);
                        break;

                    case "q":
                        fl = false;
                        break;

                    default:
                        Console.WriteLine("Wrong input, try again");
                        break;
                }
            }

            try
            {
                var acc2 = AccountFactory.CreateAccount(0);
                Console.WriteLine("Select amount for transfer ");
                var amount2 = int.Parse(Console.ReadLine());
                Console.WriteLine(acc.Transfer(acc2, amount2)
                        ? "Transfer Success"
                        : "Transfer faild");
            }
            catch (InsufficientFundsException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
