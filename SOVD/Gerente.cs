using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOVD
{
    class Gerente
    {

        string nome_gerente, sobrenome_gerente, setor, email;
        int cod_cad_gerente, cbo, horas_trabalhadas, id_account;
        double salario_mensal;


        #region Variaveis incapsuladas
        public double Salario_mensal
        {
            get { return salario_mensal; }
            set { salario_mensal = value; }
        }

        public int Horas_trabalhadas
        {
            get { return horas_trabalhadas; }
            set { horas_trabalhadas = value; }
        }

        public int Cbo
        {
            get { return cbo; }
            set { cbo = value; }
        }

        public int Cod_cad_gerente
        {
            get { return cod_cad_gerente; }
            set { cod_cad_gerente = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Setor
        {
            get { return setor; }
            set { setor = value; }
        }

        public string Sobrenome_gerente
        {
            get { return sobrenome_gerente; }
            set { sobrenome_gerente = value; }
        }

        public string Nome_gerente
        {
            get { return nome_gerente; }
            set { nome_gerente = value; }
        }


        #endregion
    }
}
