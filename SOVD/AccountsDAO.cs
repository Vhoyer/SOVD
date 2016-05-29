using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace SOVD
{
    public class AccountsDAO
    {
        Accounts account = new Accounts();

        public Accounts Account
        {
            get { return account; }
            set { account = value; }
        }

        // variaveis para acessar o MySql
        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        // método private de acesso ao BD
        private void executarComando(string comando)
        {
            // criar uma sacolinha vazia
            tabela_memoria = new DataTable();

            // converter um texto (string) para um comando SQL
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);

            // executar o comando SQL 
            executar_comando = new MySqlCommandBuilder(comando_sql);

            // resposta que será armazenada na sacolinha
            comando_sql.Fill(tabela_memoria);
        }

        public int ReturnId(string username)
        {
            executarComando("SELECT * FROM accounts WHERE username = '" + username + "'");
            return int.Parse(tabela_memoria.Rows[0]["id_accounts"].ToString());
        }


        public enum accounttype
	    {
	         admin = 2, funcionario = 1, cliente = 0
	    }

        public Boolean accountSearch (string username, String password)
        {
            executarComando("SELECT * FROM accounts WHERE username = '" + username + "' AND password = '" + password + "';");

            try
            {
                Account.Id_accounts = int.Parse(tabela_memoria.Rows[0]["id_accounts"].ToString());
                account.Username = tabela_memoria.Rows[0]["username"].ToString();
                account.Password = tabela_memoria.Rows[0]["password"].ToString();
                account.AccountType = (accounttype)Convert.ToInt32(tabela_memoria.Rows[0]["account_type"].ToString());

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void inserir(Accounts acc)
        {
            executarComando("INSERT INTO `accounts` VALUES (0,'" + acc.Username + "','" + acc.Password + "'," + (int)acc.AccountType + ")");
        }

        public DataTable selectall()
        {
            executarComando("SELECT * FROM accounts");
            
            return tabela_memoria;
        }

        public void alterar(Accounts account)
        {
            executarComando("update accounts set password='" + account.Password + "' WHERE id_accounts = '"+account.Id_accounts+"';");
        }
    }
}
