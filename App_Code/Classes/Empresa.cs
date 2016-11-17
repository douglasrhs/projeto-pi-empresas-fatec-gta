using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Empresa
/// </summary>
namespace PIxEmpresas.App_Code.Classes
{
    public class Empresa
    {
        private int codigo;
        private string nomeFantasia;
        private string telefone1;
        private string telefone2;
        private string endereco;
        private string cidade;
        private string estado;
        private string bairro;
        private string cep;
        private string email;

        public int Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public string NomeFantasia
        {
            get
            {
                return nomeFantasia;
            }

            set
            {
                nomeFantasia = value;
            }
        }

        public string Telefone1
        {
            get
            {
                return telefone1;
            }

            set
            {
                telefone1 = value;
            }
        }

        public string Telefone2
        {
            get
            {
                return telefone2;
            }

            set
            {
                telefone2 = value;
            }
        }

        public string Endereco
        {
            get
            {
                return endereco;
            }

            set
            {
                endereco = value;
            }
        }

        public string Cidade
        {
            get
            {
                return cidade;
            }

            set
            {
                cidade = value;
            }
        }

        public string Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }

        public string Bairro
        {
            get
            {
                return bairro;
            }

            set
            {
                bairro = value;
            }
        }

        public string Cep
        {
            get
            {
                return cep;
            }

            set
            {
                cep = value;
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
    }
}