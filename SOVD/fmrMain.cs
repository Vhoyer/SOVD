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
    public partial class frmMain : Form
    {
        Accounts account;//okokokokok
        int idLivro;
        public frmMain(Accounts account)
        {
            this.account = account;
            InitializeComponent();
            initiatePanels();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            pnlWelcome.BringToFront();
            Conexao.criar_Conexao();
            LivrosDAO dao = new LivrosDAO();
            dgSearch.DataSource = dao.selectAll();

            foreach (DataColumn item in (dgSearch.DataSource as DataTable).Columns)
            {
                cbSearchType.Items.Add(item.ColumnName);
            }
            cbSearchType.SelectedIndex = 1;
        }

        private void initiatePanels()
        {
            List<string> notAdd = new List<string>();
            notAdd.Add("pnlEdit");
            notAdd.Add("pnlWelcome");
            notAdd.Add("pnlAccountSettings");
            if (account.AccountType != AccountsDAO.accounttype.admin)
            {
                notAdd.Add("pnlCadGerente");
            }
            
            foreach (Control item in this.Controls)
            {
                if (item.Name.StartsWith("pnl") && !notAdd.Contains(item.Name))
                {
                    tsmiPnls.DropDownItems.Add(new ToolStripMenuItem(item.Name, null, tsmiPnls_click, item.Name));
                }
            }
        }

        private void tsmiPnls_click(object sender, EventArgs e)
        {
            switchPnl((sender as ToolStripMenuItem).Name);
        }

        public void switchPnl(string name)
        {
            foreach (Control item in this.Controls)
            {
                if (item.Name.StartsWith("pnl"))
                {
                    item.Visible = false;
                    if (item.Name == name)
                    {
                        item.Visible = true;
                    }
                }
            }
        }

        public void switchPnl(Control ctr)
        {
            foreach (Control item in this.Controls)
            {
                if (item.Name.StartsWith("pnl"))
                {
                    item.Visible = false;
                }
            }
            ctr.Visible = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            switchPnl(pnlWelcome);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        //----------------------//
        //----------------------//
        //----------------------//
        #region "BookSearch"
        private void ChamarOPainel()
        {
            switchPnl(pnlSearch);
            LivrosDAO dao = new LivrosDAO();
            dgSearch.DataSource = dao.SelectForSearch();
        }

        private void open_Edit(int cod)
        {
            idLivro = cod;
            LivrosDAO dao = new LivrosDAO();
            Livro livro = new Livro(){ Id = cod };
            switchPnl(pnlEdit);
            dao.Search(livro);

            txtArquivo.Text = livro.File;
            txtAno.Text = livro.Year;
            txtAutores.Text = livro.Authors; 
            txtEditora.Text = livro.Publisher.ToString();
            txtEdição.Text = livro.Edicao.ToString();
            txtGenero.Text = livro.Gender;
            txtPreco.Text = livro.Price.ToString("0.00");
            txtSinopse.Text = livro.Sinopse;
            txtSubtitulo.Text = livro.Subtitle;
            txtTitulo.Text = livro.Title;
        }

        private void dgSearch_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            open_Edit(Convert.ToInt32(dgSearch.CurrentRow.Cells[0].Value));
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            open_Edit(Convert.ToInt32(dgSearch.CurrentRow.Cells[0].Value));
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            int i;
            List<string> keywords = new List<string>();
            keywords.AddRange(mtbSearch.Text.Split(' '));

            string sqlCmdLine = "SELECT "
                + "idProd, title, subtitle, autors,"
                + " publisher, genders, price, year,"
                + " edition, type"
                + " FROM prod WHERE ";
            for (i = 0; i < keywords.Count - 1; i++)
            {
                sqlCmdLine += cbSearchType.SelectedText + " LIKE '%" + keywords[i] + "%' OR ";
            }
            sqlCmdLine += cbSearchType.Text + " LIKE '%" + keywords[i] + "%'";
            //Forma o codigo do mysql pra fazer a pesquisa : sqlCmdLine
            DAO dao = new DAO();
            dgSearch.DataSource = dao.Load_Table(sqlCmdLine);
        }
        #endregion
        //----------------------//
        //----------------------//
        //----------------------//
        #region "BookEdit"
        private void btnProcurar_Click(object sender, EventArgs e)
        {
            OpenFileDialog pesquisar = new OpenFileDialog();

            pesquisar.Title = "Pesquisar um arquivo";

            pesquisar.InitialDirectory = @"C:\";

            pesquisar.Filter = "Arquivos PDF (*.pdf)|*.pdf|Arquivos ePUB (*.epub)|*.epub|Arquivos MOBI (*.mobi)|*.mobi";

            DialogResult resp = pesquisar.ShowDialog();

            if (resp == DialogResult.OK)
            {
                string caminho = pesquisar.FileName;

                txtArquivo.Text = caminho.ToString();
            }

        }

        private void btnExc_Click(object sender, EventArgs e)
        {
            DialogResult exc;

            exc = MessageBox.Show("Deseja realmente excluir o livro?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (exc == DialogResult.Yes)
            {
                LivrosDAO bookDAO = new LivrosDAO();
                Livro book = new Livro();
                bookDAO.excluir(idLivro);

                MessageBox.Show("Livro excluido com sucesso!!");
            }
            else
            {
                MessageBox.Show("Cancelado.");
            }
        }

        private void btnAlt_Click(object sender, EventArgs e)
        {

            if (txtArquivo.Text == string.Empty ||
                txtAutores.Text == string.Empty ||
                txtEdição.Text == string.Empty ||
                txtPreco.Text == string.Empty ||
                txtSinopse.Text == string.Empty ||
                txtTitulo.Text == string.Empty)
            {
                MessageBox.Show("Os campos Destacados são obrigatorios e devem ser preenchidos");

                txtArquivo.BackColor = Color.Salmon;
                txtAutores.BackColor = Color.Salmon;
                txtEdição.BackColor = Color.Salmon;
                txtPreco.BackColor = Color.Salmon;
                txtSinopse.BackColor = Color.Salmon;
                txtTitulo.BackColor = Color.Salmon;
            }
            else
            {
                try
                {
                    Livro book = new Livro();
                    LivrosDAO bookDAO = new LivrosDAO();
                    book.Id = idLivro;
                    book.Title = txtTitulo.Text;
                    book.Subtitle = txtSubtitulo.Text;
                    book.Authors = txtAutores.Text;
                    book.Publisher = txtEditora.Text;
                    book.Sinopse = txtSinopse.Text;
                    book.Gender = txtGenero.Text;
                    book.Price = Convert.ToDouble(txtPreco.Text);
                    book.Year = txtAno.Text;
                    book.Edicao = Convert.ToInt32(txtEdição.Text);
                    book.File = txtArquivo.Text;
                    book.Type = Convert.ToInt32(cmbTipo.SelectedValue);
                    //----
                    txtArquivo.BackColor = Color.Empty;
                    txtAutores.BackColor = Color.Empty;
                    txtEditora.BackColor = Color.Empty;
                    txtGenero.BackColor = Color.Empty;
                    txtPreco.BackColor = Color.Empty;
                    txtSinopse.BackColor = Color.Empty;
                    txtTitulo.BackColor = Color.Empty;
                    //----
                    bookDAO.alterar(book);

                    MessageBox.Show("Dados alterados com sucesso!!");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Verificar as informações digitadas nos campos!!");
                }
            }
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            switchPnl(pnlSearch);
        }
        #endregion
        //----------------------//
        //----------------------//
        //----------------------//
        #region "StripMenu"
        private void trocarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }

        private void configuraçõesDaContaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switchPnl(pnlAccountSettings);
        } 
        #endregion
    }
}
    