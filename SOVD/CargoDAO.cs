using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace SOVD
{
    class CargoDAO
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


        public void inserir(Cargo cargo)
        {
            executarComando("INSERT INTO opl.cargo (id_account, nome, sobrenome, setor, cbo, salario_mensal, horas_trabalhadas, email)"
                                              + " VALUES ("+cargo.Id_account+", '"+cargo.Nome+"', '"+cargo.Sobrenome+"', '"+cargo.Setor
                                              + "', '"+cargo.Cbo+"', '"+cargo.Salario_mensal+"', '"+cargo.Horas_trabalhadas+"', '"+cargo.Email+"');");
        }

        public DataTable listarPraSearch()
        {
            executarComando("SELECT id, nome, sobrenome, setor, cbo, email FROM cargo");
            return tabela_memoria;
        }

        public DataTable listarTudo()
        {
            executarComando("SELECT * FROM cargo;");
            return tabela_memoria;
        }

        public void alterarEmail(string newEmail, int id_account)
        {
            executarComando("UPDATE cargo set email = '" + newEmail + "' WHERE id_account = '" + id_account + "';");
        }

        public void alterar(Cargo cargo)
        {
            executarComando("UPDATE cargo SET nome = '" + cargo.Nome + "', sobrenome = '" + cargo.Sobrenome + "', setor = '" + cargo.Setor + "', funcao = '" + cargo.Funcao + "', cbo = '" + cargo.Cbo + "', salario_mensal = '" + cargo.Salario_mensal.ToString().Replace(',', '.') + "', horas_trabalhadas = '" + cargo.Horas_trabalhadas + "' WHERE id = '" + cargo.Id + "';");
        }

        public void delete(int id)
        {
            executarComando("DELETE FROM cargo WHERE id = '" + id + "';");
        }
    }
}
