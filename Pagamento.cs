using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibi
{
    public class Pagamento
    {
        // propriedades
        private string codigo;
        private string nome;
        private string valor;
        // private datetime date;
        private string tipo;

        // getters/setters
        public string Codigo { get => codigo; private set => codigo = value; }
        public string Nome { get => nome; private set => codigo = value; }
        public string Valor { get => valor; private set => valor = value; }
        public string Tipo { get => tipo; private set => tipo = value; }

        // método construtor
        public Pagamento(string cod, string nom, string val, string tip)
        {
            this.codigo = cod;
            this.nome = nom;
            this.valor = val;
            // this.data = dat;
            this.tipo = tip;
        }
    }
}