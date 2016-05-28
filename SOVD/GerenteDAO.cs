using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace SOVD
{
    class GerenteDAO
    {

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


        private void inserir(Gerente gerent)
        {
            executarComando("INSERT INTO gerente VALUES (0,'" + gerent.Nome_gerente + "','"
                + gerent.Sobrenome_gerente + "','" + gerent.Setor + "',','" + gerent.Cbo + "','"
                + gerent.Salario_mensal.ToString().Replace(',', '.') + "','"
                + gerent.Horas_trabalhadas + "','" + gerent.Usuario + "','" + gerent.Email + "','"
                + gerent.Senha + "',');");
        }

        private DataTable listarTudo()
        {
            executarComando("SELECT * FROM GERENTE;");
            return tabela_memoria;
        }

    }
}
