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
    public partial class frmEditarConta : Form
    {
        private Accounts account;

        public frmEditarConta(Accounts account)
        {
            this.account = account;
            InitializeComponent();
            if (account.Username == "admin")
            {
                lblNewMail.Visible = false;
                txtNewMail.Visible = false;
            }
        }

        private void chkvisu2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkvisu2.Checked == true)
            {
                txtnovasenha.UseSystemPasswordChar = false;
                txtagain.UseSystemPasswordChar = false;
            }
            else
            {
                txtnovasenha.UseSystemPasswordChar = true;
                txtagain.UseSystemPasswordChar = true;
            }
        }

        private void btnnovasenha_Click(object sender, EventArgs e)
        {
            if (txtnovasenha.Text == txtagain.Text)
            {
                AccountsDAO accountsDAO = new AccountsDAO();

                account.Password = txtagain.Text;
                accountsDAO.alterar(account);
                if (account.Username != "admin")
                {
                    CargoDAO cargoDAO = new CargoDAO();
                    cargoDAO.alterarEmail(txtNewMail.Text, account.Id_accounts); 
                }

                MessageBox.Show("Credenciais alteradas com sucesso!");
                this.Close();
            }
            else
            {
                MessageBox.Show("As senhas não coincidem.");
            }
        }

        private void chkvisu_CheckedChanged(object sender, EventArgs e)
        {
            if (chkvisu.Checked == true)
            {
                txtsenha.UseSystemPasswordChar = false;
            }
            else
            {
                txtsenha.UseSystemPasswordChar = true;
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string senha;
            senha = txtsenha.Text;

            if (senha == account.Password)
            {
                txtagain.Enabled = true;
                txtnovasenha.Enabled = true;
                btnnovasenha.Enabled = true;

                if (account.Username != "admin")
                {
                    DAO dao = new DAO();
                    txtNewMail.Text = dao.Load_Table("SELECT email FROM cargo WHERE id_account = '" + account.Id_accounts + "'").Rows[0]["email"].ToString();
                    txtNewMail.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Credenciais inseridas não correspondem às usadas na senha do login");
            }
        }
    }
}
