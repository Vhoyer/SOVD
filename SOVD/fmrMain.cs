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
            LivrosDAO livrodao = new LivrosDAO();
            dgSearch.DataSource = livrodao.selectAll();

            foreach (DataColumn item in (dgSearch.DataSource as DataTable).Columns)
            {
                cbSearchType.Items.Add(item.ColumnName);
            }
            cbSearchType.SelectedIndex = 1;
            
            if (!System.IO.Directory.Exists(EnderecoCadastro()))
            {
                System.IO.Directory.CreateDirectory(EnderecoCadastro());
            }
            DAO dao = new DAO();
            cmbType.DataSource = dao.Load_Table("SELECT * FROM tipoprod");
            cmbType.ValueMember = "idTipoProd";
            cmbType.DisplayMember = "TipoProd";
            cmbTipo.DataSource = dao.Load_Table("SELECT * FROM tipoprod");
            cmbTipo.ValueMember = "idTipoProd";
            cmbTipo.DisplayMember = "TipoProd";
        }

        private void initiatePanels()
        {
            List<string> notAdd = new List<string>();
            notAdd.Add("pnlEdit");
            notAdd.Add("pnlWelcome");
            if (account.AccountType != AccountsDAO.accounttype.admin)
            {
                notAdd.Add("pnlFuncControl");
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
            txtAno.Text = livro.Year;
            txtAutores.Text = livro.Authors; 
            txtEditora.Text = livro.Publisher.ToString();
            txtEdição.Text = livro.Edicao.ToString();
            txtGenero.Text = livro.Gender;
            txtPreco.Text = livro.Price.ToString("0.00");
            txtSinopse.Text = livro.Sinopse;
            txtSubtitulo.Text = livro.Subtitle;
            txtTitulo.Text = livro.Title;
            cmbTipo.SelectedValue = livro.Type;
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

            if (txtAutores.Text == string.Empty ||
                txtEdição.Text == string.Empty ||
                txtPreco.Text == string.Empty ||
                txtSinopse.Text == string.Empty ||
                txtTitulo.Text == string.Empty)
            {
                MessageBox.Show("Os campos Destacados são obrigatorios e devem ser preenchidos");

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
                    book.Type = Convert.ToInt32(cmbTipo.SelectedValue);
                    //----
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
            throw new NotImplementedException();
        }
        #endregion
        //----------------------//
        //----------------------//
        //----------------------//
        #region "não me atrevo a mexer em codigos marcianos"
        Livro b = new Livro();
        LivrosDAO bdao = new LivrosDAO();
        private void btnCadProd_Click(object sender, EventArgs e)
        {

            if (txtFile.Text == string.Empty || txtTitle.Text == string.Empty || txtPrice.Text == string.Empty ||
                txtYear.Text == string.Empty || txtAutors.Text == string.Empty || txtEdition.Text == string.Empty ||
                txtEditora.Text == string.Empty || cmbType.Text == string.Empty || txtGenero.Text == string.Empty ||
                txtSinopse.Text == string.Empty)
            {
                if (txtFile.Text == string.Empty) txtFile.BackColor = Color.Salmon;
                if (txtTitle.Text == string.Empty) txtTitle.BackColor = Color.Salmon;
                if (txtPrice.Text == string.Empty) txtPrice.BackColor = Color.Salmon;
                if (txtYear.Text == string.Empty) txtYear.BackColor = Color.Salmon;
                if (txtAutors.Text == string.Empty) txtAutors.BackColor = Color.Salmon;
                if (txtEdition.Text == string.Empty) txtEdition.BackColor = Color.Salmon;
                if (txtEditora.Text == string.Empty) txtEditora.BackColor = Color.Salmon;
                if (cmbType.Text == string.Empty) cmbType.BackColor = Color.Salmon;
                if (txtGenero.Text == string.Empty) txtGenero.BackColor = Color.Salmon;
                if (txtSinopse.Text == string.Empty) txtSinopse.BackColor = Color.Salmon;
                MessageBox.Show("Preencha os campos em Rosa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (System.IO.Path.GetExtension(txtFile.Text) == ".pdf")
                    {
                        try
                        {
                            string FileName = System.IO.Path.GetFileName(txtFile.Text);
                            string newLocation = EnderecoCadastro() + FileName;
                            System.IO.File.Move(txtFile.Text, EnderecoCadastro() + FileName);
                            b.File = newLocation.ToString().Replace('\\', '/');
                            b.Title = txtTitle.Text;
                            b.Price = Convert.ToDouble(txtPrice.Text);
                            if (txtSubT.Text == string.Empty) b.Subtitle = null; else b.Subtitle = txtSubT.Text;
                            b.Year = txtYear.Text;
                            b.Authors = txtAutors.Text;
                            b.Edicao = Convert.ToInt32(txtEdition.Text);
                            b.Publisher = txtEditora.Text;
                            b.Type = Convert.ToInt32(cmbType.SelectedValue);
                            b.Gender = txtGenero.Text;
                            b.Sinopse = txtSinopse.Text;
                            bdao.inserir(b);
                            txtAutors.Text = string.Empty;
                            txtEdition.Text = string.Empty;
                            txtEditora.Text = string.Empty;
                            txtFile.Text = string.Empty;
                            txtGenero.Text = string.Empty;
                            txtPrice.Text = string.Empty;
                            txtSinopse.Text = string.Empty;
                            txtSubT.Text = string.Empty;
                            txtTitle.Text = string.Empty;
                            txtYear.Text = string.Empty;
                            cmbType.Text = string.Empty;
                        }
                        catch
                        {
                            MessageBox.Show("Reveja o endereço.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else MessageBox.Show("Tipo de arquivo não compativel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                catch (FormatException)
                {
                    MessageBox.Show("Reveja os Dados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void lstDragDropFile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void lstDragDropFile_DragDrop(object sender, DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string File in FileList)
            {
                if (System.IO.Path.GetExtension(File) == ".pdf")
                    txtFile.Text = File;
                else MessageBox.Show("Tipo de arquivo não compativel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string EnderecoCadastro()
        {

            string DebugE = (System.AppDomain.CurrentDomain.BaseDirectory.ToString());
            return DebugE + @"Livros/";

        }
        #endregion
        //----------------------//
        //----------------------//
        //----------------------//
        #region "pnlAdminConfig"
        private void pnlSearch_VisibleChanged(object sender, EventArgs e)
        {
            CargoDAO cargodao = new CargoDAO();
            dgvFuncs.DataSource = cargodao.listarPraSearch();
            if (cmbTipoPesquisaFunc.Items.Count <= 0)
            {
                foreach (DataColumn item in (dgvFuncs.DataSource as DataTable).Columns)
                    cmbTipoPesquisaFunc.Items.Add(item.ColumnName);
                cmbTipoPesquisaFunc.SelectedIndex = 1;
            }
        }

        private void btSearchfunc_Click(object sender, EventArgs e)
        {
            int i;
            List<string> keywords = new List<string>();
            keywords.AddRange(mtbSearch.Text.Split(' '));

            string sqlCmdLine = "SELECT id, nome, sobrenome, setor, cbo, email FROM cargo"
                + " WHERE ";
            for (i = 0; i < keywords.Count - 1; i++)
            {
                sqlCmdLine += cbSearchType.SelectedText + " LIKE '%" + keywords[i] + "%' OR ";
            }
            sqlCmdLine += cbSearchType.Text + " LIKE '%" + keywords[i] + "%'";
            //Forma o codigo do mysql pra fazer a pesquisa : sqlCmdLine
            DAO dao = new DAO();
            dgSearch.DataSource = dao.Load_Table(sqlCmdLine);
        }

        private void minharola()
        {

        }
        #endregion
    }
}
    