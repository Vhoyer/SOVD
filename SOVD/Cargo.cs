using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOVD
{
    class Cargo
    {

        string nome, sobrenome, setor, funcao, email, cbo;
        int id, horas_trabalhadas, id_account;
        double salario_mensal;


        #region Variaveis incapsuladas
        public double Salario_mensal
        {
            get { return salario_mensal; }
            set { salario_mensal = value; }
        }

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public string Sobrenome
        {
            get
            {
                return sobrenome;
            }

            set
            {
                sobrenome = value;
            }
        }

        public string Setor
        {
            get
            {
                return setor;
            }

            set
            {
                setor = value;
            }
        }

        public string Funcao
        {
            get
            {
                return funcao;
            }

            set
            {
                funcao = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Cbo
        {
            get
            {
                return cbo;
            }

            set
            {
                cbo = value;
            }
        }

        public int Horas_trabalhadas
        {
            get
            {
                return horas_trabalhadas;
            }

            set
            {
                horas_trabalhadas = value;
            }
        }

        public int Id_account
        {
            get
            {
                return id_account;
            }

            set
            {
                id_account = value;
            }
        }

        #endregion
    }
}
