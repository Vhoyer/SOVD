using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOVD
{
    public class Accounts
    {
        AccountsDAO.accounttype accountType;

        public AccountsDAO.accounttype AccountType
        {
            get { return accountType; }
            set { accountType = value; }
        }
        int id_accounts;

        public int Id_accounts
        {
            get { return id_accounts; }
            set { id_accounts = value; }
        }
        string username, password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
    }
}
