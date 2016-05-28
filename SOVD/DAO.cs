using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOVD
{
    public class DAO
    {
        DataTable table;
        MySqlCommandBuilder builder;
        MySqlDataAdapter adapter;

        public DataTable Load_Table(string cmd)
        {
            table = new DataTable();
            adapter = new MySqlDataAdapter(cmd, Conexao.Conectar);
            builder = new MySqlCommandBuilder(adapter);
            adapter.Fill(table);
            return table;
        }
    }
}
