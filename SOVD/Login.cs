using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOVD
{
    public partial class frmLogin : Form
    {
        AccountsDAO accountsDAO = new AccountsDAO();
        Accounts account = new Accounts();

        public frmLogin()
        {
            Conexao.criar_Conexao();
            InitializeComponent();

            if (accountsDAO.selectall().Rows.Count == 0)
            {
                account.Username = "admin";
                account.Password = "admin";
                account.AccountType = AccountsDAO.accounttype.admin;
                accountsDAO.inserir(account);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        frmMain frm;
        private void btnLoginADM_Click(object sender, EventArgs e)
        {
            if(accountsDAO.accountSearch(txtUsuario.Text, txtSenha.Text) == true)
            {
                if (accountsDAO.Account.AccountType > AccountsDAO.accounttype.cliente)
                {
                    this.Hide();
                    frm = new frmMain(accountsDAO.Account);
                    frm.Show(this);
                }
                else
                {
                    MessageBox.Show("Essa conta não possui os privilegios necessarios");
                }
                txtSenha.Clear();
                txtUsuario.Clear();
            }
            else
            {
                MessageBox.Show("Credenciais inseridas não correspondem a nenhuma conta cadastrada");
            }
        }
    }
}
