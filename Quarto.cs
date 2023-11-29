using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibi
{
    public class Quarto
    {
        // campos
        private string codigo { get; set; }
        private string nome { get; set; }
        private string numero { get; set; }
        private string tipo { get; set; }
        private string disponivel{ get; set; }

        // propriedades
        public string Codigo { get => codigo; private set => codigo = value; }
        public string Nome { get => nome; private set => codigo = value; }
        public string Numero { get => numero; private set => numero = value; }
        public string Tipo { get => tipo; private set => tipo = value; }
        public string Disponivel { get => disponivel; private set => disponivel = value; }

        // método construtor
        public Quarto(string cod, string nom, string num, string tip, string dis)
        {
            this.codigo = cod;
            this.nome = nom;
            this.numero = num;
            this.tipo = tip;
            this.disponivel = dis;
        }
    }
}