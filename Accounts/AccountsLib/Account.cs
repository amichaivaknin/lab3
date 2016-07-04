using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsLib
{
    public class Account
    {
        public int Id { get; }
        public int Balance { get; private set; }

        internal Account(int id)
        {
            Id = id;
            Balance = 0;
        }

        public void Deposit(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount),"The amount must be positive");
            }
            else
            {
                Balance = Balance + amount;
            }       
        }

        public bool Withdraw(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "The amount must be positive");
            }

            else if (amount > Balance)
            {
                throw new InsufficientFundsException("The amount is bigger then the total balance");
            }
            else
            {
                Balance -= amount;
                return true;
            }
        }

        public bool Transfer(Account account, int amount)
        {
            var fl = false;
            int before = Balance;
            try
            {
                if (Withdraw(amount))
                {
                    account.Deposit(amount);
                    fl = true;
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                fl=false;
            }

            finally
            {
                Console.WriteLine("Transfer attempt has been made");
                if (fl)
                {
                    Console.WriteLine("Balance before " + before);
                    Console.WriteLine("Balance after " + Balance);
                }
                else
                {
                    Console.WriteLine("Transfer fail, the current balance is " + Balance);
                }  
            }
            return fl;
        }
    }
}
