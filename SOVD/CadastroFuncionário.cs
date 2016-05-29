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
    public partial class frmCadastroFuncionário : Form
    {
        public frmCadastroFuncionário()
        {
            InitializeComponent();
        }
        public frmCadastroFuncionário(int id)
        {
            InitializeComponent();
            grpAccout_e_email.Enabled = false;
            cmbLevel.Enabled = false;
            edit = true;
            this.id = id;

            DAO dao = new DAO();
            DataTable table = dao.Load_Table("SELECT nome, id_account, sobrenome, setor, funcao, cbo, salario_mensal, horas_trabalhadas FROM cargo WHERE id = '" + id + "';");
            txtCBO.Text = table.Rows[0]["cbo"].ToString();
            txtFuncao.Text = table.Rows[0]["funcao"].ToString();
            txtHorasTrabson.Text = table.Rows[0]["horas_trabalhadas"].ToString();
            txtNomeFunc.Text = table.Rows[0]["nome"].ToString();
            txtSalario.Text = table.Rows[0]["salario_mensal"].ToString();
            txtSetor.Text = table.Rows[0]["setor"].ToString();
            txtSobrenome.Text = table.Rows[0]["sobrenome"].ToString();
            id_account = int.Parse(table.Rows[0]["id_account"].ToString());
        }
        Cargo func = new Cargo();
        CargoDAO funDAO = new CargoDAO();
        bool edit = false;
        int id_account, id;

        private void button1_Click(object sender, EventArgs e)
        {
            if (!edit)
            {
                #region "MEU DEUS QUE COISA HORRIVEL"
                if (txtSenha.Text != txtConfirmarSenha.Text | txtSenha.Text == "")
                {
                    MessageBox.Show("Senhas não são as mesmas ou o campo estabelecido para a senha se encontra vazio");
                    return;
                }
                else if (txtEmail.Text != txtConfirmarEmail.Text | txtEmail.Text == "" | !txtEmail.Text.Contains("@"))
                {
                    MessageBox.Show("Emails não são os mesmos ou o(s) campo(s) se encontra(m) vazio(s) ou o email não é valido");
                    return;
                }
                if (txtUsuario.Text == string.Empty ||
                   txtSenha.Text == string.Empty ||
                   txtEmail.Text == string.Empty)
                {
                    MessageBox.Show("Os campos destacados são obrigatórios.");
                    txtEmail.BackColor = Color.Pink;
                    txtSenha.BackColor = Color.Pink;
                    txtUsuario.BackColor = Color.Pink;
                    txtConfirmarSenha.BackColor = Color.Pink;
                    txtConfirmarEmail.BackColor = Color.Pink;
                }
                else
                {
                    if (txtSobrenome.Text == string.Empty || txtNomeFunc.Text == string.Empty)
                    {
                        DialogResult dr = MessageBox.Show("O campo nome e/ou sobrenome não se encontram preenchidos, deseja deixa-los em branco?", "Campos vazios", MessageBoxButtons.YesNo);

                        if (dr == DialogResult.Yes)
                        {
                            try
                            {
                                AccountsDAO accDao = new AccountsDAO();
                                Accounts acc = new Accounts();
                                if (txtCBO.Text != string.Empty)
                                    func.Cbo = txtCBO.Text;
                                func.Email = txtEmail.Text;
                                func.Funcao = txtFuncao.Text;
                                if (txtHorasTrabson.Text != string.Empty)
                                    func.Horas_trabalhadas = Convert.ToInt32(txtHorasTrabson.Text);
                                func.Nome = txtNomeFunc.Text;
                                if (txtSalario.Text != string.Empty)
                                    func.Salario_mensal = Convert.ToDouble(txtSalario.Text.Replace('.', ','));
                                acc.Password = txtSenha.Text;
                                func.Setor = txtSetor.Text;
                                func.Sobrenome = txtSobrenome.Text;
                                acc.Username = txtUsuario.Text;

                                accDao.inserir(acc);
                                func.Id_account = accDao.ReturnId(acc.Username);
                                funDAO.inserir(func);
                                MessageBox.Show("Cadastrado com sucesso");
                                this.Close();
                            }
                            catch (FormatException)
                            {
                                MessageBox.Show("Favor checar os valores.");
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            AccountsDAO accDao = new AccountsDAO();
                            Accounts acc = new Accounts();
                            if (txtCBO.Text != string.Empty)
                                func.Cbo = txtCBO.Text;
                            func.Email = txtEmail.Text;
                            func.Funcao = txtFuncao.Text;
                            if (txtHorasTrabson.Text != string.Empty)
                                func.Horas_trabalhadas = Convert.ToInt32(txtHorasTrabson.Text);
                            func.Nome = txtNomeFunc.Text;
                            if (txtSalario.Text != string.Empty)
                                func.Salario_mensal = Convert.ToDouble(txtSalario.Text.Replace('.', ','));
                            acc.Password = txtSenha.Text;
                            func.Setor = txtSetor.Text;
                            func.Sobrenome = txtSobrenome.Text;
                            acc.Username = txtUsuario.Text;
                            acc.AccountType = (AccountsDAO.accounttype)Convert.ToInt32(cmbLevel.SelectedValue);

                            accDao.inserir(acc);
                            func.Id_account = accDao.ReturnId(acc.Username);
                            funDAO.inserir(func);
                            MessageBox.Show("Cadastrado com sucesso");
                            this.Close();
                        }
                        catch (MySql.Data.MySqlClient.MySqlException err)
                        {
                            if (err.Message.Contains("'username_UNIQUE'"))
                            {
                                MessageBox.Show("Usuario já em uso");
                            }
                            else if (err.Message.Contains("'email_UNIQUE'"))
                            {
                                MessageBox.Show("email já em uso");
                            }
                            else
                            {
                                throw err;
                            }
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Favor checar os valores.");
                        }
                    }
                }
                #endregion
            }
            else
            {
                CargoDAO dao = new CargoDAO();
                Cargo cargo = new Cargo();

                cargo.Cbo = txtCBO.Text;
                cargo.Funcao = txtFuncao.Text;
                cargo.Horas_trabalhadas = int.Parse(txtHorasTrabson.Text);
                cargo.Nome = txtNomeFunc.Text;
                cargo.Salario_mensal = double.Parse(txtSalario.Text.Replace('.',','));
                cargo.Setor = txtSetor.Text;
                cargo.Sobrenome = txtSobrenome.Text;
                cargo.Id = id;

                dao.alterar(cargo);
                MessageBox.Show("Atualizado com sucesso");
                this.Close();
            }
        }

        private void frmCadastroFuncionário_Load(object sender, EventArgs e)
        {
            DataTable t = new DataTable();
            t.Columns.AddRange(new DataColumn[] {
                new DataColumn("id", typeof(int)),
                new DataColumn("nivel", typeof(string))
            });
            t.Rows.Add(1, "Funcionario");
            t.Rows.Add(2, "Administrador");

            cmbLevel.DataSource = t;
            cmbLevel.DisplayMember = "nivel";
            cmbLevel.ValueMember = "id";
            cmbLevel.SelectedIndex = 0;

            try
            {
                DAO dao = new DAO();
                DataTable table = dao.Load_Table("SELECT account_type FROM accounts WHERE id_accounts = '" + id_account + "'");
                cmbLevel.SelectedValue = int.Parse(table.Rows[0]["account_type"].ToString());
            }
            catch (Exception) { }
        }
    }
}
