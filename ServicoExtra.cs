using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibi
{
    public class ServicoExtra
    {
        // propriedades
        private string codigo;
        private string nome;
        private string preco;

        // getters/setters
        public string Codigo { get => codigo; private set => codigo = value; }
        public string Nome { get => nome; private set => nome = value; }
        public string Preco { get => preco; private set => preco = value; }

        // método construtor
        public ServicoExtra(string cod, string nom, string pre)
        {
            this.codigo = cod;
            this.nome = nom;
            this.preco = pre;
        }
    }
}