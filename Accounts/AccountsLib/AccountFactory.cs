using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AccountsLib
{
    public static class AccountFactory
    {
        private static int Id=1;

        public static Account CreateAccount(int initialBalance)
        {
            var acc = new Account(Id);
            acc.Deposit(initialBalance);
            return acc;
        }
    }
}
